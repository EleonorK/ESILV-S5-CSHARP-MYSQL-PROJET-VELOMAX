using MySql.Data.MySqlClient;
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

namespace projetBDD
{
    /// <summary>
    /// Logique d'interaction pour CommandeClient.xaml
    /// </summary>
    public partial class CommandeClient : Window
    {
        public CommandeClient()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void RechercherVelo_Click(object sender, RoutedEventArgs e)
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
            if (tbnom_velo.Text == "")
            {
                selection = "SELECT * FROM velo";
            }
            else
            {
                selection = "SELECT * FROM velo WHERE nom_velo = '" + tbnom_velo.Text + "';";
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
                AfficheGrille(dgVelo, selection);
                dgVelo.IsReadOnly = true;
            }
            else
            {
                MessageBox.Show("Aucun résultat");
            }
            #endregion
            maConnexion.Close();
        }


        private void RechercherPiece_Click(object sender, RoutedEventArgs e)
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

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            string ProduitASupprimer = lbPanier.SelectedItem.ToString();
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

            string IsPresent = "";
            double prix_velo = 0;
            string test = "";
            double prixASupprimer = 0;

            IsPresent = Result("SELECT '" + ProduitASupprimer + "' IN (SELECT nom_velo FROM velo)");
            if (IsPresent == "1")//c'est un vélo
            {
                prix_velo = RecupePrix("SELECT prix_velo FROM velo WHERE nom_velo = '" + ProduitASupprimer + "';");
                test = Convert.ToString(prix_velo);
                if (test.Length > 3)
                {
                    test = test.Remove(3);
                }
                prixASupprimer = Convert.ToInt32(test);
            }
            else
            {
                prixASupprimer = RecupePrix("SELECT prix_piece FROM piece WHERE nom_piece = '" + ProduitASupprimer + "';");
            }

            MessageBox.Show("ligne 231 = " + tbPrixTotal.Text);
            tbPrixTotal.Text = tbPrixTotal.Text.Replace(" €", "");
            double tmp = Convert.ToDouble(tbPrixTotal.Text) - prixASupprimer;
            MessageBox.Show("ligne 234 = ", tmp.ToString());
            tbPrixTotal.Text = tmp + " €";
            maConnexion.Close();
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

