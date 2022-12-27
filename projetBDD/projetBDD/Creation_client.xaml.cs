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
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace projetBDD
{
    /// <summary>
    /// Logique d'interaction pour Creation_client.xaml
    /// </summary>
    public partial class Creation_client : Window
    {
        private int num_fidelio;
        public int Num_fildelio
        {
            get { return this.num_fidelio; }
        }
        private int duree;
        public int Duree
        {
            get { return duree; }
        }
        public Creation_client()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            grid_original.Visibility = Visibility.Hidden;
            sc_original.Visibility = Visibility.Hidden;
        }
        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void bt_retour_Click(object sender, RoutedEventArgs e)
        {
            Gerer_clients fenetre = new Gerer_clients();
            fenetre.Show();
            this.Hide();
        }

        private void bt_exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void bt_verifClient_Click(object sender, RoutedEventArgs e)
        {
            if (cb_client.Text != "")
            {
                MessageBox.Show("produit defini");
                cb_client.IsEnabled = false;
                bt_verifProduit.Visibility = Visibility.Hidden;
                grid_original.Visibility = Visibility.Visible;
                sc_original.Visibility = Visibility.Visible;
                if (cb_client.Text == "BOUTIQUE")
                {
                    tx_prenom.Visibility = Visibility.Hidden;
                    fidelio.IsEnabled = false;
                    st_fidelio.IsEnabled=false;

                }
            }
            else
            {
                MessageBox.Show("Veuiller choisir le type de Client");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cb_client.Text == "INDIVIDUEL")
            {
                if (Verif_Individuel() == true)
                {
                    InsererAdresse();
                    int id = Trouver_IDadresse();
                    if (Verif_Adhesion() == false)
                    {
                        MessageBox.Show("Fidelio non souscrit");
                        InsererClient(true, id, false);
                    }
                    else {
                        InsererClient(true, id, true);
                        int id_cli = Trouver_IDclients();
                        InsererAdhesion(id_cli);
                    }
                }
            }
            else
            {
                if (Verif_Boutique() == true)
                {
                    InsererAdresse();
                    int id = Trouver_IDadresse();
                    InsererClient(false, id, false);
                }
            }
        }
        #region methodes
        private bool Verif_Individuel()
        {
            bool verif = true;
            if(verif == true)
            {
                if (tx_nom.Text == "") {MessageBox.Show("Veuillez saisir un nom"); verif = false; }
                if (tx_prenom.Text == "") { MessageBox.Show("Veuillez saisir un prenom"); verif = false; }
                if (tx_rue.Text == "" || tx_ville.Text == "" ||tx_province.Text == "" || tx_CP.Text == "") { MessageBox.Show("Veuillez saisir une adresse postale"); verif = false; }
                if (tx_numTel.Text == "") { MessageBox.Show("Veuillez saisir un numero de téléphone"); verif = false; }
                if (tx_couriel.Text == "") { MessageBox.Show("Veuillez saisir une adresse mail"); verif = false; }
                if(Verif_Mdp() == false) { MessageBox.Show("Mot de passe incorrect"); verif = false; }
            }
            return verif;
        }
        private bool Verif_Boutique()
        {
            bool verif = true;
            if (verif == true)
            {
                if (tx_nom.Text == "") { MessageBox.Show("Veuillez saisir le nom de la boutique"); verif = false; }
                if (tx_rue.Text == "" || tx_ville.Text == "" || tx_province.Text == "" || tx_CP.Text == "") { MessageBox.Show("Veuillez saisir une adresse postale"); verif = false; }
                if (tx_numTel.Text == "" ) { MessageBox.Show("Veuillez saisir un numero de téléphone"); verif = false; }
                if (tx_couriel.Text == "") { MessageBox.Show("Veuillez saisir une adresse mail"); verif = false; }
                if (Verif_Mdp() == false) { MessageBox.Show("Mot de passe incorrect"); verif = false; }
            }
            return verif;
        }
        private bool Verif_Mdp()
        {
            bool verif;
            if (tx_mdp.Password.ToString() == tx_mdpConfir.Password.ToString()) { verif = true; }
            else { verif = false; }
            return verif;
        }
        #region fidelio
        private bool Verif_Adhesion()
        {
            bool bon = false;
            if (ck_normal.IsChecked==true && ck_or.IsChecked==false && ck_platine.IsChecked == false && ck_max.IsChecked == false) { bon = true; this.num_fidelio = 1; this.duree = 1; }
            else if (ck_normal.IsChecked == false && ck_or.IsChecked == true && ck_platine.IsChecked == false && ck_max.IsChecked == false) { bon = true; this.num_fidelio = 2; this.duree = 2; }
            else if (ck_normal.IsChecked == false && ck_or.IsChecked == false && ck_platine.IsChecked == true && ck_max.IsChecked == false) { bon = true; this.num_fidelio = 3; this.duree = 2; }
            else if (ck_normal.IsChecked == false && ck_or.IsChecked == false && ck_platine.IsChecked == false && ck_max.IsChecked == true) { bon = true; this.num_fidelio = 4; this.duree = 3; }
            return bon;
        }
        #endregion
        #region insertion
        private int Trouver_IDadresse()
        {
            int id = 0;
            MySqlConnection maConnexion = null;
            
            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                maConnexion = new MySqlConnection(connexionInfo);
                string query = "SELECT MAX(id_adresse) FROM adresse;";
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
        private int Trouver_IDclients()
        {
            int id = 0;
            MySqlConnection maConnexion = null;

            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                maConnexion = new MySqlConnection(connexionInfo);
                string query = "SELECT MAX(id_clients) FROM clients";
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
        private void InsererAdresse()
        {
            MySqlConnection maConnexion = null;
            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                maConnexion = new MySqlConnection(connexionInfo);
                maConnexion.Open();
                string query = "INSERT INTO adresse(rue,ville,code_postal,province) VALUES (@rue,@ville,@code_postal,@province)";
                MySqlCommand cmd = new MySqlCommand(query, maConnexion);
                cmd.Parameters.Add(new MySqlParameter("@rue", tx_rue.Text));
                cmd.Parameters.Add(new MySqlParameter("@ville", tx_ville.Text));
                cmd.Parameters.Add(new MySqlParameter("@code_postal", tx_CP.Text));
                cmd.Parameters.Add(new MySqlParameter("@province", tx_province.Text));
                cmd.ExecuteNonQuery();
                maConnexion.Close();
            }
            catch (MySqlException msg)
            {
                MessageBox.Show("Erreur de connexion : " + msg.ToString());
                return;
            }
        }
        private void InsererClient(bool client, int id, bool fidelio)
        {
            MySqlConnection maConnexion = null;
            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                maConnexion = new MySqlConnection(connexionInfo);
                maConnexion.Open();
                if(client == true)
                {
                    string query = "INSERT INTO clients(mdp_clients,nom_clients,prenom_clients,id_adresse,contact_clients,couriel_clients,adhesion) VALUES (@mdp_clients,@nom_clients,@prenom_clients,@id_adresse,@contact_clients,@couriel_clients,@adhesion)";
                    MySqlCommand cmd = new MySqlCommand(query, maConnexion);
                    cmd.Parameters.Add(new MySqlParameter("@mdp_clients", tx_mdp.Password));
                    cmd.Parameters.Add(new MySqlParameter("@nom_clients", tx_nom.Text));
                    cmd.Parameters.Add(new MySqlParameter("@prenom_clients", tx_prenom.Text));
                    cmd.Parameters.Add(new MySqlParameter("@id_adresse", id));
                    cmd.Parameters.Add(new MySqlParameter("@contact_clients", tx_numTel.Text));
                    cmd.Parameters.Add(new MySqlParameter("@couriel_clients", tx_couriel.Text));
                    if(fidelio == true) { cmd.Parameters.Add(new MySqlParameter("@adhesion", true)); }
                    else { cmd.Parameters.Add(new MySqlParameter("@adhesion", false)); }
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    string query = "INSERT INTO clients(mdp_clients,nom_boutique,id_adresse,contact_clients,couriel_clients,adhesion) VALUES (@mdp_clients,@nom_boutique,@id_adresse,@contact_clients,@couriel_clients,@adhesion)";
                    MySqlCommand cmd = new MySqlCommand(query, maConnexion);
                    cmd.Parameters.Add(new MySqlParameter("@mdp_clients", tx_mdp.Password));
                    cmd.Parameters.Add(new MySqlParameter("@nom_boutique", tx_nom.Text));
                    cmd.Parameters.Add(new MySqlParameter("@id_adresse", id));
                    cmd.Parameters.Add(new MySqlParameter("@contact_clients", tx_numTel.Text));
                    cmd.Parameters.Add(new MySqlParameter("@couriel_clients", tx_couriel.Text));
                    cmd.Parameters.Add(new MySqlParameter("@adhesion", false));
                    cmd.ExecuteNonQuery();
                }
                
                maConnexion.Close();
            }
            catch (MySqlException msg)
            {
                MessageBox.Show("Erreur de connexion : " + msg.ToString());
                return;
            }
        }
        private void InsererAdhesion(int id_cli)
        {
            MySqlConnection maConnexion = null;
            DateTime thisDay = DateTime.Today;
            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                maConnexion = new MySqlConnection(connexionInfo);
                maConnexion.Open();
                string query = "INSERT INTO adhesion(id_fidelio,id_clients,date_adhesion,date_expiration) VALUES (@id_fidelio,@id_clients,@date_adhesion,@date_expiration)";
                MySqlCommand cmd = new MySqlCommand(query, maConnexion);
                cmd.Parameters.Add(new MySqlParameter("@id_fidelio", this.num_fidelio));
                cmd.Parameters.Add(new MySqlParameter("@id_clients", id_cli));
                cmd.Parameters.Add(new MySqlParameter("@date_adhesion", conversiondate(thisDay.ToString())));
                cmd.Parameters.Add(new MySqlParameter("@date_expiration", AddDate(conversiondate(thisDay.ToString()))));
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
            string[] ligne = dateBase.Split('/');
            string dateFinale = (Convert.ToInt32(ligne[0]) + this.duree).ToString();
            dateFinale += "/" + ligne[1] + "/" + ligne[2];
            return dateFinale;
        }
        #endregion
    }
}
