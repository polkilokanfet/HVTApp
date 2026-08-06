using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using HVTApp.Model;

namespace HVTApp.UI.PriceEngineering.Converters
{
    [ValueConversion(typeof(TaskViewModel), typeof(Visibility))]
    public class PriceEngineeringTaskViewModelIsTargetTaskVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TaskViewModel priceEngineeringTaskViewModel)
            {
                if (priceEngineeringTaskViewModel.IsTarget)
                {
                    return Visibility.Visible;
                }

                if (priceEngineeringTaskViewModel.Model.UserConstructorInitiator != null &&
                    priceEngineeringTaskViewModel.Model.UserConstructorInitiator.IsAppCurrentUser())
                {
                    return Visibility.Visible;
                }
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}