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
    /// Logique d'interaction pour GestionFiliereWindow.xaml
    /// </summary>
    public partial class GestionFiliereWindow : Window
    {
        private Repository repository;
        private ObservableCollection<FilieremodelData> filiers;
        public GestionFiliereWindow()
        {
            InitializeComponent();
            repository = new Repository();

            loaddata();
        }

        public void loaddata()
        {
            // Obtenez les données depuis le repository
            List<FilieremodelData> data = repository.getFilieres();
            filiers = new ObservableCollection<FilieremodelData>(data);
            DataContext = filiers;

        }

        private void Carousel_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            if (carousel.SelectedItem is FilieremodelData selectedItem)
            {
                id.Text = selectedItem.IdFiliere.ToString();
                fil.Text = selectedItem.NomFiliere.ToString();
                resp.Text = selectedItem.RespoFiliere.ToString();

                //MessageBox.Show($"Selected Item: {selectedItem.IdFiliere} - {selectedItem.NomFiliere}");
            }
        }

        private void AjouterBtn(object sender, RoutedEventArgs e)
        {
            int id_fil = Convert.ToInt32(id.Text);
            string nom_fil = fil.Text;
            string resp_fil = resp.Text;
            if (id_fil != null && nom_fil != null && resp_fil != null)
            {
                repository.addFiliere(id_fil, nom_fil, resp_fil);
                filiers.Add(new FilieremodelData
                {
                    IdFiliere = id_fil,
                    NomFiliere = nom_fil,
                    RespoFiliere = resp_fil
                });
            }
        }

        private void ModifierBtn(object sender, RoutedEventArgs e)
        {
            if (carousel.SelectedItem is FilieremodelData selectedItem)
            {
                string nom_fil = fil.Text;
                string resp_fil = resp.Text;
                int id_fil = Convert.ToInt32(id.Text);
                if (id_fil != null && nom_fil != null && resp_fil != null)
                {
                    repository.modifierFiliere(selectedItem.IdFiliere, id_fil, nom_fil, resp_fil);

                    //appliquer les modif 3la observallist :
                    var itemToUpdate = filiers.FirstOrDefault(f => f.IdFiliere == selectedItem.IdFiliere);
                    if (itemToUpdate != null)
                    {
                        itemToUpdate.IdFiliere = id_fil;
                        itemToUpdate.NomFiliere = nom_fil;
                        itemToUpdate.RespoFiliere = resp_fil;
                        var index = filiers.IndexOf(itemToUpdate);
                        filiers[index] = itemToUpdate;

                    }
                }
            }
        }

        private void SupprimerBtn(object sender, RoutedEventArgs e)
        {
            if (carousel.SelectedItem is FilieremodelData selectedItem)
            {
                int id_fil = Convert.ToInt32(id.Text);
                if (id_fil != 0)
                {
                    repository.deleteFiliere(id_fil);
                    //appliquer les modif  de suppression 3la observallist :
                    var itemToRemove = filiers.FirstOrDefault(f => f.IdFiliere == id_fil);
                    if (itemToRemove != null)
                    {
                        filiers.Remove(itemToRemove);
                    }

                }

            }
        }
    }
}
