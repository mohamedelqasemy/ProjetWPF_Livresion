using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppGestionEtudiant
{
    internal class Repository
    {
        private DataClasses1DataContext dataContext;
        string connectionString = "Data Source=DESKTOP-0JL7EGK\\SQLEXPRESS; Initial Catalog=Gestion; Integrated Security=true";

        public Repository()
        {
            dataContext = new DataClasses1DataContext();
        }


        public List<modelData> findStudentCountByFiliere()
        {
            var result = from f in dataContext.filiere
                         join e in dataContext.etudiant on f.id_filiere equals e.id_filiere
                         group e by f.nom_filiere into grouped
                         select new modelData
                         {
                             NomFiliere = grouped.Key,
                             EtudiantCount = grouped.Count()
                         };

            return result.ToList();
        }

        public List<FilieremodelData> getFilieres()
        {
            var result = from f in dataContext.filiere
                         select new FilieremodelData
                         {
                             IdFiliere = f.id_filiere,
                             NomFiliere = f.nom_filiere,
                             RespoFiliere = f.respo_name
                         };

            return result.ToList();
        }

        public void addFiliere(int id,string nom, string respo)
        {
            filiere f = new filiere();
            f.id_filiere = id;
            f.nom_filiere = nom;
            f.respo_name = respo;
            dataContext.filiere.InsertOnSubmit(f);
            dataContext.SubmitChanges();
        }
        public void modifierFiliere(int id, int newid, string nom, string respo)
        {
            var result = (from f in dataContext.filiere
                         where f.id_filiere == id
                         select f).SingleOrDefault();
            //MessageBox.Show(result.RespoFiliere);
            result.id_filiere = newid;
            result.nom_filiere = nom;
            result.respo_name = respo;
            dataContext.SubmitChanges();
            
        }
        public void deleteFiliere(int id)
        {
            var result = (from f in dataContext.filiere
                          where f.id_filiere == id
                          select f).SingleOrDefault();
            dataContext.filiere.DeleteOnSubmit(result);
            dataContext.SubmitChanges();

        }


    }
}
