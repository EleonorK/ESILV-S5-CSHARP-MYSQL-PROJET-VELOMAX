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
    /// Logique d'interaction pour ValiderCommandeClient.xaml
    /// </summary>
    public partial class ValiderCommandeClient : Window
    {
        private int id_cli = 0;
        public int Id_cli
        {
            get { return id_cli; }
        }
        private int id_velo = 0;
        public int Id_Velo
        {
            get { return id_velo; }
        }
        private int id_piece = 0;
        public int Id_Piece
        {
            get { return id_piece; }
        }
        private int qte_velo = 0;
        public int Qte_velo
        {
            get { return qte_velo; }
        }
        private int qte_piece = 0;
        public int Qte_piece
        {
            get { return qte_piece; }
        }
        private double prix_base = 0;
        public double Prix_base
        {
            get { return prix_base; }
        }
        private double prix_final=0;
        public double Prix_final
        {
            get { return prix_final; }
        }
        private int del = 0;
        public int Del
        {
            get { return del; }
        }
        public ValiderCommandeClient(double prix,int qteVelo, int qtePiece, int idVelo, int idPiece)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            tx_nom.Visibility = Visibility.Hidden;
            bt_RechercheNom.Visibility = Visibility.Hidden;
            this.prix_base = prix;
            this.id_piece = idPiece;
            this.id_velo = idVelo;
            this.qte_piece = qtePiece;
            this.qte_velo = qteVelo;
        }
        #region Test Client
        private void TestIndividu()
        {
            MySqlConnection maConnexion = null;
            string tableau = "";
            string ligne = "";

            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                maConnexion = new MySqlConnection(connexionInfo);
                string query = "SELECT id_clients FROM clients WHERE nom_clients='"+tx_nom+"';";
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
                this.id_cli = Convert.ToInt32(tableau);
                maConnexion.Close();
            }
            catch (MySqlException msg)
            {
                MessageBox.Show("Erreur de connexion : " + msg.ToString());
                //return;
            }
        }
        private void TestBoutique()
        {
            MySqlConnection maConnexion = null;
            string tableau = "";
            string ligne = "";
            int id = 0;

            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                maConnexion = new MySqlConnection(connexionInfo);
                string query = "SELECT id_clients FROM clients WHERE nom_boutique='" + tx_nom + "';";
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
                this.id_cli = Convert.ToInt32(tableau);
                maConnexion.Close();
            }
            catch (MySqlException msg)
            {
                MessageBox.Show("Erreur de connexion : " + msg.ToString());
                //return;
            }
        }
        #endregion
        #region bt inutiles
        private void bt_exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void bt_retour_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion
        #region Test rabais
        private bool Adherant()
        {
            MySqlConnection maConnexion = null;
            string tableau = "";
            string ligne = "";
            bool ad = false;
            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                maConnexion = new MySqlConnection(connexionInfo);
                string query = "SELECT adhesion FROM clients WHERE id_clients = " + this.id_cli + ";";
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
                if(tableau == "1") { ad = true; }
                maConnexion.Close();
            }
            catch (MySqlException msg)
            {
                MessageBox.Show("Erreur de connexion : " + msg.ToString());
                //return;
            }
            return ad;
        }
        private int TestFidelio()
        {
            MySqlConnection maConnexion = null;
            string tableau = "";
            string ligne = "";
            int rabais = 0;
            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                maConnexion = new MySqlConnection(connexionInfo);
                string query = "SELECT rabais FROM fidelio F, adhesion A WHERE A.id_clients = "+this.id_cli+" AND F.if_fidelio = A.id_fidelio;";
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
                tableau.Replace("%", "");
                rabais = Convert.ToInt32(tableau);
                maConnexion.Close();
            }
            catch (MySqlException msg)
            {
                MessageBox.Show("Erreur de connexion : " + msg.ToString());
                //return;
            }
            return rabais;
        }
        private int TestBoutiqueRabais()
        {
            MySqlConnection maConnexion = null;
            string tableau = "";
            string ligne = "";
            int nb_achat = 0;
            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                maConnexion = new MySqlConnection(connexionInfo);
                string query = "SELECT nb_achat FROM clients WHERE id_clients = "+this.id_cli+";";
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
                tableau.Replace("%", "");
                nb_achat = Convert.ToInt32(tableau);
                maConnexion.Close();
            }
            catch (MySqlException msg)
            {
                MessageBox.Show("Erreur de connexion : " + msg.ToString());
                //return;
            }
            return nb_achat;
        }
        #endregion
        #region Ajouter cumul et achat
        private double TrouverCumul()
        {
            MySqlConnection maConnexion = null;
            string tableau = "";
            string ligne = "";
            double cumul = 0;
            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                maConnexion = new MySqlConnection(connexionInfo);
                string query = "SELECT nb_cumul FROM clients WHERE id_clients=" + this.id_cli + ";";
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
                tableau = tableau.Replace(",", ".");
                cumul = Convert.ToDouble(tableau);
                maConnexion.Close();
            }
            catch (MySqlException msg)
            {
                MessageBox.Show("Erreur de connexion : " + msg.ToString());
                //return;
            }
            return cumul;
        }
        private void AjoutCumul(double nvx_cumul)
        {
            MySqlConnection maConnexion = null;
            string tableau = "";
            string ligne = "";
            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                maConnexion = new MySqlConnection(connexionInfo);
                string query = "UPDATE clients SET nb_cumul='"+nvx_cumul.ToString().Replace(".",",")+"€' WHERE id_client="+this.id_cli+";";
                maConnexion.Open();
                MySqlCommand cmd = maConnexion.CreateCommand();
                cmd.CommandText = query;
                MySqlDataReader exeRequete = cmd.ExecuteReader();
                exeRequete.Close();
                maConnexion.Close();
            }
            catch (MySqlException msg)
            {
                MessageBox.Show("Erreur de connexion : " + msg.ToString());
                //return;
            }
        }
        private void AjoutAchat()
        {
            MySqlConnection maConnexion = null;
            string tableau = "";
            string ligne = "";
            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                maConnexion = new MySqlConnection(connexionInfo);
                string query = "UPDATE clients SET nb_achat = nb_achat + 1 WHERE id_client=" + this.id_cli + ";";
                maConnexion.Open();
                MySqlCommand cmd = maConnexion.CreateCommand();
                cmd.CommandText = query;
                MySqlDataReader exeRequete = cmd.ExecuteReader();
                exeRequete.Close();
                maConnexion.Close();
            }
            catch (MySqlException msg)
            {
                MessageBox.Show("Erreur de connexion : " + msg.ToString());
                //return;
            }
        }
        #endregion
        #region insertion
        private int Trouver_IDcommande()
        {
            int id = 0;
            MySqlConnection maConnexion = null;

            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                maConnexion = new MySqlConnection(connexionInfo);
                string query = "SELECT MAX(id_commande) FROM commande;";
                maConnexion.Open();
                MySqlCommand cmd = maConnexion.CreateCommand();
                cmd.CommandText = query;
                MySqlDataReader exeRequete = cmd.ExecuteReader();
                string tableau = "";
                string ligne = "";
                while (exeRequete.Read())
                {
                    for (int i = 0; i < exeRequete.FieldCount; i++)
                    {
                        ligne = ligne + " \t" + exeRequete.GetValue(i).ToString();
                    }
                    tableau = tableau + "\n " + ligne;
                }
                exeRequete.Close();
                id = Convert.ToInt32(tableau.Replace(" ", ""));
                maConnexion.Close();
            }
            catch (MySqlException msg)
            {
                MessageBox.Show("Erreur de connexion : " + msg.ToString());
                //return;
            }
            return id;
        }
        private int Trouver_IDadresse()
        {
            int id = 0;
            MySqlConnection maConnexion = null;

            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                maConnexion = new MySqlConnection(connexionInfo);
                string query = "SELECT id_adresse FROM clients WHERE id_clients="+this.id_cli+";";
                maConnexion.Open();
                MySqlCommand cmd = maConnexion.CreateCommand();
                cmd.CommandText = query;
                MySqlDataReader exeRequete = cmd.ExecuteReader();
                string tableau = "";
                string ligne = "";
                while (exeRequete.Read())
                {
                    for (int i = 0; i < exeRequete.FieldCount; i++)
                    {
                        ligne = ligne + " \t" + exeRequete.GetValue(i).ToString();
                    }
                    tableau = tableau + "\n " + ligne;
                }
                exeRequete.Close();
                id = Convert.ToInt32(tableau.Replace(" ", ""));
                maConnexion.Close();
            }
            catch (MySqlException msg)
            {
                MessageBox.Show("Erreur de connexion : " + msg.ToString());
                //return;
            }
            return id;
        }
        private void InsererCommande()
        {
            int idAdresse = Trouver_IDadresse();
            MySqlConnection maConnexion = null;
            DateTime thisDay = DateTime.Today;
            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                maConnexion = new MySqlConnection(connexionInfo);
                maConnexion.Open();
                string query = "INSERT INTO commande(id_clients,id_adresse,date_commande,date_livraison,prix_commande) VALUES (@id_clients,@id_adresse,@date_commande,@date_livraison,@prix_commande)";
                MySqlCommand cmd = new MySqlCommand(query, maConnexion);
                cmd.Parameters.Add(new MySqlParameter("@id_clients", this.id_cli));
                cmd.Parameters.Add(new MySqlParameter("@id_adresse", idAdresse));
                cmd.Parameters.Add(new MySqlParameter("@date_commande", conversiondate(thisDay.ToString())));
                cmd.Parameters.Add(new MySqlParameter("@date_livraison", AddDate(conversiondate(thisDay.ToString()))));
                cmd.Parameters.Add(new MySqlParameter("@prix_commande", this.prix_final));
                cmd.ExecuteNonQuery();
                maConnexion.Close();
            }
            catch (MySqlException msg)
            {
                MessageBox.Show("Erreur de connexion : " + msg.ToString());
                return;
            }
        }
        private void InsererVelo()
        {
            int idAdresse = Trouver_IDadresse();
            MySqlConnection maConnexion = null;
            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                maConnexion = new MySqlConnection(connexionInfo);
                maConnexion.Open();
                string query = "INSERT INTO vente_velo(id_commande,id_velo,qte_velo) VALUES (@id_commande,@id_velo,@qte_velo)";
                MySqlCommand cmd = new MySqlCommand(query, maConnexion);
                cmd.Parameters.Add(new MySqlParameter("@id_commande", Trouver_IDcommande()));
                cmd.Parameters.Add(new MySqlParameter("@id_velo", this.id_velo));
                cmd.Parameters.Add(new MySqlParameter("@qte_velo", this.qte_velo)); ;
                cmd.ExecuteNonQuery();
                maConnexion.Close();
            }
            catch (MySqlException msg)
            {
                MessageBox.Show("Erreur de connexion : " + msg.ToString());
                return;
            }
        }
        private void InsererPiece()
        {
            int idAdresse = Trouver_IDadresse();
            MySqlConnection maConnexion = null;
            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                maConnexion = new MySqlConnection(connexionInfo);
                maConnexion.Open();
                string query = "INSERT INTO vente_piece(id_commande,id_piece,qte_piece) VALUES (@id_commande,@id_piece,@qte_piece)";
                MySqlCommand cmd = new MySqlCommand(query, maConnexion);
                cmd.Parameters.Add(new MySqlParameter("@id_commande", Trouver_IDcommande()));
                cmd.Parameters.Add(new MySqlParameter("@id_piece", this.id_piece));
                cmd.Parameters.Add(new MySqlParameter("@qte_piece", this.qte_piece)); ;
                cmd.ExecuteNonQuery();
                maConnexion.Close();
            }
            catch (MySqlException msg)
            {
                MessageBox.Show("Erreur de connexion : " + msg.ToString());
                return;
            }
        }

        #endregion
        private void bt_verifProduit_Click(object sender, RoutedEventArgs e)
        {
            if (cb_client.Text != "")
            {
                cb_client.IsEnabled = false;
                bt_verifProduit.Visibility = Visibility.Hidden;
                tx_nom.Visibility = Visibility.Visible;
                bt_RechercheNom.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Veuiller choisir le type de Client");
            }
        }

        private void bt_verif_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            int delai = rand.Next(1, 13);
            if (cb_client.Text == "") { MessageBox.Show("Veuillez saisir le le type de client"); }
            else
            {
                if (cb_client.Text == "INDIVIDU")
                {
                    double cumul = TrouverCumul();
                    AjoutCumul(prix_final + cumul);
                    AjoutAchat();
                    InsererCommande();
                    if (this.qte_velo != 0) { InsererVelo(); }
                    if (this.qte_piece != 0) { InsererPiece(); }
                }
                else
                {
                    double cumul = TrouverCumul();
                    AjoutCumul(prix_final + cumul);
                    AjoutAchat();
                    InsererCommande();
                    if(this.qte_velo != 0) { InsererVelo(); }
                    if (this.qte_piece != 0) { InsererPiece(); }
                    if(this.qte_piece == 0) { MessageBox.Show("La commande arrivera dans " + delai + " chez vous"); }
                    else { MessageBox.Show("La commande arrivera dans " + this.del + " chez vous"); }
                }
            }
        }

        private void bt_RechercheNom_Click(object sender, RoutedEventArgs e)
        {
            if (cb_client.Text == "INDIVIDU")
            {
                TestIndividu();
                if (Adherant() == true)
                {
                    int rabais = TestFidelio();
                    this.prix_final = (this.prix_base * rabais) / 100;
                    this.prix_final = this.prix_base - this.prix_final;
                }
                else { this.prix_final = this.prix_base; }
            }
            else
            {
                TestBoutique();
                int nb_achat = TestBoutiqueRabais();
                double prix_final = 0;
                if (nb_achat % 5 == 0)
                {
                    this.prix_final = (this.prix_base * 15) / 100;
                    this.prix_final = this.prix_base - prix_final;
                }
                else { this.prix_final = this.prix_base; }
            }
            lb_prix.Content = "PRIX A REGLER : " + this.prix_final ;
        }
        #region date
        static string conversiondate(string chaine)
        {
            string date = chaine; // 2021/12/7
            if (date.Length != 0)
            {
                date = date.Remove(10);
                date = date.Replace(" ", "");
                if (date.Length == 10)
                {
                    date = date.Substring(6, 4) + "/" + date.Substring(3, 2) + "/" + date.Substring(0, 2);
                }
                if (date.Length == 9)
                {
                    date = date.Substring(5, 4) + "/" + date.Substring(2, 2) + "/" + date.Substring(0, 1);
                }
            }
            return date;
        }
        private string AddDate(string dateBase)
        {
            string [] ligne = dateBase.Split('/');
            string dateFinale = "/" + ligne[1] + "/" + ligne[2];
            dateFinale += (Convert.ToInt32(ligne[2]) + this.del).ToString();
            dateFinale += "/" + ligne[0] + "/" + ligne[1];
            return dateFinale;
        }
        private void Delai()
        {
            MySqlConnection maConnexion = null;

            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                maConnexion = new MySqlConnection(connexionInfo);
                string query = "SELECT delai FROM clients WHERE id_piece=" + this.id_piece + ";";
                maConnexion.Open();
                MySqlCommand cmd = maConnexion.CreateCommand();
                cmd.CommandText = query;
                MySqlDataReader exeRequete = cmd.ExecuteReader();
                string tableau = "";
                string ligne = "";
                while (exeRequete.Read())
                {
                    for (int i = 0; i < exeRequete.FieldCount; i++)
                    {
                        ligne = ligne + " \t" + exeRequete.GetValue(i).ToString();
                    }
                    tableau = tableau + "\n " + ligne;
                }
                exeRequete.Close();
                this.del = Convert.ToInt32(tableau.Replace(" ", ""));
                maConnexion.Close();
            }
            catch (MySqlException msg)
            {
                MessageBox.Show("Erreur de connexion : " + msg.ToString());
                //return;
            }
        }
        #endregion
    }
}
