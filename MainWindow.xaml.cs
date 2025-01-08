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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppGestionEtudiant
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StatistiqueControl statistiqueControl = new StatistiqueControl();
        GestionEtudiantControl etudiantControl = new GestionEtudiantControl();
        GestionFiliereControl filiereControl = new GestionFiliereControl();
        public MainWindow()
        {
            InitializeComponent();
            cntrlFrame.Content = etudiantControl;
        }
        private void btnGestionFiliere(object sender, RoutedEventArgs e)
        {
            cntrlFrame.Content = filiereControl;

        }

        private void btnGestionEtudiant(object sender, RoutedEventArgs e)
        {
            cntrlFrame.Content = etudiantControl;
        }

        private void btnStatistique(object sender, RoutedEventArgs e)
        {
            cntrlFrame.Content = statistiqueControl;

        }
    }
}
