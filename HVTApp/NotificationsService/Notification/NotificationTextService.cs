using System;
using System.Linq;
using System.Text;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Enums;
using HVTApp.Model;
using HVTApp.Model.POCOs;
using HVTApp.Model.Services;

namespace NotificationsService
{
    public class NotificationTextService : INotificationTextService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public NotificationTextService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public string GetActionInfo(NotificationUnit notificationUnit)
        {
            switch (notificationUnit.ActionType)
            {
                #region PriceEngineeringTasks

                case NotificationActionType.PriceEngineeringTasksStart:
                    return "Запущена задача ТСП";

                case NotificationActionType.PriceEngineeringTasksInstructToBackManager:
                    return notificationUnit.RecipientRole == Role.BackManager
                        ? "Загрузите результаты проработки ТСП в Team Center"
                        : "Назначен Бэкменеджер";

                #endregion

                #region PriceEngineeringTask

                case NotificationActionType.PriceEngineeringTaskStart:
                    return notificationUnit.RecipientRole == Role.DesignDepartmentHead
                        ? "Назначьте исполнителя"
                        : "Проработайте задачу";

                case NotificationActionType.PriceEngineeringTaskStop:
                    return "Менеджер остановил проработку блока ТСП";

                case NotificationActionType.PriceEngineeringTaskInstructToConstructor:
                    return notificationUnit.RecipientRole == Role.Constructor
                        ? "Проработайте блок"
                        : "Назначен исполнитель";

                case NotificationActionType.PriceEngineeringTaskFinish:
                    return "Блок ТСП проработан";

                case NotificationActionType.PriceEngineeringTaskAccept:
                    return "Проработка блока ТСП принята менеджером";

                case NotificationActionType.PriceEngineeringTaskRejectByManager:
                    return "Проработка блока ТСП отклонена менеджером (необходима доработка)";

                case NotificationActionType.PriceEngineeringTaskRejectByHeadToManager:
                    return "Проработка блока ТСП отклонена руководителем КБ";

                case NotificationActionType.PriceEngineeringTaskRejectByConstructorToManager:
                    return "Проработка блока ТСП отклонена исполнителем";

                case NotificationActionType.PriceEngineeringTaskSendMessage:
                    return "Новое сообщение в проработке ТСП";

                case NotificationActionType.PriceEngineeringTaskFinishGoToVerification:
                    return notificationUnit.RecipientRole == Role.DesignDepartmentHead
                        ? "Проверьте проработку"
                        : "Блок ТСП отправлен на проверку руководителю КБ";

                case NotificationActionType.PriceEngineeringTaskVerificationRejected:
                    return notificationUnit.RecipientRole == Role.Constructor
                        ? "Проработка не согласована руководителем КБ или проверяющим (перепроработайте)"
                        : "Проработка не согласована руководителем КБ или проверяющим";

                case NotificationActionType.PriceEngineeringTaskVerificationAcceptedByDesignDepartment:
                    return "Проработка согласована руководителем или проверяющим КБ";

                case NotificationActionType.PriceEngineeringTaskInstructToPlanMaker:
                    return notificationUnit.RecipientRole == Role.PlanMaker
                        ? "Откройте производство"
                        : "Назначен плановик";

                case NotificationActionType.PriceEngineeringTaskLoadToTceStart:
                    return notificationUnit.RecipientRole == Role.BackManager
                        ? "Загрузите результаты проработки ТСП в Team Center"
                        : "Назначьте Бэкменеджера";

                case NotificationActionType.PriceEngineeringTaskLoadToTceFinish:
                    return "Проработка загружена в Team Center";

                case NotificationActionType.PriceEngineeringTaskProductionRequestStart:
                    return notificationUnit.RecipientRole == Role.BackManagerBoss
                        ? "Назначте плановика (для открытия производства)"
                        : "Отправлен запрос на открытие производства";

                case NotificationActionType.PriceEngineeringTaskProductionRequestCancel:
                    return "Отозван запрос на откритие производства";

                case NotificationActionType.PriceEngineeringTaskProductionRequestFinish:
                    return "Производство открыто";

                case NotificationActionType.PriceEngineeringTaskProductionRequestStop:
                    return "Заявка на остановку производства";

                case NotificationActionType.PriceEngineeringTaskProductionRequestStopConfirm:
                    return "Заявка на остановку производства согласована";

                case NotificationActionType.PriceEngineeringTaskProductionRequestStopReject:
                    return "Заявка на остановку производства отклонена";

                case NotificationActionType.PriceEngineeringTaskInstructInspector:
                    return "Поручена проверка задачи";

                #endregion

                #region PriceCalculation

                case NotificationActionType.StartPriceCalculation:
                    return "Запущен расчёт переменных затрат";
                case NotificationActionType.CancelPriceCalculation:
                    return "Остановлен расчёт переменных затрат";
                case NotificationActionType.RejectPriceCalculation:
                    return "Отклонен расчёт переменных затрат";
                case NotificationActionType.FinishPriceCalculation:
                    return "Завершен расчёт переменных затрат";

                #endregion

                #region TechnicalRequirementsTask

                case NotificationActionType.StartTechnicalRequirementsTask:
                    return "Запущена задача ТСЕ";

                case NotificationActionType.InstructTechnicalRequirementsTask:
                    return "Поручена задача ТСЕ";

                case NotificationActionType.RejectTechnicalRequirementsTask:
                    return "Отклонена задача ТСЕ";

                case NotificationActionType.RejectByFrontManagerTechnicalRequirementsTask:
                    return "Отклонена задача ТСЕ";

                case NotificationActionType.FinishTechnicalRequirementsTask:
                    return "Завершена задача ТСЕ";

                case NotificationActionType.AcceptTechnicalRequirementsTask:
                    return "Принята задача ТСЕ";

                case NotificationActionType.StopTechnicalRequirementsTask:
                    return "Остановлена задача ТСЕ";

                #endregion

                #region TaskInvoiceForPayment

                case NotificationActionType.TaskInvoiceForPaymentStart:
                    return "Запущена задача на формирование счёта";
                case NotificationActionType.TaskInvoiceForPaymentFinish:
                    return "Завершена задача на формирование счёта";
                case NotificationActionType.TaskInvoiceForPaymentInstruct:
                    return "Поручена задача на формирование счёта";
                case NotificationActionType.TaskInvoiceForPaymentStop:
                    return "Остановлена задача на формирование счёта";

                #endregion

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public string GetCommonInfo(NotificationUnit notificationUnit)
        {
            switch (notificationUnit.ActionType)
            {
                #region PriceEngineeringTasks

                case NotificationActionType.PriceEngineeringTasksStart:
                case NotificationActionType.PriceEngineeringTasksInstructToBackManager:
                {
                    using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork())
                    {
                        var targetEntity = unitOfWork.Repository<PriceEngineeringTasks>().GetById(notificationUnit.TargetEntityId);
                        return this.GetCommonInfo(targetEntity);
                    }
                }

                #endregion

                #region PriceEngineeringTask

                case NotificationActionType.PriceEngineeringTaskStart:
                case NotificationActionType.PriceEngineeringTaskStop:
                case NotificationActionType.PriceEngineeringTaskInstructToConstructor:
                case NotificationActionType.PriceEngineeringTaskFinish:
                case NotificationActionType.PriceEngineeringTaskAccept:
                case NotificationActionType.PriceEngineeringTaskRejectByManager:
                case NotificationActionType.PriceEngineeringTaskRejectByHeadToManager:
                case NotificationActionType.PriceEngineeringTaskRejectByConstructorToManager:
                case NotificationActionType.PriceEngineeringTaskSendMessage:
                case NotificationActionType.PriceEngineeringTaskFinishGoToVerification:
                case NotificationActionType.PriceEngineeringTaskVerificationRejected:
                case NotificationActionType.PriceEngineeringTaskVerificationAcceptedByDesignDepartment:
                case NotificationActionType.PriceEngineeringTaskInstructToPlanMaker:
                case NotificationActionType.PriceEngineeringTaskLoadToTceStart:
                case NotificationActionType.PriceEngineeringTaskLoadToTceFinish:
                case NotificationActionType.PriceEngineeringTaskProductionRequestStart:
                case NotificationActionType.PriceEngineeringTaskProductionRequestCancel:
                case NotificationActionType.PriceEngineeringTaskProductionRequestFinish:
                case NotificationActionType.PriceEngineeringTaskProductionRequestStop:
                case NotificationActionType.PriceEngineeringTaskProductionRequestStopConfirm:
                case NotificationActionType.PriceEngineeringTaskProductionRequestStopReject:
                case NotificationActionType.PriceEngineeringTaskInstructInspector:
                {
                    using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork())
                    {
                        var priceEngineeringTaskTarget = unitOfWork.Repository<PriceEngineeringTask>().GetById(notificationUnit.TargetEntityId);
                        if (priceEngineeringTaskTarget == null)
                            throw new NotificationUnitHasNoTargetEntityException();

                        var priceEngineeringTaskTop = priceEngineeringTaskTarget.GetTopPriceEngineeringTask(unitOfWork);
                        var priceEngineeringTasks = priceEngineeringTaskTarget.GetPriceEngineeringTasks(unitOfWork);

                        return this.GetCommonInfo(
                            priceEngineeringTasks,
                            priceEngineeringTaskTarget,
                            priceEngineeringTaskTop);
                    }
                }

                #endregion

                #region PriceCalculation

                case NotificationActionType.StartPriceCalculation:
                case NotificationActionType.CancelPriceCalculation:
                case NotificationActionType.RejectPriceCalculation:
                case NotificationActionType.FinishPriceCalculation:
                {
                    using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork())
                    {
                        var targetEntity = unitOfWork.Repository<PriceCalculation>().GetById(notificationUnit.TargetEntityId);
                        return this.GetCommonInfo(targetEntity);
                    }
                }

