using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace AppGestionEtudiant
{
    // Classe Etudiant pour la liaison dynamique
    public class Etudiant : INotifyPropertyChanged
    {
        private string _cne;
        private string _nom;
        private string _prenom;
        private char _sexe;
        private DateTime _dateNaissance;
        private string _imagePath;
        private BitmapImage _image;
        private int _id_filiere;

        public string Cne
        {
            get => _cne;
            set
            {
                _cne = value;
                OnPropertyChanged(nameof(Cne));
            }
        }

        public string Nom
        {
            get => _nom;
            set
            {
                _nom = value;
                OnPropertyChanged(nameof(Nom));
            }
        }

        public string Prenom
        {
            get => _prenom;
            set
            {
                _prenom = value;
                OnPropertyChanged(nameof(Prenom));
            }
        }

        public char Sexe
        {
            get => _sexe;
            set
            {
                _sexe = value;
                OnPropertyChanged(nameof(Sexe));
            }
        }

        public DateTime DateNaissance
        {
            get => _dateNaissance;
            set
            {
                _dateNaissance = value;
                OnPropertyChanged(nameof(DateNaissance));
            }
        }

        public string ImagePath
        {
            get => _imagePath;
            set
            {
                _imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }

        //public BitmapImage Image
        //{
        //    get => _image;
        //    private set
        //    {
        //        _image = value;
        //        OnPropertyChanged(nameof(Image));
        //    }
        //}

        public int Id_filiere
        {
            get => _id_filiere;
            set
            {
                _id_filiere = value;
                OnPropertyChanged(nameof(Id_filiere));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

