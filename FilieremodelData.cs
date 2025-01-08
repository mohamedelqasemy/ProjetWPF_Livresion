using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionEtudiant
{
    public class FilieremodelData : INotifyPropertyChanged
    {
        private string _nomFiliere;
        public string NomFiliere
        {
            get
            {
                return _nomFiliere;
            }
            set
            {
                _nomFiliere = value;
                OnPropertyChanged("NomFiliere");
            } 
        }
        private string _respoFiliere;
        public string RespoFiliere
        {
            get
            {
                return _respoFiliere;
            }
            set
            {
                _respoFiliere = value;
                OnPropertyChanged("RespoFiliere");
            }
        }
        private int _idFiliere;
        public int IdFiliere
        {
            get
            {
                return _idFiliere;
            }
            set 
            {
                _idFiliere = value;
                OnPropertyChanged("IdFiliere");
            } 
        }

        public FilieremodelData() { }

        public FilieremodelData(string nomFiliere, int idFiliere, string respoFiliere)
        {
            RespoFiliere = respoFiliere;
            NomFiliere = nomFiliere;
            IdFiliere = idFiliere;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
