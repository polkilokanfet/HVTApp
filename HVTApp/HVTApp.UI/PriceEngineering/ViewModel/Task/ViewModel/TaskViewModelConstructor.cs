using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Extensions;
using HVTApp.Infrastructure.Interfaces;
using HVTApp.Infrastructure.Interfaces.Services;
using HVTApp.Infrastructure.Interfaces.Services.DialogService;
using HVTApp.Infrastructure.Services;
using HVTApp.Model;
using HVTApp.Model.POCOs;
using HVTApp.Model.Services;
using HVTApp.Model.Wrapper;
using HVTApp.Model.Wrapper.Base.TrackingCollections;
using HVTApp.UI.Commands;
using HVTApp.UI.PriceEngineering.DoStepCommand;
using HVTApp.UI.PriceEngineering.ParametersService1;
using HVTApp.UI.PriceEngineering.View;
using HVTApp.UI.PriceEngineering.Wrapper;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;

namespace HVTApp.UI.PriceEngineering
{
    public class TaskViewModelConstructor : TaskViewModelBaseConstructor
    {
        private TaskProductBlockAddedWrapperConstructor _selectedBlockAdded;
        private readonly TaskViewModelConstructor _parentTask;

        public override bool IsTarget => Equals(Model.UserConstructor?.Id, GlobalAppProperties.User.Id);

        public override bool IsEditMode
        {
            get
            {
                if (IsTarget == false) return false;
                
                var steps = new List<ScriptStep>
                {
                    ScriptStep.Start,
                    ScriptStep.RejectByManager,
                    ScriptStep.VerificationReject
                };

                return steps.Contains(Status);
            }
        }

        public override bool AllowEditAddedBlocks => IsEditMode;

        public TaskProductBlockAddedWrapperConstructor SelectedBlockAdded
        {
            get => _selectedBlockAdded;
            set => this.SetProperty(ref _selectedBlockAdded, value,
                () =>
                {
                    RemoveBlockAddedCommand.RaiseCanExecuteChanged();
                    CopyProductBlockAddedCommand.RaiseCanExecuteChanged();
                });
        }

        #region Buffer

        private static ProductBlock BufferProductBlock;
        private static PriceEngineeringTaskProductBlockAdded BufferProductBlockAdded;
        private static PriceEngineeringTask BufferPriceEngineeringTask;

        #endregion

        #region Commands

        /// <summary>
        /// Выбрать блок продукта
        /// </summary>
        public DelegateLogCommand SelectProductBlockCommand { get; }
        /// <summary>
        /// Команда добавления зависиммых блоков (например ЗИПов)
        /// </summary>
        public DelegateLogCommand AddBlockAddedCommand { get; }
        public DelegateLogCommand AddBlockAddedComplectCommand { get; }
        public DelegateLogConfirmationCommand RemoveBlockAddedCommand { get; }
        public DelegateLogCommand AddAnswerFilesCommand { get; }
        public DelegateLogConfirmationCommand RemoveAnswerFileCommand { get; }
        public ICommandRaiseCanExecuteChanged FinishCommand { get; }
        public ICommandRaiseCanExecuteChanged RejectCommand { get; }
        public DelegateLogCommand BlockAddedNewParameterCommand { get; }
        public DelegateLogCommand BlockNewParameterCommand { get; }

        /// <summary>
        /// Команда создания подзадачи (например, добавление площадки обслуживания).
        /// </summary>
        public DelegateLogCommand CreateSubTaskCommand { get; }
        /// <summary>
        /// Команда удаления подзадачи (например, добавление площадки обслуживания).
        /// </summary>
        public DelegateLogConfirmationCommand RemoveSubTaskCommand { get; }

        public DelegateLogCommand LoadJsonFileCommand { get; }

        /// <summary>
        /// Команда копирования основного блока в буфер обмена
        /// </summary>
        public DelegateLogCommand CopyProductBlockCommand { get; }

        /// <summary>
        /// Команда вставки основного блока из буфера обмена
        /// </summary>
        public DelegateLogConfirmationCommand PasteProductBlockCommand { get; }

        /// <summary>
        /// Команда копирования добавленного блока в буфер обмен
        /// </summary>
        public DelegateLogCommand CopyProductBlockAddedCommand { get; }

        /// <summary>
        /// Команда вставки добавленного блока из буфера обмена
        /// </summary>
        public DelegateLogCommand PasteProductBlockAddedCommand { get; }

