using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace AppGestionEtudiant
{
    public class FiliereToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string filiere)
            {
                var statControl =App.Current.MainWindow.FindName("StatistiqueControl") as StatistiqueControl;
                if (statControl != null)
                {
                    return statControl.GetFiliereColor(filiere);
                }
            }
            return new SolidColorBrush(Colors.Blue); // Couleur par défaut
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
