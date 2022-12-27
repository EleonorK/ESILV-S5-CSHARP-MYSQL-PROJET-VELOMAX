using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
    /// Logique d'interaction pour CommandeGerant.xaml
    /// </summary>
    public partial class CommandeGerant : Window
    {
        public CommandeGerant()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Rechercher_Click(object sender, RoutedEventArgs e)
        {
            #region 1.Ouverture de la connexion avec MySQL
            MySqlConnection maConnexion = null;
            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                maConnexion = new MySqlConnection(connexionInfo);
                maConnexion.Open();
            }
            catch (MySqlException msg)
            {
                MessageBox.Show("Erreur de connexion : " + msg.ToString());
                return;
            }
            #endregion

            string selection = "";

            #region selection
            if (tbnom_piece.Text == "")
            {
                selection = "SELECT * FROM piece";
            }
            else
            {
                selection = "SELECT * FROM piece WHERE nom_piece = '" + tbnom_piece.Text + "';";
            }

            MySqlCommand command2 = maConnexion.CreateCommand();
            command2.CommandText = selection;
            MySqlDataReader exeRequete = command2.ExecuteReader();
            #endregion

            #region exploitation des résultats
            string tableau = "";

            while (exeRequete.Read())
            {
                string ligne = "";
                for (int i = 0; i < exeRequete.FieldCount; i++)
                {
                    ligne = ligne + " \t" + exeRequete.GetValue(i).ToString();
                }
                tableau = tableau + "\n " + ligne;
            }
            exeRequete.Close();
            if (tableau != "")
            {
                AfficheGrille(dgPiece, selection);
                dgPiece.IsReadOnly = true;
            }
            else
            {
                MessageBox.Show("Aucun résultat");
            }
            #endregion
            maConnexion.Close();
        }

        static void AfficheGrille(DataGrid dg, string requete)
        {
            DataTable myDT;
            myDT = new DataTable();

            MySqlConnection maConnexion = null;
            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                maConnexion = new MySqlConnection(connexionInfo);

                maConnexion.Open();

                MySqlDataAdapter sqlDa = new MySqlDataAdapter(requete, maConnexion);
                sqlDa.SelectCommand.CommandType = CommandType.Text;
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dg.ItemsSource = dtbl.DefaultView;
            }
            catch (MySqlException msg)
            {
                MessageBox.Show("Erreur de connexion : " + msg.ToString());
            }
            finally
            {
                maConnexion.Close();
            }
        }

        private void dgPiece_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = dgPiece.SelectedItem;
            lbPanier.Items.Add((dgPiece.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text);
            if (dgPiece.SelectedCells[2].Column.GetCellContent(item).IsMouseCaptured == true)
            {
                lbPanier.Items.Add((dgPiece.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text);
            }

            #region 1.Ouverture de la connexion avec MySQL
            MySqlConnection maConnexion = null;
            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                //connexion
                maConnexion = new MySqlConnection(connexionInfo);

                //ouvrir le canal de communication/connexion
                maConnexion.Open();
            }
            catch (MySqlException msg)
            {
                MessageBox.Show("Erreur de connexion : " + msg.ToString());
                return;
            }
            #endregion



            // -----------------------------------------------------------------------------------------------------------------------------------------

            double prix_piece = 0;

            double prixTotal = 0;
            for (int i = 0; i < lbPanier.Items.Count; i++)
            {
                prix_piece = RecupePrix("SELECT prix_piece FROM piece WHERE nom_piece = '" + lbPanier.Items[i] + "';");

                prixTotal = prixTotal + prix_piece;
                tbPrixTotal.Text = prixTotal.ToString() + " €";
            }
            tbPrixTotal.Text = prixTotal.ToString() + " €";
            maConnexion.Close();
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            lbPanier.Items.Remove(lbPanier.SelectedItem);

            #region 1.Ouverture de la connexion avec MySQL
            MySqlConnection maConnexion = null;
            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                //connexion
                maConnexion = new MySqlConnection(connexionInfo);

                //ouvrir le canal de communication/connexion
                maConnexion.Open();
            }
            catch (MySqlException msg)
            {
                MessageBox.Show("Erreur de connexion : " + msg.ToString());
                return;
            }
            #endregion



            // -----------------------------------------------------------------------------------------------------------------------------------------
            double prix_piece = 0;
            double prixTotal = 0;
            for (int i = 0; i < lbPanier.Items.Count; i++)
            {

                prix_piece = RecupePrix("SELECT prix_piece FROM piece WHERE nom_piece = '" + lbPanier.Items[i] + "';");

                prixTotal = prixTotal + prix_piece;
                tbPrixTotal.Text = prixTotal.ToString() + "€";
            }
            tbPrixTotal.Text = prixTotal.ToString() + "€";
            maConnexion.Close();

            MessageBox.Show("le produit a été supprimé");

        }

        static int RecupeID(string requete)
        {
            #region 1.Ouverture de la connexion avec MySQL
            MySqlConnection maConnexion = null;
            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                //connexion
                maConnexion = new MySqlConnection(connexionInfo);

                //ouvrir le canal de communication/connexion
                maConnexion.Open();
            }
            catch (MySqlException msg)
            {
                MessageBox.Show("Erreur de connexion : " + msg.ToString());
            }
            #endregion

            #region selection
            string selection = requete;
            MySqlCommand command2 = maConnexion.CreateCommand();
            command2.CommandText = selection;
            MySqlDataReader exeRequete = command2.ExecuteReader();
            #endregion

            string tableau = "";

            while (exeRequete.Read())
            {
                //récupération du résultat ligne par ligne
                //MessageBox.Show("Il y a " + exeRequete.FieldCount + "colonnes");

                //pour chaque ligne 
                string ligne = "";
                for (int i = 0; i < exeRequete.FieldCount; i++)
                {
                    //construire la ligne dans une chaine de caratères
                    ligne = ligne + exeRequete.GetValue(i).ToString();
                }
                tableau = tableau + ligne;
            }
            exeRequete.Close();
            maConnexion.Close();
            return Convert.ToInt32(tableau);
        }

        static double RecupQte(string nom, ListBox lbPanier)
        {
            int compteur = 0;
            for (int i = 0; i < lbPanier.Items.Count; i++)
            {
                if (lbPanier.Items[i].ToString() == nom)
                {
                    compteur++;
                }
            }
            return compteur;
        }

        static double RecupePrix(string requete)
        {
            #region 1.Ouverture de la connexion avec MySQL
            MySqlConnection maConnexion = null;
            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                //connexion
                maConnexion = new MySqlConnection(connexionInfo);

                //ouvrir le canal de communication/connexion
                maConnexion.Open();
            }
            catch (MySqlException msg)
            {
                MessageBox.Show("Erreur de connexion : " + msg.ToString());
            }
            #endregion

            #region selection
            string selection = requete;
            MySqlCommand command2 = maConnexion.CreateCommand();
            command2.CommandText = selection;
            MySqlDataReader exeRequete = command2.ExecuteReader();
            #endregion

            string tableau = "";

            while (exeRequete.Read())
            {
                //récupération du résultat ligne par ligne
                //MessageBox.Show("Il y a " + exeRequete.FieldCount + "colonnes");

                //pour chaque ligne 
                string ligne = "";
                for (int i = 0; i < exeRequete.FieldCount; i++)
                {
                    //construire la ligne dans une chaine de caratères
                    ligne = ligne + exeRequete.GetValue(i).ToString();
                }
                tableau = tableau + ligne;
            }
            //MessageBox.Show("tableau à la l.250 =" + tableau);
            exeRequete.Close();
            maConnexion.Close();
            return Convert.ToDouble(tableau.Replace("€", ""));
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            #region 1.Ouverture de la connexion avec MySQL
            MySqlConnection maConnexion = null;
            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                //connexion
                maConnexion = new MySqlConnection(connexionInfo);

                //ouvrir le canal de communication/connexion
                maConnexion.Open();
            }
            catch (MySqlException msg)
            {
                MessageBox.Show("Erreur de connexion : " + msg.ToString());
                return;
            }
            #endregion

            #region insertion commande

            string dateCommande = DateTime.Now.ToString("yyyy-MM-dd");

            //string dateLivraison = dateCommande + delai
            string selection = "INSERT INTO commande(id_clients, id_adresse, date_commande, date_livraison, prix_commande) VALUES (1,1,'" + dateCommande + "','" + AddDate(dateCommande) + "','" + tbPrixTotal.Text + "');";

            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = selection;
            command.ExecuteNonQuery();
            command.Dispose();
            #endregion

            // -----------------------------------------------------------------------------------------------------------------------------------------
            #region insertion vente_piece
            //string requeteId_piece = "";
            int id_piece = 0;
            double qte_piece = 0;
            double prix_piece = 0;

            double prixTotal = 0;
            for (int i = 0; i < lbPanier.Items.Count; i++)
            {
                id_piece = RecupeID("SELECT id_piece FROM piece WHERE nom_piece = '" + lbPanier.Items[i] + "';");
                qte_piece = RecupQte(lbPanier.Items[i].ToString(), lbPanier);
                prix_piece = RecupePrix("SELECT prix_piece FROM piece WHERE nom_piece = '" + lbPanier.Items[i] + "';");
                selection = "INSERT INTO vente_piece(id_commande, id_piece, qte_piece) VALUES(1," + id_piece + "," + qte_piece + ")";
                prixTotal = prixTotal + prix_piece;
                command.CommandText = selection;
                command.ExecuteNonQuery();
                command.Dispose();
            }

            #endregion
            maConnexion.Close();
            MessageBox.Show("Commande validée !");
        }

        private void bt_retour_Click(object sender, RoutedEventArgs e)
        {
            Gerer_Commande cmd = new Gerer_Commande();
            cmd.Show();
            this.Hide();
        }

        private void bt_exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private string AddDate(string dateBase)
        {
            Random rand = new Random();
            int duree = rand.Next(3, 12);
            string[] ligne = dateBase.Split('-');
            string dateFinale = ligne[0] + "/" + ligne[1] +"/";
            dateFinale += (Convert.ToInt32(ligne[2]) + duree).ToString();
            return dateFinale;
        }
    }
}
