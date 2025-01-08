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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppGestionEtudiant
{
    /// <summary>
    /// Logique d'interaction pour StatistiqueControl.xaml
    /// </summary>
    public partial class StatistiqueControl : UserControl
    {
        private Repository repository;
        public SolidColorBrush Brush { get; set; }
        public StatistiqueControl()
        {
            InitializeComponent();
            repository = new Repository();
            LoadChartData();
        }
        //public void LoadChartData()
        //{
        //    // Obtenez les données depuis le repository
        //    List<modelData> data = repository.findStudentCountByFiliere();

        //    // Affichez les données dans la console pour vérifier leur validité
        //    foreach (var item in data)
        //    {
        //        Console.WriteLine($"Filière: {item.NomFiliere}, Nombre d'étudiants: {item.EtudiantCount}");
        //    }

        //    // Lier les données au DataContext pour le binding
        //    DataContext = new ObservableCollection<modelData>(data);
        //}

        public ObservableCollection<modelData> ChartData { get; set; }

        public void LoadChartData()
        {
            List<modelData> data = repository.findStudentCountByFiliere();
            ChartData = new ObservableCollection<modelData>(data);

            // Définir les couleurs dynamiques
            AssignColors();
            // Mettre à jour le DataContext pour les graphiques.
            DataContext = this;
        }
        private void AssignColors()
        {
            var colorMapping = new Dictionary<string, Brush>
            {
                { "GATE", new SolidColorBrush(Color.FromRgb(52, 152, 219)) }, // Bleu
                { "GPMA", new SolidColorBrush(Color.FromRgb(46, 204, 113)) }, // Vert
                { "GIDIAA", new SolidColorBrush(Color.FromRgb(241, 196, 15)) }, // Jaune
                { "GINFO", new SolidColorBrush(Color.FromRgb(231, 76, 60)) },   // Rouge
                { "INDUS", new SolidColorBrush(Color.FromRgb(255, 192, 203)) }, // Jaune
            };

            foreach (var item in ChartData)
            {
                if (colorMapping.TryGetValue(item.NomFiliere, out Brush brush))
                {
                    item.SegmentBrush = brush;
                }
                else
                {
                    item.SegmentBrush = new SolidColorBrush(Colors.Gray); // Couleur par défaut
                }
            }
        }

        public object GetFiliereColor(string filiere)
        {
            var colorMapping = new Dictionary<string, Brush>
            {
                { "GATE", new SolidColorBrush(Color.FromRgb(52, 152, 219)) }, // Bleu
                { "GPMA", new SolidColorBrush(Color.FromRgb(46, 204, 113)) }, // Vert
                { "GIDIAA", new SolidColorBrush(Color.FromRgb(241, 196, 15)) }, // Jaune
                { "GINFO", new SolidColorBrush(Color.FromRgb(231, 76, 60)) }   // Rouge
            };
            return colorMapping[filiere];
        }
    }

}