        /// <summary>
        /// Команда копирования всей задачи в буфер обмена
        /// </summary>
        public DelegateLogCommand CopyPriceEngineeringTaskCommand { get; }

        /// <summary>
        /// Команда вставки всей задачи из буфера обмена
        /// </summary>
        public DelegateLogConfirmationCommand PastePriceEngineeringTaskCommand { get; }

        public DelegateLogConfirmationCommand SplitPriceEngineeringTaskCommand { get; }

        #endregion

        #region ctor

        private readonly IMessageService _messageService;

        public TaskViewModelConstructor(IUnityContainer container, Guid priceEngineeringTaskId, TaskViewModelConstructor parentTask) : base(container, priceEngineeringTaskId)
        {
            _parentTask = parentTask;
            _messageService = container.Resolve<IMessageService>();
            var eventAggregator = container.Resolve<IEventAggregator>();

            var vms = Model.ChildPriceEngineeringTasks.Select(priceEngineeringTask => new TaskViewModelConstructor(container, priceEngineeringTask.Id, this));
            ChildPriceEngineeringTasks = new ValidatableChangeTrackingCollection<TaskViewModel>(vms);

            //Обязательные параметры главного блока продукта задачи
            var productBlockRequiredParameters = Model.DesignDepartment
                .ParameterSets
                .FirstOrDefault(parameters => parameters.Parameters.AllContainsInById(Model.ProductBlockManager.Parameters))?
                .Parameters.ToList();

            #region Commands

            SelectProductBlockCommand = new DelegateLogCommand(
                () =>
                {
                    if (this.Model.ProductBlock.IsService)
                    {
                        _messageService.Message("Услуга не требует состава ПЗ. Комплекты для ремонта необходимо добавлять в разделе Дополнительные блоки.");
                        return;
                    }

                    var originProductBlock = this.ProductBlockEngineer.Model;
                    var selectedProductBlock = this.DesignDepartment.IsKitDepartment 
                        ? Container.Resolve<IGetProductService>().GetKit(this.DesignDepartment)?.ProductBlock
                        : Container.Resolve<IGetProductService>().GetProductBlock(originProductBlock, productBlockRequiredParameters);

                    if (selectedProductBlock == null || 
                        originProductBlock.Id == selectedProductBlock.Id) return;

                    this.ProductBlockEngineer.RejectChanges();

                    //если выбрали пустой КТТ
                    var emptyParameter = GlobalAppProperties.Actual.EmptyParameterCurrentTransformersSet;
                    if (emptyParameter != null && selectedProductBlock.Parameters.ContainsById(emptyParameter))
                    {
                        var dr = _messageService.ConfirmationDialog("Пустой КТТ", "Вы выбрали КТТ без ТТ. Хотите ли Вы запустить подбор ТТ?", defaultYes:true);
                        if (dr)
                        {
                            var rp = productBlockRequiredParameters.ToList();
                            rp.Add(GlobalAppProperties.Actual.ParameterCurrentTransformersSetCustom);
                            var product = Container.Resolve<IGetProductService>().GetProduct(rp);
                            if (product != null)
                            {
                                foreach (var block in product.GetBlocks())
                                {
                                    if (productBlockRequiredParameters.AllContainsInById(block.Parameters))
                                    {
                                        continue;
                                    }
                                    AddAddedBlock(block);
                                }
                            }
                        }
                    }

                    this.ProductBlockEngineer.RejectChanges();
                    this.ProductBlockEngineer = new ProductBlockStructureCostWrapperConstructor(UnitOfWork.Repository<ProductBlock>().GetById(selectedProductBlock.Id));
                },
                () => IsTarget && IsEditMode);

            AddBlockAddedCommand = new DelegateLogCommand(
                () =>
                {
                    var addedBlocksList = Model.DesignDepartment.ParameterSetsAddedBlocks;
                    if (addedBlocksList.Any() == false)
                    {
                        _messageService.Message("Вашему КБ не назначено ни одного дополнительного блока. Если необходимо их добавить, обратитесь к Косолапову А.Г.");
                        return;
                    }

                    var block = Container.Resolve<IGetProductService>().GetProductBlock(addedBlocksList);
                    if (block == null) return;
                    AddAddedBlock(block);
                },
                () => IsTarget && IsEditMode);

            AddBlockAddedComplectCommand = new DelegateLogCommand(
                () =>
                {
                    var kit = Container.Resolve<IGetProductService>().GetKit(this.DesignDepartment);
                    if (kit == null) return;
                    kit = UnitOfWork.Repository<Product>().GetById(kit.Id);
                    if (kit.DesignDepartmentsKits.ContainsById(this.Model.DesignDepartment) == false)
                    {
                        kit.DesignDepartmentsKits.Add(UnitOfWork.Repository<DesignDepartment>().GetById(this.Model.DesignDepartment.Id));
                    }
                    var wrapper = new TaskProductBlockAddedWrapperConstructor(new PriceEngineeringTaskProductBlockAdded())
                    {
                        ProductBlock = new ProductBlockStructureCostWrapperConstructor(kit.ProductBlock)
                    };
                    this.ProductBlocksAdded.Add(wrapper);
                },
                () => IsTarget && IsEditMode);

            RemoveBlockAddedCommand = new DelegateLogConfirmationCommand(
                _messageService, 
                "Вы уверены, что хотите удалить выделенное дополнительное оборудование?",
                () =>
                {
                    this.RemoveBlockAdded(SelectedBlockAdded.Model);
                    SelectedBlockAdded = null;
                },
                () => IsTarget && IsEditMode && SelectedBlockAdded != null);

            AddAnswerFilesCommand = new DelegateLogCommand(
                () =>
                {
                    var fileNames = container.Resolve<IGetFilePaths>().GetFilePaths().ToList();
                    if (fileNames.Any() == false) return;

                    //копируем каждый файл
                    foreach (var fileName in fileNames)
                    {
                        var fileWrapper = new PriceEngineeringTaskFileAnswerWrapper(new PriceEngineeringTaskFileAnswer())
                        {
                            Name = Path.GetFileNameWithoutExtension(fileName).LimitLength(50),
                            Path = fileName
                        };
                        this.FilesAnswers.Add(fileWrapper);
                    }
                },
                () => IsTarget && IsEditMode == true);

            RemoveAnswerFileCommand = new DelegateLogConfirmationCommand(
                _messageService,
                "Вы уверены, что хотите удалить выделенный файл?",
                () => { this.FilesAnswers.Remove(SelectedFileAnswer); }, 
                () => IsTarget && IsEditMode && SelectedFileAnswer != null);

            FinishCommand = new DoStepCommandFinishByConstructor(this, container);

            RejectCommand = new DoStepCommandRejectedByConstructor(this, container);

            BlockAddedNewParameterCommand = new DelegateLogCommand(
                () =>
                {
                    Container.Resolve<IDialogService>().ShowDialog(new ParametersServiceViewModel(Container, this.Model.DesignDepartment));
                },
                () => IsEditMode);

            BlockNewParameterCommand = new DelegateLogCommand(
                () =>
                {
                    Container.Resolve<IDialogService>().ShowDialog(new ParametersServiceViewModel(Container, this.Model.ProductBlockEngineer, productBlockRequiredParameters));
                },
                () => IsEditMode);

            CreateSubTaskCommand = new DelegateLogCommand(
                () =>
                {
                    if (this.Model.DesignDepartment.ParameterSetsSubTask.Any() == false)
                    {
                        _messageService.Message("Информация", "Ваше КБ не имеет продуктов для поручения.");
                        return;
                    }

                    var getProductService = Container.Resolve<IGetProductService>();

                    var block = getProductService.GetProductBlock(Model.DesignDepartment.ParameterSetsSubTask);
                    if (block == null) return;

                    using (var unitOfWork = Container.Resolve<IUnitOfWorkFactory>().GetUnitOfWork())
                    {
                        block = unitOfWork.Repository<ProductBlock>().GetById(block.Id);
                        var product = getProductService.GetSavedOrSaveProduct(new Product { ProductBlock = block });
                        product = unitOfWork.Repository<Product>().GetById(product.Id);

                        var taskViewModel = new TaskViewModelManagerNew(Container, unitOfWork, product, 1)
                        {
                            ParentPriceEngineeringTaskId = this.Model.Id,
                        };

                        if (taskViewModel.DesignDepartment == null)
                        {
                            _messageService.Message("Ошибка", $"Данному продукту не назначено КБ. Обратитесь для назначения к администратору:\n{product.ProductBlock.ParametersOrdered.ToStringEnum("\n")}");
                            return;
                        }

                        taskViewModel.Model.Statuses.Where(status => status.StatusEnum == ScriptStep.Create.Value).ForEach(status => status.Moment = DateTime.Now.AddSeconds(-3));
                        taskViewModel.Model.UserConstructorInitiator = unitOfWork.Repository<User>().GetById(GlobalAppProperties.User.Id);
                        taskViewModel.FilesTechnicalRequirements.AddRange(this.FilesTechnicalRequirements.Where(file => file.IsActual).Select(fileWrapper => new PriceEngineeringTaskFileTechnicalRequirementsWrapper(unitOfWork.Repository<PriceEngineeringTaskFileTechnicalRequirements>().GetById(fileWrapper.Id))));

                        taskViewModel.StartCommand.ExecuteWithoutConfirmation();
                        this.ChildPriceEngineeringTasks.Add(new TaskViewModelConstructor(this.Container, taskViewModel.Model.Id, this));
                    }
                },
                () => IsTarget && IsEditMode);

            RemoveSubTaskCommand = new DelegateLogConfirmationCommand(
                _messageService,
                "Вы уверены, что хотите удалить созданную Вами подзадачу?",
                () =>
                {
                    _parentTask.RemoveChildTask(this.Model);
                },
                () => _parentTask != null && this.Model.UserConstructorInitiator?.Id == GlobalAppProperties.User.Id);

            LoadJsonFileCommand = new DelegateLogCommand(
                () =>
                {
                    var fPath = Container.Resolve<IFilesStorageService>().GetDirectoryPath();
                    var blocks = Container.Resolve<IJsonService>().ReadJsonFile<List<PriceEngineeringTaskProductBlockAdded>>($"{fPath}\\test.json");
                    this.ProductBlocksAdded.AddRange(blocks.Select(x => new TaskProductBlockAddedWrapperConstructor(x)));
                });

            SplitPriceEngineeringTaskCommand = new DelegateLogConfirmationCommand(
                _messageService,
                $"Вы уверены, что хотите разделить задачу на {this.Amount}?",
                () =>
                {
                    if (SaveCommand.CanExecute())
                    {
                        var dr = _messageService.ConfirmationDialog("Сохранить предварительно задачу?");
                        if (dr)
                            SaveCommand.Execute();
                    }

                    using (var unitOfWork = container.Resolve<IUnitOfWork>())
                    {
                        var parenTask = unitOfWork.Repository<PriceEngineeringTask>().GetById(this.Model.Id);
                        for (int i = 1; i < parenTask.Amount; i++)
                        {
                            var task = GetCopy(parenTask);
                            task.Amount = 1;
                            unitOfWork.Repository<PriceEngineeringTask>().Add(task);
                        }

                        parenTask.Amount = 1;
                        unitOfWork.SaveChanges();
                    }

                    var parameters = new NavigationParameters { { nameof(PriceEngineeringTask), parentTask.Model } };
                    container.Resolve<IRegionManager>().RequestNavigateContentRegion<PriceEngineeringTasksViewConstructor>(parameters);
                },
                () => IsEditMode && this.Amount > 1);


            eventAggregator.GetEvent<CopyProductBlockEvent>().Subscribe(() =>
            {
                this.PasteProductBlockCommand.RaiseCanExecuteChanged();
            });

            eventAggregator.GetEvent<CopyProductBlockAddedEvent>().Subscribe(() =>
            {
                this.PasteProductBlockAddedCommand.RaiseCanExecuteChanged();
            });

            eventAggregator.GetEvent<CopyPriceEngineeringTaskEvent>().Subscribe(() =>
            {
                this.PastePriceEngineeringTaskCommand.RaiseCanExecuteChanged();
            });

            CopyProductBlockCommand = new DelegateLogCommand(() =>
            {
                BufferProductBlock = this.Model.ProductBlock;
                eventAggregator.GetEvent<CopyProductBlockEvent>().Publish();
            });

            CopyProductBlockAddedCommand = new DelegateLogCommand(() =>
            {
                BufferProductBlockAdded = this.SelectedBlockAdded.Model;
                eventAggregator.GetEvent<CopyProductBlockAddedEvent>().Publish();
            }, () => this.IsTarget && this.SelectedBlockAdded != null);

            CopyPriceEngineeringTaskCommand = new DelegateLogCommand(() =>
            {
                BufferPriceEngineeringTask = this.Model;
                eventAggregator.GetEvent<CopyPriceEngineeringTaskEvent>().Publish();
            }, () => this.IsTarget);

            PasteProductBlockCommand = new DelegateLogConfirmationCommand(
                _messageService,
                "Вы уверены, что хотите вставить блок оборудования из буфера обмена?",
                () => this.PasteProductBlock(BufferProductBlock),
                () => this.IsEditMode && BufferProductBlock != null);

            PasteProductBlockAddedCommand = new DelegateLogCommand(
                () => this.PasteProductBlockAdded(BufferProductBlockAdded),
                () => this.IsEditMode && BufferProductBlockAdded != null);

            PastePriceEngineeringTaskCommand = new DelegateLogConfirmationCommand(
                _messageService,
                "Вы уверены, что хотите вставить все данные задачи из буфера обмена?",
                () =>
                {
                    if (!this.PasteProductBlock(BufferPriceEngineeringTask.ProductBlock)) return;

                    foreach (var blockAdded in this.ProductBlocksAdded.Select(ba => ba.Model).ToList())
                    {
                        this.RemoveBlockAdded(blockAdded);
                    }

                    foreach (var blockAdded in BufferPriceEngineeringTask.ProductBlocksAdded)
                    {
                        this.PasteProductBlockAdded(blockAdded);
                    }
                },
                () => this.IsEditMode && BufferPriceEngineeringTask != null);


            #endregion

            this.SelectedAnswerFileIsChanged += () => RemoveAnswerFileCommand.RaiseCanExecuteChanged();

            this.Statuses.CollectionChanged += (sender, args) =>
            {
                RaisePropertyChanged(nameof(AllowEditAddedBlocks));
            };
        }

