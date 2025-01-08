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
    /// Interaction logic for Gestion_etudiant.xaml
    /// </summary>
    public partial class Gestion_etudiant : Window
    {
        string connectionString = "Data Source=DESKTOP-0JL7EGK\\SQLEXPRESS; Initial Catalog=Gestion; Integrated Security=true";
        DataClasses1DataContext db;

        public Gestion_etudiant()
        {
            InitializeComponent();
            db = new DataClasses1DataContext();

            // Charger les données et inclure les chemins d'image
            var etudiants = db.etudiant.Select(e => new
            {
                e.cne,
                e.nom,
                e.prenom,
                e.date_naiss,
                imagePath = new BitmapImage(new Uri(e.imagePath, UriKind.RelativeOrAbsolute))
            }).ToList();

            // Lier les données au RadGridView
            rad_grid.ItemsSource = etudiants;

            var r = (from f in db.filiere
                     select new { 
                         f.nom_filiere
                     }).ToList();
            foreach(var i in r)
            {
                combo_box.Items.Add(i.nom_filiere);
            }
        }

        private void combo_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = combo_box.SelectedItem.ToString();
            if (selected == "Genie informatique") { 
                var r = (from f in db.filiere
                         where f.nom_filiere == selected
                         select new
                         {
                             f.nom_filiere,
                             f.respo_name
                         }).SingleOrDefault();
                label_filiere.Content = r.nom_filiere;
                label_respo.Content = r.respo_name;

                var etudiants = (from et in db.etudiant
                                 join f in db.filiere on
                                 et.id_filiere equals f.id_filiere
                                 where f.nom_filiere == selected
                                 select new {
                                     et.cne,
                                     et.nom,
                                     et.prenom,
                                     et.date_naiss,
                                     imagePath = new BitmapImage(new Uri(et.imagePath, UriKind.RelativeOrAbsolute))
                                 }).ToList();

                // Lier les données au RadGridView
                rad_grid.ItemsSource = etudiants;

            }
            else if (selected == "Genie industriel")
            {
                var r = (from f in db.filiere
                         where f.nom_filiere == selected
                         select new
                         {
                             f.nom_filiere,
                             f.respo_name
                         }).SingleOrDefault();
                label_filiere.Content = r.nom_filiere;
                label_respo.Content = r.respo_name;

                var etudiants = (from et in db.etudiant
                                 join f in db.filiere on
                                 et.id_filiere equals f.id_filiere
                                 where f.nom_filiere == selected
                                 select new
                                 {
                                     et.cne,
                                     et.nom,
                                     et.prenom,
                                     et.date_naiss,
                                     imagePath = new BitmapImage(new Uri(et.imagePath, UriKind.RelativeOrAbsolute))
                                 }).ToList();

                // Lier les données au RadGridView
                rad_grid.ItemsSource = etudiants;

            } 
            else if (selected == "Genie aeronotique")
            {
                var r = (from f in db.filiere
                         where f.nom_filiere == selected
                         select new
                         {
                             f.nom_filiere,
                             f.respo_name
                         }).SingleOrDefault();
                label_filiere.Content = r.nom_filiere;
                label_respo.Content = r.respo_name;

                var etudiants = (from et in db.etudiant
                                 join f in db.filiere on
                                 et.id_filiere equals f.id_filiere
                                 where f.nom_filiere == selected
                                 select new
                                 {
                                     et.cne,
                                     et.nom,
                                     et.prenom,
                                     et.date_naiss,
                                     imagePath = new BitmapImage(new Uri(et.imagePath, UriKind.RelativeOrAbsolute))
                                 }).ToList();

                // Lier les données au RadGridView
                rad_grid.ItemsSource = etudiants;

            }
        }
    }

}
