using HVTApp.Model.POCOs;
using HVTApp.Model.Wrapper.Base;

namespace HVTApp.UI.Modules.Settings.ViewModels
{
    public class UserSettingsWrapper : WrapperBase<User>
    {
        public UserSettingsWrapper(User model) : base(model) { }

        /// <summary>
        /// Показывать сообщения в задачах ТСП
        /// </summary>
        public bool IsPriceEngineeringTaskMessagesEnabled
        {
            get => Model.IsPriceEngineeringTaskMessagesEnabled;
            set => SetValue(value);
        }
        public bool IsPriceEngineeringTaskMessagesEnabledOriginalValue => GetOriginalValue<bool>(nameof(IsPriceEngineeringTaskMessagesEnabled));
        public bool IsPriceEngineeringTaskMessagesEnabledIsChanged => GetIsChanged(nameof(IsPriceEngineeringTaskMessagesEnabled));

    }
}