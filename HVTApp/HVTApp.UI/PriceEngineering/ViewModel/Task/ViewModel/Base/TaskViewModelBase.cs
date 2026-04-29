using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Comparers;
using HVTApp.Infrastructure.Exceptions;
using HVTApp.Infrastructure.Extensions;
using HVTApp.Infrastructure.Interfaces;
using HVTApp.Model;
using HVTApp.Model.POCOs;
using HVTApp.Model.Services;
using HVTApp.Model.Wrapper;
using HVTApp.Model.Wrapper.Base;
using HVTApp.Model.Wrapper.Base.TrackingCollections;
using Microsoft.Practices.Unity;

namespace HVTApp.UI.PriceEngineering
{
    public abstract class TaskViewModelBase : WrapperBase<PriceEngineeringTask>
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IUnityContainer Container;

        #region ctors

        private TaskViewModelBase(IUnityContainer container, IUnitOfWork unitOfWork, PriceEngineeringTask priceEngineeringTask)
            : base(priceEngineeringTask)
        {
            Container = container;
            UnitOfWork = unitOfWork;

            this.PropertyChanged += (sender, args) =>
            {
                this.RaiseCommandsCanExecuteChanged();
            };

            if (Model.Statuses == null) throw new ArgumentException("Statuses cannot be null");
            Statuses = new StatusesContainer(Model.Statuses);
            RegisterCollection(Statuses, Model.Statuses);

            this.InCtor();
        }

        protected TaskViewModelBase(IUnityContainer container, IUnitOfWork unitOfWork, Guid priceEngineeringTaskId)
            : this(container, unitOfWork, unitOfWork.Repository<PriceEngineeringTask>().GetById(priceEngineeringTaskId))
        {
        }

        protected TaskViewModelBase(IUnityContainer container, IUnitOfWork unitOfWork)
            : this(container, unitOfWork, new PriceEngineeringTask())
        {
        }

        /// <summary>
        /// Метод запускается в конце каждого конструктора
        /// </summary>
        protected virtual void InCtor() { }

        #endregion

        #region SimpleProperties

        #region Amount

        /// <summary>
        /// Количество блоков продукта
        /// </summary>
        public int Amount
        {
            get => Model.Amount;
            set => SetValue(value);
        }
        public int AmountOriginalValue => GetOriginalValue<int>(nameof(Amount));
        public bool AmountIsChanged => GetIsChanged(nameof(Amount));

        #endregion

        #region ParentPriceEngineeringTaskId

        /// <summary>
        /// Id материнской задачи
        /// </summary>
        public Guid ParentPriceEngineeringTaskId
        {
            get => GetValue<Guid>();
            set => SetValue(value);
        }
        public Guid ParentPriceEngineeringTaskIdOriginalValue => GetOriginalValue<Guid>(nameof(ParentPriceEngineeringTaskId));
        public bool ParentPriceEngineeringTaskIdIsChanged => GetIsChanged(nameof(ParentPriceEngineeringTaskId));

        #endregion

        /// <summary>
        /// Статус
        /// </summary>
        public ScriptStep Status => this.Model.Status;

        /// <summary>
        /// ТЗ валидно для производства
        /// </summary>
        public bool IsValidForProduction => Model.IsValidForProduction;

        public string TceNumber
        {
            get
            {
                try
                {
                    return Model.GetPriceEngineeringTasks(this.UnitOfWork).TceNumber;
                }
                catch (EntityNotInDataBaseException)
                {
                    return null;
                }
            }
        }

        #endregion

        #region ComplexProperties

        /// <summary>
        /// Конструктор
        /// </summary>
        public User UserConstructor => Model.UserConstructor;

        /// <summary>
        /// Бюро конструкторов
        /// </summary>
        public DesignDepartment DesignDepartment => Model.DesignDepartment;