        static int RecupQte(string nom, ListBox lbPanier)
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
                    //construire la ligne dans une chaine de caractères
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
            /*ValiderCommandeClient v = new ValiderCommandeClient(Convert.ToDouble(tbPrixTotal.Text.Replace(" €","")));
            v.Show();
            this.Hide();*/
            // juste a rajouter dans l'ordre qte velo, qte piece, id velo, id piece
            // le prix est deja ds le parametre

        }

        private void dgVelo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = dgVelo.SelectedItem;
            //lbPanier.Items.Add((dgVelo.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text + ";"+(dgVelo.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text);
            lbPanier.Items.Add((dgVelo.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text);
            if (dgVelo.SelectedCells[1].Column.GetCellContent(item).IsMouseCaptured == true)
            {
                lbPanier.Items.Add((dgVelo.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text);
            }
            /*
            string[] tab;
            tab = Convert.ToString(lbPanier.Items[lbPanier.Items.Count-1]).Split(';');
            MessageBox.Show("ligne 126 = " + tab[1]);
            */



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

            double prix_velo = 0;
            string test = "";
            string IsPresent = "";
            double prixTotal = 0;

            IsPresent = Result("SELECT '" + lbPanier.Items[lbPanier.Items.Count - 1] + "' IN (SELECT nom_velo FROM velo)");
            //prix_velo = RecupePrix("SELECT prix_velo FROM velo WHERE nom_velo = '" + lbPanier.Items[i] + "' AND grandeur ='"+tab[1]+"';");
            if (IsPresent == "1")
            {
                //prix_velo = RecupePrix("SELECT prix_velo FROM velo WHERE nom_velo = '" + lbPanier.Items[i] + "' AND grandeur ='"+tab[1]+"';");
                prix_velo = RecupePrix("SELECT prix_velo FROM velo WHERE nom_velo = '" + lbPanier.Items[lbPanier.Items.Count - 1] + "';");
                test = Convert.ToString(prix_velo);
                if (test.Length > 3)
                {
                    test = test.Remove(3);
                }
                //prix_velo = Convert.ToInt32(Convert.ToString(prix_velo).Remove(3));
                if (tbPrixTotal.Text != "")
                {
                    prixTotal = Convert.ToDouble(tbPrixTotal.Text.Replace(" €", "")) + prixTotal + Convert.ToDouble(test);
                }
                else
                {
                    prixTotal = prixTotal + Convert.ToInt32(test);
                }

                tbPrixTotal.Text = prixTotal.ToString() + " €";
            }

            tbPrixTotal.Text = prixTotal.ToString() + " €";

            maConnexion.Close();
        }

        private void dgPiece_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = dgPiece.SelectedItem;
            //lbPanier.Items.Add((dgVelo.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text + ";"+(dgVelo.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text);
            lbPanier.Items.Add((dgPiece.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text);
            if (dgPiece.SelectedCells[2].Column.GetCellContent(item).IsMouseCaptured == true)
            {
                lbPanier.Items.Add((dgPiece.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text);
            }

            //MessageBox.Show("ligne 491 = " + (dgPiece.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text);


            /*
            string[] tab;
            tab = Convert.ToString(lbPanier.Items[lbPanier.Items.Count-1]).Split(';');
            MessageBox.Show("ligne 126 = " + tab[1]);
            */

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

            //string IsPresent = Result("SELECT 'Kilimandjaroo' IN (SELECT nom_velo FROM velo)");
            string IsPresent = "";



            // -----------------------------------------------------------------------------------------------------------------------------------------

            double prix_piece = 0;
            double prixTotal = 0;

            IsPresent = Result("SELECT '" + lbPanier.Items[lbPanier.Items.Count - 1] + "' IN (SELECT nom_piece FROM piece);");
            //MessageBox.Show("ligne 539 res = " + IsPresent);
            //prix_velo = RecupePrix("SELECT prix_velo FROM velo WHERE nom_velo = '" + lbPanier.Items[i] + "' AND grandeur ='"+tab[1]+"';");
            if (IsPresent == "1")
            {
                prix_piece = RecupePrix("SELECT prix_piece FROM piece WHERE nom_piece = '" + lbPanier.Items[lbPanier.Items.Count - 1] + "';");
                if (tbPrixTotal.Text != "")
                {
                    prixTotal = Convert.ToDouble(tbPrixTotal.Text.Replace(" €", "")) + prixTotal + prix_piece;
                }
                else
                {
                    prixTotal = prixTotal + prix_piece;
                }

                tbPrixTotal.Text = prixTotal.ToString() + " €";
            }
            tbPrixTotal.Text = prixTotal.ToString() + " €";
            maConnexion.Close();
        }
        static string Result(string requete)
        {
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

            MySqlCommand command2 = maConnexion.CreateCommand();
            command2.CommandText = requete;
            MySqlDataReader exeRequete = command2.ExecuteReader();
            #region exploitation des résultats
            string tableau = "";
            while (exeRequete.Read())
            {
                string ligne = "";
                for (int i = 0; i < exeRequete.FieldCount; i++)
                {
                    ligne = ligne + exeRequete.GetValue(i).ToString();
                }
                tableau = tableau + ligne;
            }
            tableau = tableau.Replace(" ", "");
            exeRequete.Close();
            #endregion
            maConnexion.Close();
            return tableau;
        }

        private void bt_exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void bt_retour_Click(object sender, RoutedEventArgs e)
        {
            Gerer_Commande c = new Gerer_Commande();
            c.Show();
            this.Hide();
        }
    }
}
