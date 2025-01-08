using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        string connectionString = "Data Source=DESKTOP-PD512SN\\SQLEXPRESS; Initial Catalog=Gestion; Integrated Security=true";
        public Login()
        {
            InitializeComponent();
        }

       public void Man()
        {
            
            DataClasses1DataContext context = new DataClasses1DataContext();

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

            errorPanel.Visibility = Visibility.Visible;
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
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (Login_function(username, password))
            {
                errorPanel.Visibility = Visibility.Collapsed;
                //MainWindow mainWindow = new MainWindow();
                //mainWindow.Show();

                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();
                this.Close();
            }
            else
            {
                errorPanel.Visibility = Visibility.Visible;
            }
        }
        public bool Login_function(string username, string password)
        {
            // Hacher le mot de passe entré
            string hashedPassword = HashPassword(password);

            using (var context = new DataClasses1DataContext())
            {
                var user = context.users.SingleOrDefault(u => u.username == username && u.password == hashedPassword);

                if (user != null)
                {
                    return true; 
                }
                else
                {
                    return false; // Connexion échouée
                }
            }
        }

        
    }
}
