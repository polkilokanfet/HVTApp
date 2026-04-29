using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Attributes;
using HVTApp.Infrastructure.Extensions;
using HVTApp.Infrastructure.Services.Storage;
using HVTApp.Model.Services;
using HVTApp.Model.Services.Storage;

namespace HVTApp.Model.POCOs
{
    //то, что фиксируется в БД
    [Designation("Технико-стоимостная проработка")]
    [DesignationPlural("Технико-стоимостные проработки")]
    public partial class PriceEngineeringTask : BaseEntity, IProductBlockContainer, IBasePriorityTask, IStructureCostVersionsContainer, ISalesUnitsContainer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Designation("№"), OrderStatus(3000)]
        public int Number { get; set; }

        [Designation("Id группы"), OrderStatus(2000)]
        public virtual Guid? ParentPriceEngineeringTasksId { get; set; }


        [Designation("Бюро конструкторов"), OrderStatus(1900)]
        public virtual DesignDepartment DesignDepartment { get; set; }

        [Designation("Конструктор"), OrderStatus(1800)]
        public virtual User UserConstructor { get; set; }

        [Designation("Плановик"), OrderStatus(1700)]
        public virtual User UserPlanMaker { get; set; }

        /// <summary>
        /// Конструктор, которого назначили проверять проработку
        /// </summary>
        [Designation("Проверяющий конструктор"), OrderStatus(1750)]
        public virtual User UserConstructorInspector { get; set; }

        /// <summary>
        /// Если задача инициирована конструктором (например, для добавления площадки обслуживания выключателя)
        /// </summary>
        [Designation("Инициатор подзадачи")]
        public virtual User UserConstructorInitiator { get; set; }


        [Designation("Количество блоков продукта"), Required, OrderStatus(950)]
        public int Amount { get; set; }

        [Designation("Блок продукта от менеджера"), Required, OrderStatus(900)]
        public virtual ProductBlock ProductBlockManager { get; set; }

        [Designation("Блок продукта от инженера-конструктора"), Required, OrderStatus(850)]
        public virtual ProductBlock ProductBlockEngineer { get; set; }

        [Designation("Добавленные блоки продукта от инженера-конструктора"), OrderStatus(800)]
        public virtual List<PriceEngineeringTaskProductBlockAdded> ProductBlocksAdded { get; set; } = new List<PriceEngineeringTaskProductBlockAdded>();

        [NotMapped]
        public List<PriceEngineeringTaskProductBlockAdded> ProductBlocksAddedActual =>
            ProductBlocksAdded.Where(x => x.IsRemoved == false).ToList();


        [Designation("Файлы технических требований"), Required, OrderStatus(610)]
        public virtual List<PriceEngineeringTaskFileTechnicalRequirements> FilesTechnicalRequirements { get; set; } = new List<PriceEngineeringTaskFileTechnicalRequirements>();

        [Designation("Файлы ответов ОГК"), OrderStatus(600)]
        public virtual List<PriceEngineeringTaskFileAnswer> FilesAnswers { get; set; } = new List<PriceEngineeringTaskFileAnswer>();


        [Designation("Переписка"), OrderStatus(500)]
        public virtual List<PriceEngineeringTaskMessage> Messages { get; set; } = new List<PriceEngineeringTaskMessage>();


        [Designation("Id материнской задачи"), OrderStatus(100)]
        public virtual Guid? ParentPriceEngineeringTaskId { get; set; }

        [Designation("Дочерние задачи"), OrderStatus(90)]
        public virtual List<PriceEngineeringTask> ChildPriceEngineeringTasks { get; set; } = new List<PriceEngineeringTask>();

        [Designation("Версии SCC"), OrderStatus(80)]
        public virtual List<StructureCostVersion> StructureCostVersions { get; set; } = new List<StructureCostVersion>();


        [Designation("Строки расчётов ПЗ"), OrderStatus(80)]
        public virtual List<PriceCalculationItem> PriceCalculationItems { get; set; } = new List<PriceCalculationItem>();

        [Designation("Приоритет проработки задачи"), OrderStatus(81)]
        public virtual DateTime? TermPriority { get; set; }

        [Designation("Статусы проработки"), Required, OrderStatus(50)]
        public virtual List<PriceEngineeringTaskStatus> Statuses { get; set; } = new List<PriceEngineeringTaskStatus>();

        [Designation("SalesUnits"), OrderStatus(10)]
        public virtual List<SalesUnit> SalesUnits { get; set; } = new List<SalesUnit>();

        [Designation("Запрос на проверку от руководителя"), OrderStatus(40)]
        public bool RequestForVerificationFromHead { get; set; } = false;

        [Designation("Запрос на проверку от исполнителя"), OrderStatus(35)]
        public bool RequestForVerificationFromConstructor { get; set; } = false;

        public bool VerificationIsRequested => 
            RequestForVerificationFromConstructor || 
            RequestForVerificationFromHead;

        [Designation("ТЗ валидно для производства"), OrderStatus(36)]
        public bool IsValidForProduction { get; set; } = true;

        [Designation("Позиция в ТСЕ"), MaxLength(4)]
        public string TcePosition { get; set; }

        [Designation("Задачи на изменение номера стракчакоста блока")]
        public virtual List<UpdateStructureCostNumberTask> UpdateStructureCostNumberTasks { get; set; } = new List<UpdateStructureCostNumberTask>();
        public bool HasAnyUpdateStructureCostNumberTaskNotFinished 
            => this.UpdateStructureCostNumberTasks.Any(x => x.MomentFinish.HasValue == false);

        #region DesignDocumentationAvailability

        [Designation("Требуется разработка КД")]
        public bool NeedDesignDocumentationDevelopment { get; set; } = false;

        [Designation("Дней на разработку КД")]
        public short? DaysToDesignDocumentationDevelopment { get; set; } = 0;

        [Designation("Комментарий по разработке КД"), MaxLength(512)]
        public string DesignDocumentationAvailabilityComment { get; set; }

        [Designation("Требуется оснастка")]
        public bool NeedEquipment { get; set; } = false;

        #endregion

        [Designation("Документация загружена в TeamCenter")]
        public bool IsUploadedDocumentationToTeamCenter { get; set; }

        /// <summary>
        /// Коэффициент удорожания
        /// </summary>
        [Designation("Коэффициент удорожания")]
        public double? PriceIncreaseFactor { get; set; }

        public virtual Specification Specification { get; set; }

        ///// <summary>
        ///// Идентичные задачи (например, 3 одинаковых привода в 1 выключателе)
        ///// </summary>
        //[Designation("Идентичные задачи (например, 3 одинаковых привода в 1 выключателе)")]
        //public virtual List<PriceEngineeringTask> PriceEngineeringTasksToSplit { get; set; }

        ///// <summary>
        ///// ИД лицевой задачи по которой прорабатывается данная задача
        ///// </summary>
        //public Guid PriceEngineeringTaskToSplitFrontId { get; set; }
    }

    public partial class PriceEngineeringTask
    {
        [Designation("Статус"), NotMapped, NotForListView, NotForDetailsView]
        public ScriptStep Status
        {
            get
            {
                var status1 = Statuses.Any() ? Statuses.OrderBy(status => status.Moment).Last().StatusEnum : 0;
                return ScriptStep.FromValue(status1);
            }
        }

        /// <summary>
        /// Задача в процессе проработки конструктором
        /// </summary>
        public bool IsInProcessByConstructor 
        {
            get
            {
                if (UserConstructor == null) return false;

                var statuses = new List<ScriptStep>
                {
                    ScriptStep.Create,
                    ScriptStep.Start,
                    ScriptStep.RejectByManager,
                    ScriptStep.VerificationReject
                };

                return statuses.Contains(Status);
            }
        }

        /// <summary>
        /// Проработка задачи завершена исполнителем
        /// </summary>
        public bool IsFinishedByConstructor
        {
            get
            {
                var statuses = new List<ScriptStep>
                {
                    ScriptStep.RejectByConstructor,
                    ScriptStep.FinishByConstructor,
                    ScriptStep.VerificationRequestByConstructor,
                    ScriptStep.VerificationAccept,
                    ScriptStep.Accept,
                    ScriptStep.LoadToTceStart,
                    ScriptStep.LoadToTceFinish,
                    ScriptStep.ProductionRequestStart,
                    ScriptStep.ProductionRequestFinish,
                    ScriptStep.ProductionRequestStop, 
                    ScriptStep.ProductionRequestCancel
                };

                return statuses.Contains(Status);
            }
        }

        /// <summary>
        /// ТСП принята менеджером у ОГК
        /// </summary>
        public bool IsAccepted
        {
            get
            {
                var steps = new[]
                {
                    ScriptStep.Accept,
                    ScriptStep.LoadToTceStart,
                    ScriptStep.LoadToTceFinish,
                    ScriptStep.ProductionRequestStart,
                    ScriptStep.ProductionRequestFinish
                };

                return steps.Contains(this.Status);
            }
        }

        /// <summary>
        /// Проработка задачи принята менеджером (со всеми вложенными задачами).
        /// </summary>
        public bool IsAcceptedTotal
        {
            get
            {
                var steps = new[]
                {
                    ScriptStep.Accept,
                    ScriptStep.LoadToTceStart,
                    ScriptStep.LoadToTceFinish,
                    ScriptStep.ProductionRequestStart,
                    ScriptStep.ProductionRequestFinish
                };

                return this.StatusesAll.All(step => steps.Contains(step));
            }
        }

        /// <summary>
        /// Проработка задачи остановлена менеджером (со всеми вложенными задачами).
        /// </summary>
        public bool IsStoppedTotal => this.StatusesAll.All(step => step.Equals(ScriptStep.Stop));

        /// <summary>
        /// Статусы этой задачи и всех вложенных
        /// </summary>
        [Designation("Статусы этой задачи и всех вложенных"), NotMapped, NotForListView, NotForDetailsView]
        public IEnumerable<ScriptStep> StatusesAll
        {
            get
            {
                yield return this.Status;
                foreach (var childPriceEngineeringTask in this.ChildPriceEngineeringTasks)
                {
                    foreach (var taskStatus in childPriceEngineeringTask.StatusesAll)
                    {
                        yield return taskStatus;
                    }
                }
            }
        }

        [Designation("Старт"), NotMapped]
        public DateTime? StartMoment
        {
            get
            {
                if (IsStarted == false)
                    return default;

                return this.Statuses
                    .Where(status => status.StatusEnum == ScriptStep.Start.Value)
                    .OrderBy(status => status.Moment)
                    .Last()
                    .Moment;
            }
        }

        /// <summary>
        /// Задача была запущена на проработку и не остановлена в текущий момент
        /// </summary>
        public bool IsStarted =>
            Status.Equals(ScriptStep.Stop) == false &&
            Status.Equals(ScriptStep.Create) == false &&
            Statuses.Select(status => status.StatusEnum).Contains(ScriptStep.Start.Value);

        /// <summary>
        /// Блок продукта конкретно из этой задачи имеет версию номера SCC в TCE
        /// </summary>
        private bool HasSccNumberInTce =>
            this.StructureCostVersions.Any(structureCostVersion =>
                structureCostVersion.Version.HasValue &&
                structureCostVersion.OriginalStructureCostNumber == this.ProductBlock.StructureCostNumber &&
                structureCostVersion.PriceIncreaseFactor.Equals(this.PriceIncreaseFactor)); 


        /// <summary>
        /// Все блоки из задачи (в т.ч. включённое и дочернее оборудование) имеют SCC в TCE
        /// </summary>
        [NotMapped, NotForDetailsView, NotForListView]
        public bool AllProductBlocksHasSccNumbersInTce
        {
            get
            {
                if (this.ProductBlock.StructureCostNumberIsRequired && this.HasSccNumberInTce == false)
                    return false;

                var actualProductBlocksAdded =
                    this.ProductBlocksAdded
                        .Where(blockAdded => blockAdded.IsRemoved == false)
                        .Where(blockAdded => blockAdded.ProductBlock.StructureCostNumberIsRequired);
                if (actualProductBlocksAdded.Any(blockAdded => blockAdded.HasSccNumberInTce == false))
                    return false;

                if (this.ChildPriceEngineeringTasks.Any(task => task.AllProductBlocksHasSccNumbersInTce == false))
                    return false;

                return true;
            }
        }

        /// <summary>
        /// Задача подходит для загрузки в ТС
        /// </summary>
        /// <returns></returns>
        public bool IsSuitableForLoadInTce()
        {
            var scriptSteps = new List<ScriptStep>
            {
                ScriptStep.LoadToTceStart,
                ScriptStep.LoadToTceFinish
            };

            return GetAllPriceEngineeringTasks().All(priceEngineeringTask => scriptSteps.Contains(priceEngineeringTask.Status));
        }

        /// <summary>
        /// Задачи в которых пользователь имеет право назначить з/з
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public IEnumerable<PriceEngineeringTask> GetSuitableTasksForOpenOrder(User user)
        {
            var steps = new[]
            {
                ScriptStep.ProductionRequestStart,
                ScriptStep.ProductionRequestFinish
            };
            foreach (var priceEngineeringTask in this.GetAllPriceEngineeringTasks())
            {
                if (steps.Contains(priceEngineeringTask.Status) &&
                    priceEngineeringTask.UserPlanMaker?.Id == user.Id)
                    yield return priceEngineeringTask;
            }
        }


        /// <summary>
        /// Вернуть все задачи, которые прорабатывает данный User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public IEnumerable<PriceEngineeringTask> GetSuitableTasksForWork(User user)
        {
            if (Equals(user.Id, this.UserConstructor?.Id))
            {
                yield return this;
            }

            foreach (var childPriceEngineeringTask in ChildPriceEngineeringTasks)
            {
                foreach (var priceEngineeringTask in childPriceEngineeringTask.GetSuitableTasksForWork(user))
                {
                    yield return priceEngineeringTask;
                }
            }
        }

        /// <summary>
        /// Вернуть все задачи, которые проверяет данный User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public IEnumerable<PriceEngineeringTask> GetSuitableTasksForInspect(User user)
        {
            if (Equals(user.Id, this.UserConstructorInspector?.Id))
            {
                yield return this;
            }

            foreach (var childPriceEngineeringTask in ChildPriceEngineeringTasks)
            {
                foreach (var priceEngineeringTask in childPriceEngineeringTask.GetSuitableTasksForInspect(user))
                {
                    yield return priceEngineeringTask;
                }
            }
        }

        /// <summary>
        /// Вернуть все задачи, которые обозревает данный User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public IEnumerable<PriceEngineeringTask> GetSuitableTasksForObserve(User user)
        {
            if (this.DesignDepartment != null)
            {
                if (this.DesignDepartment.Head.Id == GlobalAppProperties.User.Id ||
                    this.DesignDepartment.Observers.ContainsById(user))
                {
                    yield return this;
                }
            }

            foreach (var childPriceEngineeringTask in ChildPriceEngineeringTasks)
            {
                foreach (var priceEngineeringTask in childPriceEngineeringTask.GetSuitableTasksForObserve(user))
                {
                    yield return priceEngineeringTask;
                }
            }
        }


        /// <summary>
        /// Вернуть все задачи, которые прорабатывает бюро пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public IEnumerable<PriceEngineeringTask> GetSuitableTasksForInstruct(User user)
        {
            if (this.DesignDepartment?.Head.Id == user.Id)
            {
                yield return this;
            }

            foreach (var childPriceEngineeringTask in ChildPriceEngineeringTasks)
            {
                foreach (var priceEngineeringTask in childPriceEngineeringTask.GetSuitableTasksForInstruct(user))
                {
                    yield return priceEngineeringTask;
                }
            }
        }

        public IEnumerable<DesignDepartment> GetDepartments()
        {
            yield return this.DesignDepartment;
            foreach (var childPriceEngineeringTask in ChildPriceEngineeringTasks)
            {
                foreach (var department in childPriceEngineeringTask.GetDepartments())
                {
                    yield return department;
                }
            }
        }

        public IEnumerable<StructureCost> GetStructureCosts(string tceNumber = null, int? salesUnitsAmount = null, IPriceService priceService = null)
        {
            var g = GetStructureCosts0(tceNumber, salesUnitsAmount, priceService).GroupBy(x => x.OriginalStructureCostProductBlock.Id);
            foreach (var grp in g)
            {
                var first = grp.First();
                var f = Fraction.Sum(grp.Select(x => new Fraction(int.Parse(x.AmountNumerator.ToString(CultureInfo.InvariantCulture)), int.Parse(x.AmountDenomerator.ToString(CultureInfo.InvariantCulture)))).ToArray());
                var result = GetNewStructureCost(first.OriginalStructureCostProductBlock, first.Number, f.Numerator, f.Denominator);
                result.PriceIncreaseFactor = first.PriceIncreaseFactor;
                yield return result;
            }
        }
        private IEnumerable<StructureCost> GetStructureCosts0(string tceNumber = null, int? salesUnitsAmount = null, IPriceService priceService = null)
        {
            salesUnitsAmount = salesUnitsAmount ?? SalesUnits.Count;

            //стракчакост основного блока
            if (this.ProductBlock.StructureCostNumberIsRequired)
            {
                var structureCostNumber = GetStructureCostNumber(this, tceNumber, priceService);
                var structureCost = GetNewStructureCost(ProductBlockEngineer, structureCostNumber, 1, 1);
                structureCost.PriceIncreaseFactor = this.PriceIncreaseFactor;
                yield return structureCost;
            }

            //стракчакосты добавленных блоков
            foreach (var blockAdded in ProductBlocksAdded.Where(productBlockAdded => productBlockAdded.IsRemoved == false))
            {
                var structureCostNumber1 = GetStructureCostNumber(blockAdded, tceNumber, priceService);
                yield return GetNewStructureCost(blockAdded.ProductBlock, structureCostNumber1, blockAdded.Amount, blockAdded.IsOnBlock ? 1 : salesUnitsAmount.Value);
            }

            //стракчакосты вложенных задач
            foreach (var childPriceEngineeringTask in ChildPriceEngineeringTasks)
            {
                foreach (var structureCost in childPriceEngineeringTask.GetStructureCosts0(tceNumber, salesUnitsAmount))
                {
                    yield return structureCost;
                }
            }
        }

        private string GetStructureCostNumber(
            IStructureCostVersionsContainer structureCostVersionsContainer, 
            string tceNumber, 
            IPriceService priceService)
        {
            if (tceNumber != null && structureCostVersionsContainer.GetStructureCostVersion() != null)
            {
                return $"{tceNumber} V{structureCostVersionsContainer.GetStructureCostVersion().Version:D2}";
            }

            if (string.IsNullOrWhiteSpace(structureCostVersionsContainer.ProductBlock.StructureCostNumber) == false)
            {
                return structureCostVersionsContainer.ProductBlock.StructureCostNumber;
            }

            if (priceService != null)
            {
                return priceService.GetAnalogWithPrice(this.ProductBlock)?.StructureCostNumber;
            }

            return "no scc";
        }

        private StructureCost GetNewStructureCost(ProductBlock productBlock, string structureCostNumber, double amountNumerator, double amountDenomenator)
        {
            return new StructureCost
            {
                Comment = productBlock.ToString().LimitLength(200),
                Number = structureCostNumber,
                OriginalStructureCostProductBlock = productBlock,
                OriginalStructureCostNumber = productBlock.StructureCostNumber,
                AmountNumerator = amountNumerator,
                AmountDenomerator = amountDenomenator
            };
        }

        /// <summary>
        /// Возвращает эту задачу и все дочерние
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PriceEngineeringTask> GetAllPriceEngineeringTasks()
        {
            yield return this;

            foreach (var childPriceEngineeringTask in ChildPriceEngineeringTasks)
            {
                foreach (var priceEngineeringTask in childPriceEngineeringTask.GetAllPriceEngineeringTasks())
                {
                    yield return priceEngineeringTask;
                }
            }
        }

        public override string ToString()
        {
            return SalesUnits.Any() 
                ? $"ТСП объектов: {SalesUnits.Select(salesUnit => salesUnit.Facility).Distinct().OrderBy(facility => facility.Name).ToStringEnum(", ")}" 
                : $"ТСП блока: {this.ProductBlock}";
        }

        [NotForListView, NotForDetailsView]
        public ProductBlock ProductBlock => this.ProductBlockEngineer;

        /// <summary>
        /// Формирует продукт из проработанных блоков
        /// </summary>
        /// <returns></returns>
        public Product GetProduct()
        {
            return new Product
            {
                ProductBlock = this.ProductBlockEngineer,
                DependentProducts = this.ChildPriceEngineeringTasks
                    .Where(task => task.UserConstructorInitiator == null)
                    .Select(task =>
                    new ProductDependent
                    {
                        Product = task.GetProduct(),
                        Amount = task.Amount
                    }).ToList()
            };
        }

        /// <summary>
        /// Сообщения + "сообщения-статусы"
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IMessage> GetMessages()
        {
            var messages = new List<IMessage>(this.Messages);
            messages.AddRange(this.Statuses.Select(PriceEngineeringTaskStatusMessage.Convert));
            return messages.OrderByDescending(message => message.Moment);
        }

        private const string NeedDesignDocumentationYes = "Требуемое время на разработку КД:";
        private const string NeedDesignDocumentationNo = "Разработка КД не требуется.";

        public string GetDesignDocumentationAvailabilityInfo()
        {
            if (this.NeedDesignDocumentationDevelopment == false) return NeedDesignDocumentationNo;
            var sb = new StringBuilder();
            sb.Append($"{NeedDesignDocumentationYes} {this.DaysToDesignDocumentationDevelopment} дн.");
            if (string.IsNullOrWhiteSpace(this.DesignDocumentationAvailabilityComment) == false)
                sb.Append($" Комментарий: {this.DesignDocumentationAvailabilityComment}");
            return sb.ToString();
        }

        public bool HasDesignDocumentationInfo
        {
            get
            {
                return this.Statuses
                    .Where(status => status.StatusEnum == ScriptStep.FinishByConstructor.Value || status.StatusEnum == ScriptStep.VerificationRequestByConstructor.Value)
                    .Where(x => x.Comment != null)
                    .Any(status => status.Comment.Contains(NeedDesignDocumentationYes) || status.Comment.Contains(NeedDesignDocumentationNo));
            }
        }

        /// <summary>
        /// Статусы свидетельствующие о том, что задача проработана ОГК
        /// </summary>
        private static readonly List<ScriptStep> StatusesFinishedByDesignDepartment = new List<ScriptStep>
        {
            ScriptStep.FinishByConstructor,
            ScriptStep.VerificationAccept,
            ScriptStep.Accept,
            ScriptStep.LoadToTceStart,
            ScriptStep.LoadToTceFinish,
            ScriptStep.ProductionRequestStart,
            ScriptStep.ProductionRequestFinish,
            ScriptStep.ProductionRequestStop
        };

        /// <summary>
        /// Проработано КБ ОГК и не остановлено менеджером
        /// </summary>
        public bool IsFinishedByDesignDepartment
        {
            get
            {
                if (Status.Value == ScriptStep.RejectByHead.Value) return true;
                if (Status.Value == ScriptStep.RejectByConstructor.Value) return true;

                return StatusesFinishedByDesignDepartment.Contains(Status) && 
                       this.Statuses.Select(status => status.StatusEnum).Contains(ScriptStep.FinishByConstructor.Value);
            }
        }

        /// <summary>
        /// Момент окончания работы КБ ОГК над этой задачей
        /// </summary>
        public DateTime? MomentFinishByDesignDepartment
        {
            get
            {
                if (IsFinishedByDesignDepartment == false) return null;
                
                return this.Statuses
                    .Where(status => 
                        status.StatusEnum == ScriptStep.FinishByConstructor.Value ||
                        status.StatusEnum == ScriptStep.VerificationAccept.Value ||
                        status.StatusEnum == ScriptStep.RejectByHead.Value ||
                        status.StatusEnum == ScriptStep.RejectByConstructor.Value)
                    .OrderBy(status => status.Moment)
                    .Last().Moment;
            }
        }

        /// <summary>
        /// Задача не имеет родительской задачи
        /// </summary>
        public bool IsTop => this.ParentPriceEngineeringTaskId.HasValue == false;

        public DateTime? GetDeadline(IUnitOfWork unitOfWork)
        {
            if (StartMoment.HasValue == false) return default;
            
            var deadline = this.GetPriceEngineeringTasks(unitOfWork).WorkUpTo;
            return StartMoment.Value < deadline 
                ? deadline 
                : StartMoment.Value.AddDays(2);
        }

        /// <summary>
        /// Возвращает сущности для копирования файлов (этой задачи)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IFileCopyInfo> GetFileCopyInfoEntities()
        {
            foreach (var fileTechnicalRequirement in this.FilesTechnicalRequirements)
            {
                yield return new FileCopyInfoTechnicalSpecification(fileTechnicalRequirement, this.GetDirectoryName());
            }

            foreach (var answer in this.FilesAnswers)
            {
                yield return new FileCopyInfoDesignDepartmentAnswer(answer, this.GetDirectoryName());
            }
        }
        /// <summary>
        /// Возвращает сущности для копирования файлов (этой задачи и вложенных)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IFileCopyInfo> GetFileCopyInfoEntitiesAll()
        {
            foreach (var task in this.GetAllPriceEngineeringTasks().ToList())
            {
                foreach (var fileTechnicalRequirement in task.FilesTechnicalRequirements)
                {
                    yield return new FileCopyInfoTechnicalSpecification(fileTechnicalRequirement, task.GetDirectoryName());
                }

                foreach (var answer in task.FilesAnswers)
                {
                    yield return new FileCopyInfoDesignDepartmentAnswer(answer, task.GetDirectoryName());
                }
            }
        }

        private string GetDirectoryName()
        {
            return $"[{this.Number:D4}] {this.ProductBlock.Designation.ReplaceUncorrectSimbols().LimitLength(15)}";
        }
    }
}