                #endregion

                #region TechnicalRequirementsTask

                case NotificationActionType.StartTechnicalRequirementsTask:
                case NotificationActionType.InstructTechnicalRequirementsTask:
                case NotificationActionType.RejectTechnicalRequirementsTask:
                case NotificationActionType.RejectByFrontManagerTechnicalRequirementsTask:
                case NotificationActionType.FinishTechnicalRequirementsTask:
                case NotificationActionType.AcceptTechnicalRequirementsTask:
                case NotificationActionType.StopTechnicalRequirementsTask:
                {
                    using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork())
                    {
                        var targetEntity = unitOfWork.Repository<TechnicalRequrementsTask>().GetById(notificationUnit.TargetEntityId);
                        return this.GetCommonInfo(targetEntity);
                    }
                }

                #endregion

                #region TaskInvoiceForPayment

                case NotificationActionType.TaskInvoiceForPaymentStart:
                case NotificationActionType.TaskInvoiceForPaymentFinish:
                case NotificationActionType.TaskInvoiceForPaymentInstruct:
                case NotificationActionType.TaskInvoiceForPaymentStop:
                {
                    using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork())
                    {
                        var targetEntity = unitOfWork.Repository<TaskInvoiceForPayment>().GetById(notificationUnit.TargetEntityId);
                        return this.GetCommonInfo(targetEntity);
                    }
                }

                #endregion

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private string GetCommonInfo(PriceEngineeringTasks tasks)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Номер сборки в УП ВВА: {tasks.NumberFull}");
            sb.AppendLine($"Номер задачи в УП ВВА: {tasks.Number}");
            sb.AppendLine($"Номер задачи в Team Center: {tasks.TceNumber}");
            sb.AppendLine(string.Empty);

            sb.AppendLine($"Менеджер: {tasks.UserManager}");
            sb.AppendLine($"Back-менеджер: {tasks.BackManager}");

            return sb.ToString();
        }

        private string GetCommonInfo(PriceEngineeringTasks tasks, PriceEngineeringTask taskTarget, PriceEngineeringTask taskTop)
        {
            SalesUnit salesUnit = taskTop.SalesUnits.FirstOrDefault();

            var sb = new StringBuilder();
            sb.AppendLine($"Номер сборки в УП ВВА: {tasks.NumberFull}");
            sb.AppendLine($"Номер задачи в УП ВВА: {taskTarget.Number}");
            sb.AppendLine($"Номер задачи в Team Center: {tasks.TceNumber}");
            sb.AppendLine(string.Empty);

            sb.AppendLine($"Проект: {salesUnit?.Project}");
            sb.AppendLine($"Объект: {salesUnit?.Facility}");
            sb.AppendLine($"Оборудование: {taskTop.ProductBlock};");
            sb.AppendLine($"Блок оборудования: {taskTarget.ProductBlock}");
            sb.AppendLine(string.Empty);

            sb.AppendLine($"Бюро ОГК: {taskTarget.DesignDepartment}");
            sb.AppendLine($"Исполнитель (от ОГК): {taskTarget.UserConstructor}");
            sb.AppendLine($"Менеджер: {tasks.UserManager}");
            sb.AppendLine($"Back-менеджер: {tasks.BackManager}");

            return sb.ToString();
        }

        private string GetCommonInfo(TechnicalRequrementsTask task)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Задача ТСЕ");
            sb.AppendLine("Оборудование:");
            foreach (var requirements in task.Requrements.Where(technicalRequirements => technicalRequirements.SalesUnits.Any()))
            {
                var salesUnit = requirements.SalesUnits.First();
                sb.AppendLine($" - Объект: {salesUnit.Facility}; Оборудование: {salesUnit.Product}; Количество: {requirements.SalesUnits.Count}");
            }
            return sb.ToString();
        }

        private string GetCommonInfo(PriceCalculation priceCalculation)
        {
            if (priceCalculation == null)
                return "Расчёт не найден в базе данных";

            var sb = new StringBuilder();
            sb.AppendLine("Расчёт переменных затрат");
            sb.AppendLine("Оборудование:");
            
            foreach (var priceCalculationItem in priceCalculation.PriceCalculationItems.Where(item => item.SalesUnits.Any()))
            {
                var salesUnit = priceCalculationItem.SalesUnits.First();
                sb.AppendLine($" - Объект: {salesUnit.Facility}; Оборудование: {salesUnit.Product}; Количество: {priceCalculationItem.SalesUnits.Count}");
            }
            return sb.ToString();
        }


        private string GetCommonInfo(TaskInvoiceForPayment taskInvoiceForPayment)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Задача на формирование счёта");
            sb.AppendLine("Строки счёта:");
            foreach (var item in taskInvoiceForPayment.Items)
            {
                var salesUnit = item.SalesUnits.First();
                sb.AppendLine($" - Объект: {salesUnit.Facility}; Оборудование: {salesUnit.Product}; Количество: {item.SalesUnits.Count()}");
            }
            return sb.ToString();
        }

    }
}