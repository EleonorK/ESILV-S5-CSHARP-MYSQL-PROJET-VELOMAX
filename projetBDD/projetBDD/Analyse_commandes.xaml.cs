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
using MySql.Data.MySqlClient;
namespace projetBDD
{
    /// <summary>
    /// Logique d'interaction pour Analyse_commandes.xaml
    /// </summary>
    public partial class Analyse_commandes : Window
    {
        public Analyse_commandes()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            double moyCommande = MoyenneCommandes();
            double moyPiece = MoyennePiece();
            double moyVelo = MoyenneVelo();
            lb_moyCumul.Content = "La moyenne des commandes est de : " + Math.Round(moyCommande,2) + " €";
            lb_moyPiece.Content = "La quantité moyenne de pièce vendue est de : " + Math.Round(moyPiece,2) + " pièces";
            lb_moyVelo.Content = "La quantité moyenne de vélo vendu est de : " + Math.Round(moyVelo,2) + " vélos";
        }
        private double MoyenneCommandes()
        {
            MySqlConnection maConnexion = null;
            string tableau = "";
            string ligne = "";
            double id = 0;
            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                maConnexion = new MySqlConnection(connexionInfo);
                string query = "SELECT AVG(prix_commande) FROM commande ";
                maConnexion.Open();
                MySqlCommand cmd = maConnexion.CreateCommand();
                cmd.CommandText = query;
                MySqlDataReader exeRequete = cmd.ExecuteReader();
                while (exeRequete.Read())
                {
                    for (int i = 0; i < exeRequete.FieldCount; i++)
                    {
                        ligne = ligne + " \t" + exeRequete.GetValue(i).ToString();
                    }
                    tableau = tableau + "\n " + ligne;
                }
                exeRequete.Close();
                tableau = tableau.Replace("\n", "");
                tableau = tableau.Replace("\t", "");
                tableau = tableau.Replace(" ", "");
                tableau = tableau.Replace("€", "");
                id = Convert.ToDouble(tableau);
                maConnexion.Close();
            }
            catch (MySqlException msg)
            {
                MessageBox.Show("Erreur de connexion : " + msg.ToString());
                //return;
            }
            return id;
        }
        private double MoyennePiece()
        {
            MySqlConnection maConnexion = null;
            string tableau = "";
            string ligne = "";
            double moyPiece = 0;
            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                maConnexion = new MySqlConnection(connexionInfo);
                string query = "SELECT AVG(qte_piece) FROM vente_piece ";
                maConnexion.Open();
                MySqlCommand cmd = maConnexion.CreateCommand();
                cmd.CommandText = query;
                MySqlDataReader exeRequete = cmd.ExecuteReader();
                while (exeRequete.Read())
                {
                    for (int i = 0; i < exeRequete.FieldCount; i++)
                    {
                        ligne = ligne + " \t" + exeRequete.GetValue(i).ToString();
                    }
                    tableau = tableau + "\n " + ligne;
                }
                exeRequete.Close();
                tableau = tableau.Replace("\n", "");
                tableau = tableau.Replace("\t", "");
                tableau = tableau.Replace(" ", "");
                moyPiece = Convert.ToDouble(tableau);
                maConnexion.Close();
                //moyPiece = Calculs(tableau);
            }
            catch (MySqlException msg)
            {
                MessageBox.Show("Erreur de connexion : " + msg.ToString());
                //return;
            }
            return moyPiece;
        }
        private double MoyenneVelo()
        {
            MySqlConnection maConnexion = null;
            string tableau = "";
            string ligne = "";
            double moyVelo = 0;
            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                maConnexion = new MySqlConnection(connexionInfo);
                string query = "SELECT AVG(qte_velo) FROM vente_velo";
                maConnexion.Open();
                MySqlCommand cmd = maConnexion.CreateCommand();
                cmd.CommandText = query;
                MySqlDataReader exeRequete = cmd.ExecuteReader();
                while (exeRequete.Read())
                {
                    for (int i = 0; i < exeRequete.FieldCount; i++)
                    {
                        ligne = ligne + " \t" + exeRequete.GetValue(i).ToString();
                    }
                    tableau = tableau + "\n " + ligne;
                }
                exeRequete.Close();
                maConnexion.Close();
                if(tableau != " ")
                {
                    tableau = tableau.Replace("\n", "");
                    tableau = tableau.Replace("\t", "");
                    tableau = tableau.Replace(" ", "");
                    moyVelo = Convert.ToDouble(tableau);
                }
            }
            catch (MySqlException msg)
            {
                MessageBox.Show("Erreur de connexion : " + msg.ToString());
                //return;
            }
            return moyVelo;
        }
        private int Calculs(string qte)
        {
            MessageBox.Show(qte);
            int res = 0;
            string[] temp = qte.Split("\n");
            for (int i = 0; i <= temp.Length; i++)
            {
                res += Convert.ToInt32(temp[i]);
            }
            res = res/temp.Length;
            return res;
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