        /// <summary>
        /// Блок продукта от инженера-конструктора
        /// </summary>
	    public ProductBlockEmptyWrapper ProductBlockEngineer => Model.ProductBlockEngineer == null ? null : new ProductBlockEmptyWrapper(Model.ProductBlockEngineer);

        #endregion

        #region CollectionProperties

        /// <summary>
        /// Файлы технических требований
        /// </summary>
        public FilesContainerTechnicalRequrements FilesTechnicalRequirements { get; private set; }

        /// <summary>
        /// Файлы ответов ОГК
        /// </summary>
        public FilesContainerAnswers FilesAnswers { get; private set; }

        /// <summary>
        /// Статусы проработки
        /// </summary>
        public StatusesContainer Statuses { get; private set; }

        /// <summary>
        /// SalesUnits
        /// </summary>
        public IValidatableChangeTrackingCollection<SalesUnitWithSignalToStartProductionWrapper> SalesUnits { get; private set; }

        /// <summary>
        /// Добавленные блоки продукта от инженера-конструктора
        /// </summary>
        public IEnumerable<TaskProductBlockAddedWrapperConstructor> ProductBlocksAdded => Model.ProductBlocksAdded.Select(x => new TaskProductBlockAddedWrapperConstructor(x));

        #endregion

        /// <summary>
        /// Дочерние задачи
        /// ChildPriceEngineeringTasks инициализируются в дочерних классах
        /// </summary>
        public IValidatableChangeTrackingCollection<TaskViewModel> ChildPriceEngineeringTasks { get; protected set; }

        #region InitializeProperties

        public override void InitializeComplexProperties()
        {
        }

        protected override void InitializeCollectionProperties()
        {
            if (Model.FilesTechnicalRequirements == null) throw new ArgumentException("FilesTechnicalRequirements cannot be null");
            FilesTechnicalRequirements = new FilesContainerTechnicalRequrements(
                Model.FilesTechnicalRequirements.OrderBy(x => x.CreationMoment).Select(e => new PriceEngineeringTaskFileTechnicalRequirementsWrapper(e)),
                () =>
                {
                    var uow = this.Container.Resolve<IUnitOfWork>();
                    var task = uow.Repository<PriceEngineeringTask>().GetById(this.Model.Id);
                    var result = new List<PriceEngineeringTaskFileTechnicalRequirementsWrapper>();
                    if (task != null)
                    {
                        var fs = this.Container.Resolve<IFilesStorageService>();
                        var files = task
                            .GetTopPriceEngineeringTask(uow)
                            .GetAllPriceEngineeringTasks()
                            .SelectMany(x => x.FilesTechnicalRequirements)
                            .Distinct()
                            .Select(x => this.UnitOfWork.Repository<PriceEngineeringTaskFileTechnicalRequirements>().GetById(x.Id));
                        foreach (var file in files)
                        {
                            try
                            {
                                result.Add(new PriceEngineeringTaskFileTechnicalRequirementsWrapper(file)
                                {
                                    Path = fs.FindFile(file.Id, GlobalAppProperties.Actual.TechnicalRequrementsFilesPath).FullName
                                });
                            }
                            catch (FileNotFoundException)
                            {
                            }
                        }
                    }

                    return result;
                });
            RegisterCollection(FilesTechnicalRequirements, Model.FilesTechnicalRequirements);

            if (Model.FilesAnswers == null) throw new ArgumentException("FilesAnswers cannot be null");
            FilesAnswers = new FilesContainerAnswers(
                Model.FilesAnswers.OrderBy(x => x.CreationMoment).Select(e => new PriceEngineeringTaskFileAnswerWrapper(e)),
                () =>
                {
                    return new List<PriceEngineeringTaskFileAnswerWrapper>();
                    //var fs = this.Container.Resolve<IFilesStorageService>();
                    //return Model
                    //    .GetTopPriceEngineeringTask(this.UnitOfWork)
                    //    .GetAllPriceEngineeringTasks()
                    //    .SelectMany(x => x.FilesAnswers)
                    //    .Distinct()
                    //    .Select(x => new PriceEngineeringTaskFileAnswerWrapper(x)
                    //    {
                    //        Path = fs.FindFile(x.Id, GlobalAppProperties.Actual.TechnicalRequrementsFilesAnswersPath).FullName
                    //    });
                });
            RegisterCollection(FilesAnswers, Model.FilesAnswers);

            if (Model.SalesUnits == null) throw new ArgumentException("SalesUnits cannot be null");
            SalesUnits = new ValidatableChangeTrackingCollection<SalesUnitWithSignalToStartProductionWrapper>(Model.SalesUnits.Select(e => new SalesUnitWithSignalToStartProductionWrapper(e)));
            RegisterCollection(SalesUnits, Model.SalesUnits);
        }

