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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace projetBDD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (mail.Text == "" && password.Password == "")
            {
                MessageBox.Show("vous n'avez rien saisi !", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (mail.Text == "" || password.Password == "")
                {
                    if (mail.Text == "")
                    {
                        MessageBox.Show("Nom invalide", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    if (password.Password == "")
                    {
                        MessageBox.Show("Mot de passe invalide", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            if (mail.Text != "" && password.Password != "")
            {
                if (mail.Text == "maxlegrand@hotmail.com" && password.Password == "max123")
                {
                    this.Hide();
                    Accueil a = new Accueil();
                    a.Show();
                }
                else
                {
                    MessageBox.Show("Pseudo ou mot de passe incorrect ", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
    }
}