        #endregion

        private PriceEngineeringTask GetCopy(PriceEngineeringTask parentTask)
        {
            var result = ShallowCopyEntity(parentTask);

            result.ChildPriceEngineeringTasks = parentTask.ChildPriceEngineeringTasks.Select(GetCopy).ToList();
            result.ProductBlocksAdded = parentTask.ProductBlocksAdded.Select(ShallowCopyEntity).ToList();
            result.Messages = parentTask.Messages.Select(ShallowCopyEntity).ToList();
            result.Statuses = parentTask.Statuses.Select(ShallowCopyEntity).ToList();

            return result;
        }

        private static TEntity ShallowCopyEntity<TEntity>(TEntity source)
            where TEntity : class, new()
        {
            var sourceProperties = typeof(TEntity)
                .GetProperties()
                .Where(info => 
                    info.CanRead && 
                    info.CanWrite &&
                    info.Name != "Id" &&
                    info.Name != "FilesAnswers")
                .ToList(); 
            var newObj = new TEntity();

            foreach (var property in sourceProperties)
            {
                property.SetValue(newObj, property.GetValue(source, null), null);
            }
            return newObj;
        }

        private bool RemoveBlockAdded(PriceEngineeringTaskProductBlockAdded ba)
        {
            var blockAdded = this.ProductBlocksAdded.Single(x => x.Model.Id == ba.Id);
            blockAdded.RejectChanges();
            if (blockAdded.Model.StructureCostVersions.Any())
            {
                blockAdded.IsRemoved = true;
            }
            else
            {
                if (blockAdded.Model.PriceEngineeringTaskId == this.Model.Id &&
                    UnitOfWork.Repository<PriceEngineeringTaskProductBlockAdded>().GetById(blockAdded.Model.Id) != null)
                {
                    UnitOfWork.Repository<PriceEngineeringTaskProductBlockAdded>().Delete(blockAdded.Model);
                }

                this.ProductBlocksAdded.Remove(blockAdded);
            }

            return true;
        }

