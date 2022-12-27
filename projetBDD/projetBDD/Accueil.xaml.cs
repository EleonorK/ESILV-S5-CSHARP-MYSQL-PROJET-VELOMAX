using MySql.Data.MySqlClient;
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
using System.Data;

namespace projetBDD
{
    /// <summary>
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class Accueil : Window
    {
        public Accueil()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            if (Connexion() == true) { bt_notif.Background = Brushes.Red; }
            else { bt_notif.Background = Brushes.Green; }
        }
        private void bt_clients_Click(object sender, RoutedEventArgs e)
        {
            Gerer_clients fenetre = new Gerer_clients();
            fenetre.Show();
            this.Hide();
        }
        private void bt_fournisseurs_Click(object sender, RoutedEventArgs e)
        {
            Gerer_fournisseur fenetre = new Gerer_fournisseur();
            fenetre.Show();
            this.Hide();

        }
        private void bt_produits_Click(object sender, RoutedEventArgs e)
        {
            Gerer_produits fenetre = new Gerer_produits();
            fenetre.Show();
            this.Hide();

        }
        private void bt_commandes_Click(object sender, RoutedEventArgs e)
        {
            Gerer_Commande c = new Gerer_Commande();
            c.Show();
            this.Hide();

        }

        private void bt_exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void bt_notif_Click(object sender, RoutedEventArgs e)
        {
            //ouvre le tabmeau avc les elements <= 5 en stock
            StockInfo();
        }
        private void StockInfo()
        {
            if (Connexion() == true) { MessageBox.Show("Produits <= 2 en stock"); Gestion_velo n = new Gestion_velo();n.Show();this.Hide(); }
            else { MessageBox.Show("pas de produit où le stock est insuffisant"); }
        } 
        private bool Connexion()
        {
            bool verif = false;
            MySqlConnection maConnexion = null;
            string selection = "SELECT stock_piece FROM piece WHERE stock_piece <= 2";

            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                //connexion
                maConnexion = new MySqlConnection(connexionInfo);
                //ouvrir le canal de communication/connexion
                maConnexion.Open();
                MySqlCommand command2 = maConnexion.CreateCommand();
                command2.CommandText = selection;
                MySqlDataReader exeRequete = command2.ExecuteReader();
                if(exeRequete.FieldCount > 0) { verif = true; }
            }
            catch (MySqlException msg)
            {
                MessageBox.Show("Erreur de connexion : " + msg.ToString());
            }
            return verif;
        }

        private void bt_stat_Click(object sender, RoutedEventArgs e)
        {
            Statistiques fenetre = new Statistiques();
            fenetre.Show();
            this.Hide();
        }
    }
}
