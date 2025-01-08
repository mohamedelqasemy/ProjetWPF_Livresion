using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AppGestionEtudiant
{
    /// <summary>
    /// Logique d'interaction pour GestionEtudiantControl.xaml
    /// </summary>
    public partial class GestionEtudiantControl : UserControl
    {
        string connectionString = "Data Source=DESKTOP-PD512SN\\SQLEXPRESS; Initial Catalog=Gestion; Integrated Security=true";
        DataClasses1DataContext db;
        public ObservableCollection<Etudiant> Etudiants { get; set; }
        private Repository repository;

        public GestionEtudiantControl()
        {
            InitializeComponent();
            repository = new Repository();
            db = new DataClasses1DataContext();
            Etudiants = new ObservableCollection<Etudiant>();

            // Charger les étudiants depuis la base de données
            var etudiants = db.etudiant.Select(e => new Etudiant
            {
                Cne = e.cne,
                Nom = e.nom,
                Prenom = e.prenom,
                Sexe = e.sexe,
                DateNaissance = e.date_naiss,
                ImagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/qasemy.png"),
                //ImagePath = e.imagePath,
                Id_filiere = e.id_filiere
            }).ToList();

            foreach (var etudiant in etudiants)
            {
                Etudiants.Add(etudiant);
            }

            // Lier la collection à l'interface utilisateur
            rad_grid.ItemsSource = Etudiants;

            // Charger les filières pour le combo_box
            var filieres = repository.getFilieres();
            
            foreach (var f in filieres)
            {
                combo_box.Items.Add(f.NomFiliere);
                cbFiliere.Items.Add(f.NomFiliere);
            }
            combo_box.Items.Add("Toute les filières");
        }

        private void combo_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = combo_box.SelectedItem.ToString();
            Etudiants.Clear();

            if (string.IsNullOrWhiteSpace(selected) || selected == "Toute les filières")
            {
                var etudiants = db.etudiant.Select(et => new Etudiant
                {
                    Cne = et.cne,
                    Nom = et.nom,
                    Prenom = et.prenom,
                    Sexe = et.sexe,
                    DateNaissance = et.date_naiss,
                    ImagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/qasemy.png"),
                    //ImagePath = et.imagePath,
                    Id_filiere = et.id_filiere
                }).ToList();

                foreach (var etudiant in etudiants)
                {
                    Etudiants.Add(etudiant);
                }

                label_filiere.Content = "";
                label_respo.Content = "";
            }
            else
            {
                var filiereInfo = (from f in db.filiere
                                   where f.nom_filiere == selected
                                   select new
                                   {
                                       f.nom_filiere,
                                       f.respo_name
                                   }).SingleOrDefault();

                label_filiere.Content = filiereInfo.nom_filiere;
                label_respo.Content = filiereInfo.respo_name;

                var etudiants = (from et in db.etudiant
                                 join f in db.filiere on et.id_filiere equals f.id_filiere
                                 where f.nom_filiere == selected
                                 select new Etudiant
                                 {
                                     Cne = et.cne,
                                     Nom = et.nom,
                                     Prenom = et.prenom,
                                     Sexe = et.sexe,
                                     DateNaissance = et.date_naiss,
                                     //ImagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, et.imagePath),
                                     ImagePath = et.imagePath,
                                     Id_filiere = et.id_filiere
                                 }).ToList();

                foreach (var etudiant in etudiants)
                {
                    Etudiants.Add(etudiant);
                }
            }
        }

        private void Modifier_Etudiant(object sender, RoutedEventArgs e)
        {
            Grid_Rad.Visibility = Visibility.Collapsed;
            Grid_Filter.Visibility = Visibility.Collapsed;
            Grid_Form.Visibility = Visibility.Visible;

            modify_Form.ItemsSource = Etudiants;
        }

        private void valider_mod_Click(object sender, RoutedEventArgs e)
        {
            var etudiantModifie = modify_Form.CurrentItem as Etudiant;

            if (etudiantModifie != null)
            {
                var etudiant = db.etudiant.FirstOrDefault(ae => ae.cne == etudiantModifie.Cne);

                if (etudiant != null)
                {
                    etudiant.cne = etudiantModifie.Cne;
                    etudiant.nom = etudiantModifie.Nom;
                    etudiant.prenom = etudiantModifie.Prenom;
                    etudiant.sexe = etudiantModifie.Sexe;
                    etudiant.date_naiss = etudiantModifie.DateNaissance;
                    etudiant.imagePath = etudiantModifie.ImagePath;
                    etudiant.id_filiere = etudiantModifie.Id_filiere;

                    try
                    {
                        db.SubmitChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur lors de la sauvegarde : {ex.Message}");
                    }
                }
            }

            Grid_Form.Visibility = Visibility.Collapsed;
            Grid_Rad.Visibility = Visibility.Visible;
            Grid_Filter.Visibility = Visibility.Visible;
        }
        private void ShowAddForm_Click(object sender, RoutedEventArgs e)
        {
            AddStudentForm.Visibility = Visibility.Visible;
            Grid_Rad.Visibility = Visibility.Collapsed;
        }
        private void HideAddForm_Click(object sender, RoutedEventArgs e)
        {
            AddStudentForm.Visibility = Visibility.Collapsed;
            Grid_Rad.Visibility = Visibility.Visible;
        }

        private void AjouterEtudiant_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCne.Text) ||
                string.IsNullOrWhiteSpace(txtNom.Text) ||
                string.IsNullOrWhiteSpace(txtPrenom.Text) ||
                cbSexe.SelectedItem == null ||
                dpDateNaissance.SelectedDate == null ||
                cbFiliere.SelectedItem == null)
            {
                MessageBox.Show("Tous les champs sont obligatoires !");
                return;
            }

            try
            {
                var nouvelEtudiant = new etudiant
                {
                    cne = txtCne.Text,
                    nom = txtNom.Text,
                    prenom = txtPrenom.Text,
                    sexe = (cbSexe.SelectedItem as ComboBoxItem).Content.ToString() == "Homme" ? 'm' : 'f',
                    date_naiss = dpDateNaissance.SelectedDate.Value,
                    id_filiere = (int)db.filiere.FirstOrDefault(f => f.nom_filiere == cbFiliere.SelectedItem.ToString()).id_filiere
                };

                db.etudiant.InsertOnSubmit(nouvelEtudiant);
                db.SubmitChanges();

                Etudiants.Add(new Etudiant
                {
                    Cne = nouvelEtudiant.cne,
                    Nom = nouvelEtudiant.nom,
                    Prenom = nouvelEtudiant.prenom,
                    Sexe = nouvelEtudiant.sexe,
                    DateNaissance = nouvelEtudiant.date_naiss,
                    Id_filiere = nouvelEtudiant.id_filiere
                });

                MessageBox.Show("Étudiant ajouté avec succès !");
                HideAddForm_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}");
            }
        }

















    }
}
