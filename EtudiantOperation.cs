using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace AppGestionEtudiant
{
    internal class EtudiantOperation
    {
        // Collection observable pour synchronisation automatique avec l'interface
        public static ObservableCollection<Etudiant> Etudiants { get; set; }
        private static DataClasses1DataContext db;
        private static string connectionString = "Data Source=DESKTOP-0JL7EGK\\SQLEXPRESS; Initial Catalog=Gestion; Integrated Security=true";
        public static string backgroundImagePath { get; set; }
        // Chemin d'arrière-plan
        public static string BackgroundImagePath { get; set; }

        static EtudiantOperation()
        {
            // Initialisation du chemin de l'image d'arrière-plan
            BackgroundImagePath = "D:\\4-GINFO\\.NET\\AppGestionEtudiant\\Images\\zellij3.jpg";

            // Connexion à la base de données
            db = new DataClasses1DataContext(connectionString);

            // Chargement initial des étudiants
            Etudiants = new ObservableCollection<Etudiant>(
                db.etudiant.Select(e => new Etudiant
                {
                    Cne = e.cne,
                    Nom = e.nom,
                    Prenom = e.prenom,
                    DateNaissance = e.date_naiss,
                    ImagePath = e.imagePath
                }).ToList()
            );
        }
    }
}
