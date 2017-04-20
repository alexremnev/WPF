using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Task_Scheduler.Models
{
    public class HighlighterDateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dateTime = value as DateTime? ?? new DateTime();
            if (dateTime.Date == DateTime.Now.Date) return Brushes.Yellow;
            return dateTime.Ticks - DateTime.Now.Ticks < 0 ? Brushes.Red : DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}