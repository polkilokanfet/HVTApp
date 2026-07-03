using System;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Enums;
using HVTApp.Infrastructure.Interfaces.Services;
using HVTApp.Model.POCOs;
using HVTApp.Model.Services;
using Prism.Events;
using Prism.Regions;

namespace NotificationsService
{
    public class NotificationGeneratorService : INotificationGeneratorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;
        private readonly INotificationTextService _notificationTextService;

        public NotificationGeneratorService(IUnitOfWork unitOfWork, IRegionManager regionManager, IEventAggregator eventAggregator, INotificationTextService notificationTextService)
        {
            _unitOfWork = unitOfWork;
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _notificationTextService = notificationTextService;
        }

        private INotificationHelper GetNotification(NotificationUnit unit)
        {
            switch (unit.ActionType)
            {
                case NotificationActionType.StartPriceCalculation:
                case NotificationActionType.CancelPriceCalculation:
                case NotificationActionType.RejectPriceCalculation:
                case NotificationActionType.FinishPriceCalculation:
                    return new NotificationHelperPriceCalculation(_unitOfWork, unit, _regionManager, _eventAggregator, _notificationTextService);

                case NotificationActionType.StartTechnicalRequirementsTask:
                case NotificationActionType.InstructTechnicalRequirementsTask:
                case NotificationActionType.RejectTechnicalRequirementsTask:
                case NotificationActionType.RejectByFrontManagerTechnicalRequirementsTask:
                case NotificationActionType.FinishTechnicalRequirementsTask:
                case NotificationActionType.AcceptTechnicalRequirementsTask:
                case NotificationActionType.StopTechnicalRequirementsTask:
                    return new NotificationHelperTechnicalRequrementsTask(_unitOfWork, unit, _regionManager, _eventAggregator, _notificationTextService);

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
                    return new NotificationHelperPriceEngineeringTask(_unitOfWork, unit, _regionManager, _eventAggregator, _notificationTextService);

                case NotificationActionType.PriceEngineeringTasksStart:
                case NotificationActionType.PriceEngineeringTasksInstructToBackManager:
                    return new NotificationHelperPriceEngineeringTasks(_unitOfWork, unit, _regionManager, _eventAggregator, _notificationTextService);

                case NotificationActionType.TaskInvoiceForPaymentStart:
                case NotificationActionType.TaskInvoiceForPaymentFinish:
                case NotificationActionType.TaskInvoiceForPaymentInstruct:
                case NotificationActionType.TaskInvoiceForPaymentStop:
                    return new NotificationHelperTaskInvoiceForPayment(_unitOfWork, unit, _regionManager, _eventAggregator, _notificationTextService);

                case NotificationActionType.PaymentDocumentSaved:
                    return new NotificationHelperPaymentDocumentSaved(_unitOfWork, unit, _regionManager, _eventAggregator, _notificationTextService);

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public string GetCommonInfo(NotificationUnit unit)
        {
            return this.GetNotification(unit).GetCommonInfo();
        }

        public string GetActionInfo(NotificationUnit unit)
        {
            return this.GetNotification(unit).GetActionInfo();
        }

        public Action GetOpenTargetEntityViewAction(NotificationUnit unit)
        {
            return this.GetNotification(unit).GetOpenTargetEntityViewAction();
        }

        public void RefreshTargetEntityAction(NotificationUnit unit)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(
                () =>
                {
                    this.GetNotification(unit).RefreshTargetEntityAction();
                });
        }
    }
}