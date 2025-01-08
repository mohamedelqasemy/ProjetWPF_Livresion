using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour StatistiqueWindow.xaml
    /// </summary>
    public partial class StatistiqueWindow : Window
    {
        private Repository repository;
        public StatistiqueWindow()
        {
            InitializeComponent();
            repository = new Repository();
            LoadChartData();
        }
        public void LoadChartData()
        {
            // Obtenez les données depuis le repository
            List<modelData> data = repository.findStudentCountByFiliere();

            // Affichez les données dans la console pour vérifier leur validité
            foreach (var item in data)
            {
                Console.WriteLine($"Filière: {item.NomFiliere}, Nombre d'étudiants: {item.EtudiantCount}");
            }

            // Lier les données au DataContext pour le binding
            DataContext = new ObservableCollection<modelData>(data);
        }

        private void btnStatistique(object sender, RoutedEventArgs e)
        {

        }
        private void btnGestionEtudiant(object sender, RoutedEventArgs e)
        {
            Gestion_etudiant gestion_Etudiant = new Gestion_etudiant();
            gestion_Etudiant.Show();
            this.Close();
        }
        private void btnGestionFiliere(object sender, RoutedEventArgs e)
        {
            GestionFiliereWindow gestionFiliere = new GestionFiliereWindow();
            gestionFiliere.Show();
            this.Close();
        }
    }
}
