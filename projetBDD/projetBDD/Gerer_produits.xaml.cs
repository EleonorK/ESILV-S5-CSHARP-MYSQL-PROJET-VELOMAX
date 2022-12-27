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
    /// Logique d'interaction pour Gerer_produits.xaml
    /// </summary>
    public partial class Gerer_produits : Window
    {
        public Gerer_produits()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void bt_nvxProduits_Click(object sender, RoutedEventArgs e)
        {
            creation_produit fenetre = new creation_produit();
            fenetre.Show();
            this.Hide();
        }

        private void bt_exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void bt_retour_Click(object sender, RoutedEventArgs e)
        {
            Accueil fenetre = new Accueil();
            fenetre.Show();
            this.Hide();
        }

        private void bt_mdifVelo_Click(object sender, RoutedEventArgs e)
        {
            Gestion_velo g = new Gestion_velo();
            g.Show();
            this.Hide();
        }

        private void bt_modifPiece_Click(object sender, RoutedEventArgs e)
        {
            Gestion_piece p = new Gestion_piece();
            p.Show();
            this.Hide();
        }
    }
}
