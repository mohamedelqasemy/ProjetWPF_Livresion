using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppGestionEtudiant
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window

    {
        StatistiqueControl statistiqueControl = new StatistiqueControl();
        GestionEtudiantControl etudiantControl = new GestionEtudiantControl();
        GestionFiliereControl filiereControl = new GestionFiliereControl();
        WelcomeControl welcomeControl = new WelcomeControl();
        public MainMenu()
        {
            InitializeComponent();
            TransitionControl.Content = welcomeControl;
        }
        private void NavigationView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (navigationView.SelectedItem is Telerik.Windows.Controls.RadNavigationViewItem selectedItem)
            {
                switch (selectedItem.Content.ToString())
                {
                    case "Gestion Etudiant":
                        TransitionControl.Content = etudiantControl;
                        break;

                    case "Gestion Filiere":
                        TransitionControl.Content = filiereControl;
                        break;

                    case "Statistiques":
                        TransitionControl.Content = statistiqueControl;
                        break;

                    default:
                        TransitionControl.Content = new TextBlock { Text = "Default Content", Foreground = new SolidColorBrush(Colors.Black), Margin = new Thickness(5) };
                        break;
                }
            }
        }
    }
}
