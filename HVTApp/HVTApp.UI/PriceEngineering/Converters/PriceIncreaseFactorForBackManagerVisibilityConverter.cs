using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using HVTApp.Infrastructure.Converters;
using HVTApp.UI.PriceEngineering.Tce.Second;

namespace HVTApp.UI.PriceEngineering.Converters
{
    [ValueConversion(typeof(SccVersionWrapper), typeof(Visibility))]
    public class PriceIncreaseFactorForBackManagerVisibilityConverter : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SccVersionWrapper sccVersion &&
                sccVersion.PriceIncreaseFactor.HasValue)
            {
                return Visibility.Visible;
            }

            return Visibility.Collapsed;
        }
    }
}