        private bool PasteProductBlock(ProductBlock productBlock)
        {
            if (this.Model.DesignDepartment.ProductBlockIsSuitable(productBlock) == false)
            {
                _messageService.Message($"Блок <{productBlock.Designation}> не подходит для КБ <{this.Model.DesignDepartment}>");
                return false;
            }

            this.ProductBlockEngineer = new ProductBlockStructureCostWrapperConstructor(this.UnitOfWork.Repository<ProductBlock>().GetById(productBlock.Id));
            return true;
        }

        private bool PasteProductBlockAdded(PriceEngineeringTaskProductBlockAdded blockAdded)
        {
            this.ProductBlocksAdded.Add(
                new TaskProductBlockAddedWrapperConstructor(
                    new PriceEngineeringTaskProductBlockAdded
                    {
                        Amount = blockAdded.Amount,
                        ProductBlock = this.UnitOfWork.Repository<ProductBlock>().GetById(blockAdded.ProductBlock.Id),
                        IsOnBlock = blockAdded.IsOnBlock
                    }));

            return true;
        }

        protected override void SaveCommand_ExecuteMethod()
        {
            //добавление задач на смену стракчакоста
            var targetProductBlocks = ProductBlocksAdded
                .Where(x => x.ProductBlock.StructureCostNumberIsChanged)
                .Where(x => string.IsNullOrWhiteSpace(x.ProductBlock.StructureCostNumberOriginalValue) == false)
                .Select(x => x.ProductBlock)
                .ToList();
            if (ProductBlockEngineer.StructureCostNumberIsChanged)
                if (string.IsNullOrWhiteSpace(ProductBlockEngineer.StructureCostNumberOriginalValue) == false)
                    targetProductBlocks.Add(ProductBlockEngineer);

            if (targetProductBlocks.Any())
            {
                var sb = new StringBuilder();
                sb.AppendLine("Запросы на изменения номеров стракчакостов:");
                var moment = DateTime.Now;

                foreach (var pb in targetProductBlocks)
                {
                    var ut = new UpdateStructureCostNumberTaskForConstructorViewModel(new UpdateStructureCostNumberTask())
                    {
                        ProductBlock = new ProductBlockEmptyWrapper(pb.Model),
                        MomentStart = moment,
                        StructureCostNumber = pb.StructureCostNumber,
                        StructureCostNumberOriginal = pb.StructureCostNumberOriginalValue
                    };
                    this.UpdateStructureCostNumberTasks.Add(ut);
                    sb.AppendLine($" - {ut.Model.ToString()};");
                }

                Messenger.SendMessage(sb.ToString(), false);
            }

            base.SaveCommand_ExecuteMethod();
        }

