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
    /// Logique d'interaction pour Statistiques.xaml
    /// </summary>
    public partial class Statistiques : Window
    {
        public Statistiques()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void bt_bestClients_Click(object sender, RoutedEventArgs e)
        {
            Meilleurs_Clients fenetre = new Meilleurs_Clients();
            fenetre.Show();
            this.Hide();
        }

        private void bt_exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void bt_qteVendues_Click(object sender, RoutedEventArgs e)
        {
            Qte_vendues fenetre = new Qte_vendues();
            fenetre.Show();
            this.Hide();
        }

        private void bt_fidelio_Click(object sender, RoutedEventArgs e)
        {
            ClientAdhesion f = new ClientAdhesion();
            f.Show();
            this.Hide();
        }

        private void bt_commandes_Click(object sender, RoutedEventArgs e)
        {
            Analyse_commandes fenetre = new Analyse_commandes();
            fenetre.Show();
            this.Hide();
        }

        private void bt_retour_Click(object sender, RoutedEventArgs e)
        {
            Accueil a = new Accueil();
            a.Show();
            this.Hide();
        }
    }
}
