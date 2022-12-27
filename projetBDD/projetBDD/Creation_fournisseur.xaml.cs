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
    /// Logique d'interaction pour Creation_fournisseur.xaml
    /// </summary>
    public partial class Creation_fournisseur : Window
    {
        public Creation_fournisseur()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }
        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void bt_retour_Click(object sender, RoutedEventArgs e)
        {
            Gerer_fournisseur fenetre = new Gerer_fournisseur();
            fenetre.Show();
            this.Hide();
        }

        private void bt_exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Verif_Fournisseur() == true)
            {
                InsererAdresse();
                int id = Trouver_IDadresse();
                InsererFournisseur(id);
            }
        }
        #region methode de verif
        private bool Verif_Fournisseur()
        {
            bool verif = true;
            if (Verif_Mdp() == false) { MessageBox.Show("Mot de passe incorrect"); verif = false; }
            if (tx_nonEntreprise.Text == "") { MessageBox.Show("Veuillez saisir le nom de la société"); verif = false; }
            if (tx_rue.Text == "" || tx_ville.Text == "" || tx_province.Text == "" || tx_CP.Text == "") { MessageBox.Show("Veuillez saisir une adresse postale"); verif = false; }
            if (tx_numTel.Text == "") { MessageBox.Show("Veuillez saisir un numero de téléphone"); verif = false; }
            if (tx_couriel.Text == "") { MessageBox.Show("Veuillez saisir une adresse mail"); verif = false; }
            return verif;
        }
        private bool Verif_Mdp()
        {
            bool verif;
            if (tx_mdp.Password.ToString() == tx_mdpConfir.Password.ToString()) { verif = true; }
            else { verif = false; }
            return verif;
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
        private void InsererFournisseur(int id)
        {
            MySqlConnection maConnexion = null;
            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                maConnexion = new MySqlConnection(connexionInfo);
                maConnexion.Open();
                string query = "INSERT INTO fournisseur(id_adresse,nom_entreprise,contact_fournisseur) VALUES (@id_adresse,@nom_entreprise,@contact_fournisseur)";
                MySqlCommand cmd = new MySqlCommand(query, maConnexion);
                cmd.Parameters.Add(new MySqlParameter("@id_adresse", id));
                cmd.Parameters.Add(new MySqlParameter("@nom_entreprise", tx_nonEntreprise.Text));
                cmd.Parameters.Add(new MySqlParameter("@contact_fournisseur", tx_numTel.Text));
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
    }
}