        #endregion

        /// <summary>
        /// Проверка всех команд на возможность исполнения
        /// </summary>
        private void RaiseCommandsCanExecuteChanged()
        {
            this.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(propertyInfo => typeof(ICommandRaiseCanExecuteChanged).IsAssignableFrom(propertyInfo.PropertyType))
                .Select(propertyInfo => propertyInfo.GetValue(this))
                .Where(x => x != null)
                .Cast<ICommandRaiseCanExecuteChanged>()
                .ForEach(command => command.RaiseCanExecuteChanged());
        }

        #region FilesContainer

        public abstract class FilesContainer<TItemWrapper> : ValidatableChangeTrackingCollection<TItemWrapper> 
            where TItemWrapper : class, IValidatableChangeTracking, IFilePathContainer, IIsActual
        {
            public abstract string StoragePath { get; }

            protected FilesContainer(IEnumerable<TItemWrapper> items) : base(items)
            {
            }

            //public new void Add(TItemWrapper item)
            //{
            //    if (GetAllLoadedFileWrappers().SingleOrDefault(x => FileComparer.FileCompare(item.Path, x.Path)) != null)
            //    {
            //        //_messageService.ShowOkMessageDialog("No", $"ТЗ <{item}> уже добавлено");
            //        return;
            //    }
            //    base.Add(item);
            //}

            public new void Remove(TItemWrapper item)
            {
                if (string.IsNullOrEmpty(item.Path))
                {
                    item.IsActual = false;
                    return;
                }

                base.Remove(item);
            }

            public override void AcceptChanges()
            {
                LoadNewFilesInStorage();
                base.AcceptChanges();
            }

            /// <summary>
            /// Загрузить все добавленные файлы в хранилище
            /// </summary>
            private void LoadNewFilesInStorage()
            {
                if (this.AddedItems.Any(file => string.IsNullOrWhiteSpace(file.Path) == false) == false) 
                    return;

                //новые файлы, которые нужно загрузить (в них пути к файлу не пустые)
                var addedFiles = this.AddedItems
                    .Where(file => string.IsNullOrWhiteSpace(file.Path) == false)
                    .ToList();

                //уже загруженные в хранилище файлы
                var allLoadedFiles = GetAllLoadedFileWrappers()
                    .Where(x => string.IsNullOrEmpty(x.Path) == false)
                    .ToList();

                foreach (var file in addedFiles)
                {
                    var sameFile = allLoadedFiles
                        .Where(x => string.IsNullOrEmpty(x.Path) == false)
                        .FirstOrDefault(x => FileComparer.FilesAreEqual(file.Path, x.Path));

                    if (sameFile != null)
                    {
                        this.Add(sameFile);
                        this.Remove(file);
                    }
                    else
                    {
                        file.LoadToStorage(this.StoragePath);
                        allLoadedFiles.Add(file);
                    }
                }
            }

            /// <summary>
            /// Получить все загруженные в настоящий момент файлы
            /// </summary>
            /// <returns></returns>
            protected abstract IEnumerable<TItemWrapper> GetAllLoadedFileWrappers();
        }