        protected override bool SaveCommand_CanExecuteMethod()
        {
            return IsTarget && IsEditMode && this.IsValid && this.IsChanged;
        }


        private void AddAddedBlock(ProductBlock block)
        {
            block = UnitOfWork.Repository<ProductBlock>().GetById(block.Id);
            var wrapper = new TaskProductBlockAddedWrapperConstructor(new PriceEngineeringTaskProductBlockAdded())
            {
                ProductBlock = new ProductBlockStructureCostWrapperConstructor(block)
            };
            this.ProductBlocksAdded.Add(wrapper);
        }

        public void RemoveChildTask(PriceEngineeringTask priceEngineeringTask)
        {
            var taskViewModel = this.ChildPriceEngineeringTasks.Single(x => x.Model.Id == priceEngineeringTask.Id);
            ChildPriceEngineeringTasks.Remove(taskViewModel);

            var unitOfWork = Container.Resolve<IUnitOfWork>();
            var task = unitOfWork.Repository<PriceEngineeringTask>().GetById(taskViewModel.Model.Id);
            task.FilesTechnicalRequirements.Clear();

            //task.FilesAnswers.ForEach(x => unitOfWork.RemoveEntity(x));
            //task.Messages.ForEach(x => unitOfWork.RemoveEntity(x));
            //task.ProductBlocksAdded.ForEach(x => unitOfWork.RemoveEntity(x));
            //task.Statuses.ForEach(x => unitOfWork.RemoveEntity(x));

            task.ProductBlocksAdded
                .SelectMany(blockAdded => blockAdded.StructureCostVersions)
                .ForEach(structureCostVersion => unitOfWork.RemoveEntity(structureCostVersion));

            task.UpdateStructureCostNumberTasks
                .ToList()
                .ForEach(updateStructureCostNumberTask => unitOfWork.Repository<UpdateStructureCostNumberTask>().Delete(updateStructureCostNumberTask));

            unitOfWork.RemoveEntity(task);

            unitOfWork.SaveChanges();
        }
    }

    public class CopyProductBlockEvent : PubSubEvent { }
    public class CopyProductBlockAddedEvent : PubSubEvent { }
    public class CopyPriceEngineeringTaskEvent : PubSubEvent { }
}