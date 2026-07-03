using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Attributes;
using HVTApp.Infrastructure.Enums;

namespace HVTApp.Model.POCOs
{
    public class NotificationUnit : BaseEntity
    {
        public DateTime Moment { get; set; } = DateTime.Now;

        public NotificationActionType ActionType { get; set; }

        public Guid TargetEntityId { get; set; }

        #region Sender

        /// <summary>
        /// отправитель
        /// </summary>
        [Designation("Отправитель"), Required]
        public virtual User SenderUser { get; set; }

        [NotForListView]
        public Guid SenderUserId { get; set; } = GlobalAppProperties.User.Id;

        /// <summary>
        /// роль отправителя
        /// </summary>
        [Designation("Роль отправителя")]
        public Role SenderRole { get; set; } = GlobalAppProperties.User.RoleCurrent;

        #endregion

        #region Recipient

        /// <summary>
        /// Получатель
        /// </summary>
        [Designation("Получатель"), Required]
        public virtual User RecipientUser { get; set; }

        [NotForListView]
        public Guid RecipientUserId { get; set; }

        /// <summary>
        /// Роль получателя
        /// </summary>
        [Designation("Роль получателя")]
        public Role RecipientRole { get; set; }

        #endregion

        [Designation("Отправлено по почте")]
        public bool IsSentByEmail { get; set; } = false;


        public string GetActionString()
        {
            switch (this.ActionType)
            {
                #region PriceEngineeringTasks

                case NotificationActionType.PriceEngineeringTasksStart:
                    return "Запущена задача ТСП";

                case NotificationActionType.PriceEngineeringTasksInstructToBackManager:
                    return this.RecipientRole == Role.BackManager
                        ? "Загрузите результаты проработки ТСП в Team Center"
                        : "Назначен Бэкменеджер";

                #endregion

                #region PriceEngineeringTask

                case NotificationActionType.PriceEngineeringTaskStart:
                    return this.RecipientRole == Role.DesignDepartmentHead
                        ? "Назначьте исполнителя"
                        : "Проработайте задачу";

                case NotificationActionType.PriceEngineeringTaskStop:
                    return "Менеджер остановил проработку блока ТСП";

                case NotificationActionType.PriceEngineeringTaskInstructToConstructor:
                    return this.RecipientRole == Role.Constructor
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
                    return this.RecipientRole == Role.DesignDepartmentHead
                        ? "Проверьте проработку"
                        : "Блок ТСП отправлен на проверку руководителю КБ";

                case NotificationActionType.PriceEngineeringTaskVerificationRejected:
                    return this.RecipientRole == Role.Constructor
                        ? "Проработка не согласована руководителем КБ (перепроработайте)"
                        : "Проработка не согласована руководителем КБ";

                case NotificationActionType.PriceEngineeringTaskVerificationAcceptedByDesignDepartment:
                    return "Проработка согласована руководителем или проверяющим КБ";

                case NotificationActionType.PriceEngineeringTaskInstructToPlanMaker:
                    return this.RecipientRole == Role.PlanMaker
                        ? "Откройте производство"
                        : "Назначен плановик";

                case NotificationActionType.PriceEngineeringTaskLoadToTceStart:
                    return this.RecipientRole == Role.BackManager
                        ? "Загрузите результаты проработки ТСП в Team Center"
                        : "Назначьте Бэкменеджера";

                case NotificationActionType.PriceEngineeringTaskLoadToTceFinish:
                    return "Проработка загружена в Team Center";

                case NotificationActionType.PriceEngineeringTaskProductionRequestStart:
                    return this.RecipientRole == Role.BackManagerBoss
                        ? "Назначте плановика (для открытия производства)"
                        : "Отправлен запрос на открытие производства";

                case NotificationActionType.PriceEngineeringTaskProductionRequestCancel:
                    return "Запрос на открытие производства отозван";

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

                #region PaymentDocumentSaved

                case NotificationActionType.PaymentDocumentSaved:
                    return "Сохранён платёжный документ";

                #endregion


                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #region GetCommonInfo

        public string GetCommonInfo(PriceEngineeringTasks tasks, PriceEngineeringTask taskTarget, PriceEngineeringTask taskTop)
        {
            var salesUnit = taskTop.SalesUnits.FirstOrDefault();

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

        #endregion
    }

    public class NotificationUnitHasNoTargetEntityException : Exception
    {

    }
}