        public class FilesContainerTechnicalRequrements : FilesContainer<PriceEngineeringTaskFileTechnicalRequirementsWrapper>
        {
            private readonly Func<IEnumerable<PriceEngineeringTaskFileTechnicalRequirementsWrapper>> _getAllLoadedFileWrappers;
            public override string StoragePath => GlobalAppProperties.Actual.TechnicalRequrementsFilesPath;

            protected override IEnumerable<PriceEngineeringTaskFileTechnicalRequirementsWrapper> GetAllLoadedFileWrappers()
            {
                return _getAllLoadedFileWrappers.Invoke();
            }

            public FilesContainerTechnicalRequrements(IEnumerable<PriceEngineeringTaskFileTechnicalRequirementsWrapper> items, Func<IEnumerable<PriceEngineeringTaskFileTechnicalRequirementsWrapper>> getAllLoadedFileWrappers) : base(items)
            {
                _getAllLoadedFileWrappers = getAllLoadedFileWrappers;
            }
        }

        public class FilesContainerAnswers : FilesContainer<PriceEngineeringTaskFileAnswerWrapper>
        {
            private readonly Func<IEnumerable<PriceEngineeringTaskFileAnswerWrapper>> _getAllLoadedFileWrappers;
            public override string StoragePath => GlobalAppProperties.Actual.TechnicalRequrementsFilesAnswersPath;
            protected override IEnumerable<PriceEngineeringTaskFileAnswerWrapper> GetAllLoadedFileWrappers()
            {
                return _getAllLoadedFileWrappers.Invoke();
            }

            public FilesContainerAnswers(IEnumerable<PriceEngineeringTaskFileAnswerWrapper> items, Func<IEnumerable<PriceEngineeringTaskFileAnswerWrapper>> getAllLoadedFileWrappers) : base(items)
            {
                _getAllLoadedFileWrappers = getAllLoadedFileWrappers;
            }
        }

        #endregion

        #region StatusesContainer

        public class StatusesContainer : ValidatableChangeTrackingCollection<PriceEngineeringTaskStatusEmptyWrapper>
        {
            public StatusesContainer(IEnumerable<PriceEngineeringTaskStatus> items) : base(items.Select(taskStatus => new PriceEngineeringTaskStatusEmptyWrapper(taskStatus)))
            {
            }

            /// <summary>
            /// Добавление статуса в коллекцию
            /// </summary>
            /// <param name="step"></param>
            /// <param name="comment"></param>
            public PriceEngineeringTaskStatus Add(ScriptStep step, string comment = null)
            {
                var status = new PriceEngineeringTaskStatus
                {
                    StatusEnum = step.Value,
                    Moment = DateTime.Now,
                    Comment = comment
                };

                this.Add(new PriceEngineeringTaskStatusEmptyWrapper(status));

                return status;
            }
        }


        #endregion
    }

    public class SalesUnitWithSignalToStartProductionWrapper : WrapperBase<SalesUnit>
    {
        #region SimpleProperties

        /// <summary>
        /// Сигнал менеджера о производстве
        /// </summary>
        public DateTime? SignalToStartProduction
        {
            get => GetValue<DateTime?>();
            set => SetValue(value);
        }
        public DateTime? SignalToStartProductionOriginalValue => GetOriginalValue<DateTime?>(nameof(SignalToStartProduction));
        public bool SignalToStartProductionIsChanged => GetIsChanged(nameof(SignalToStartProduction));

        /// <summary>
        /// Дата размещения в производстве
        /// </summary>
        public DateTime? SignalToStartProductionDone
        {
            get => GetValue<DateTime?>();
            set => SetValue(value);
        }
        public DateTime? SignalToStartProductionDoneOriginalValue => GetOriginalValue<DateTime?>(nameof(SignalToStartProductionDone));
        public bool SignalToStartProductionDoneIsChanged => GetIsChanged(nameof(SignalToStartProductionDone));

        #endregion

        public SalesUnitWithSignalToStartProductionWrapper(SalesUnit model) : base(model)
        {
        }
    }
}