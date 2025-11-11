using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using HVTApp.Infrastructure.Converters;

namespace HVTApp.UI.PriceEngineering.Converters
{
    [ValueConversion(typeof(TaskViewModel), typeof(Visibility))]
    public class PriceEngineeringTaskPriceIncreaseFactorVisibilityConverter : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TaskViewModel viewModel &&
                viewModel.DesignDepartment?.IsPriceIncreaseFactor == true)
            {
                return Visibility.Visible;
            }

            return Visibility.Collapsed;
        }
    }
}