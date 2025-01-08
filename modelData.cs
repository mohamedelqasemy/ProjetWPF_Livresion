using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AppGestionEtudiant
{
    public class modelData
    {
        public string NomFiliere { get; set; }
        public int EtudiantCount { get; set; }
        public Brush SegmentBrush {  get; set; }    

        public modelData() { }

        public modelData(string nomFiliere, int etudiantCount)
        {
            NomFiliere = nomFiliere;
            EtudiantCount = etudiantCount;
            SegmentBrush = new SolidColorBrush(Color.FromRgb(52, 152, 219));
        }
    }
}
