using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionEtudiant
{
    class Program
    {
        static void Ma(string[] args)
        {
            string connectionString = "Data Source=DESKTOP-PD512SN\\SQLEXPRESS;Initial Catalog=Gestion;Integrated Security=True";
            DataClasses1DataContext context = new DataClasses1DataContext(connectionString);

            // Créer deux utilisateurs manuellement
            users user1 = new users
            {

                username = "user1",
                password = HashPassword("1234")  // Hacher le mot de passe
            };

            users user2 = new users
            {
                username = "user2",
                password = HashPassword("4321")  // Hacher le mot de passe
            };
            context.users.InsertOnSubmit(user1);
            context.users.InsertOnSubmit(user2);

            context.SubmitChanges();

            Console.WriteLine("Utilisateurs ajoutés avec des mots de passe hachés.");
        }
   
        public static string HashPassword(string password)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            // Convertit le mot de passe en bytes et effectue le hachage
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Convertit les bytes en une chaîne hexadécimale
            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }

            return builder.ToString();
        }
    }

}

}

