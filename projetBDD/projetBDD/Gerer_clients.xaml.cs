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
using System.Windows.Shapes;

namespace projetBDD
{
    /// <summary>
    /// Logique d'interaction pour Gerer_clients.xaml
    /// </summary>
    public partial class Gerer_clients : Window
    {
        public Gerer_clients()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void bt_retour_Click(object sender, RoutedEventArgs e)
        {
            Accueil fenetre = new Accueil();
            fenetre.Show();
            this.Hide();
        }

        private void bt_exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void bt_nvxClient_Click(object sender, RoutedEventArgs e)
        {
            Creation_client fenetre = new Creation_client();
            fenetre.Show();
            this.Hide();
        }

        private void bt_searchClient_Click(object sender, RoutedEventArgs e)
        {
            Gestion_clients c = new Gestion_clients(); //
            c.Show();
            this.Hide();
        }
    }
}