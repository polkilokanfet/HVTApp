using System;
using HVTApp.Infrastructure;
using HVTApp.Model.Events;
using HVTApp.Model.POCOs;
using HVTApp.Model.Services;
using Prism.Events;
using Prism.Regions;

namespace NotificationsService
{
    internal class NotificationHelperPaymentDocumentSaved : NotificationHelper<PaymentDocument, AfterSavePaymentDocumentEvent>
    {
        public NotificationHelperPaymentDocumentSaved(IUnitOfWork unitOfWork, NotificationUnit unit, IRegionManager regionManager, IEventAggregator eventAggregator, INotificationTextService notificationTextService) : base(unitOfWork, unit, regionManager, eventAggregator, notificationTextService)
        {
        }

        public override Action GetOpenTargetEntityViewAction()
        {
            return null;
        }
    }
}