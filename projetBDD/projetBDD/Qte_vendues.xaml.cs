using System;
using System.Collections.Generic;
using System.Data;
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
using MySql.Data.MySqlClient;

namespace projetBDD
{
    /// <summary>
    /// Logique d'interaction pour Qte_vendues.xaml
    /// </summary>
    public partial class Qte_vendues : Window
    {
        public Qte_vendues()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            QtePiece();
            QteVelo();
        }
        private void QteVelo()
        {
            MySqlConnection maConnexion = null;

            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                maConnexion = new MySqlConnection(connexionInfo);
                string query = "SELECT nom_velo, SUM(qte_velo) FROM velo V1, vente_velo V2 WHERE V1.id_velo = V2.id_velo GROUP BY nom_velo;";
                maConnexion.Open();
                MySqlCommand cmd = maConnexion.CreateCommand();
                cmd.CommandText = query;
                MySqlDataReader exeRequete = cmd.ExecuteReader();
                exeRequete.Close();
                maConnexion.Close();
                AfficheGrille(dt_velo, query);
                dt_velo.IsReadOnly = true;
            }
            catch (MySqlException msg)
            {
                MessageBox.Show("Erreur de connexion : " + msg.ToString());
                //return;
            }
        }
        private void QtePiece()
        {
            MySqlConnection maConnexion = null;

            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                maConnexion = new MySqlConnection(connexionInfo);
                string query = "SELECT nom_piece, SUM(qte_piece) FROM piece P, vente_piece V WHERE V.id_piece = P.id_piece GROUP BY nom_piece;";
                maConnexion.Open();
                MySqlCommand cmd = maConnexion.CreateCommand();
                cmd.CommandText = query;
                MySqlDataReader exeRequete = cmd.ExecuteReader();
                exeRequete.Close();
                maConnexion.Close();
                AfficheGrille(dt_piece, query);
                dt_piece.IsReadOnly = true;
            }
            catch (MySqlException msg)
            {
                MessageBox.Show("Erreur de connexion : " + msg.ToString());
                //return;
            }
        }
        static void AfficheGrille(DataGrid dg, string requete)
        {
            DataTable myDT;
            myDT = new DataTable();


            MySqlConnection maConnexion = null;
            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                //connexion
                maConnexion = new MySqlConnection(connexionInfo);

                //ouvrir le canal de communication/connexion
                maConnexion.Open();

                MySqlDataAdapter sqlDa = new MySqlDataAdapter(requete, maConnexion);
                sqlDa.SelectCommand.CommandType = CommandType.Text;
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dg.ItemsSource = dtbl.DefaultView;
            }
            catch (MySqlException msg)
            {
                Console.WriteLine("Erreur de connexion : " + msg.ToString());
                return;
            }
            finally
            {
                maConnexion.Close();
            }
        }

        private void bt_exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void bt_retour_Click(object sender, RoutedEventArgs e)
        {
            Statistiques fenetre = new Statistiques();
            fenetre.Show();
            this.Hide();
        }
    }
}
