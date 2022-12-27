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
    /// Logique d'interaction pour Maj_fidelio.xaml
    /// </summary>
    public partial class Maj_fidelio : Window
    {
        private int id_cli = 0;
        private int num_fidelio;
        private int duree;
        public int Duree
        {
            get { return duree; }
        }
        public int Num_fildelio
        {
            get { return this.num_fidelio; }
        }
        public int Id_cli
        {
            get { return id_cli; }
        }
        public Maj_fidelio(int id)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.id_cli = id;
        }
        #region insertion
        private void Trouver_IDclients()
        {
            MySqlConnection maConnexion = null;

            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                maConnexion = new MySqlConnection(connexionInfo);
                string query = "UPDATE clients SET adhesion = true WHERE id_clients =" + this.id_cli +";";
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
        private bool Verif_Adhesion()
        {
            bool bon = false;
            if (ck_normal.IsChecked == true && ck_or.IsChecked == false && ck_platine.IsChecked == false && ck_max.IsChecked == false) { bon = true; this.num_fidelio = 1; this.duree = 1; }
            else if (ck_normal.IsChecked == false && ck_or.IsChecked == true && ck_platine.IsChecked == false && ck_max.IsChecked == false) { bon = true; this.num_fidelio = 2; this.duree = 2; }
            else if (ck_normal.IsChecked == false && ck_or.IsChecked == false && ck_platine.IsChecked == true && ck_max.IsChecked == false) { bon = true; this.num_fidelio = 3; this.duree = 2; }
            else if (ck_normal.IsChecked == false && ck_or.IsChecked == false && ck_platine.IsChecked == false && ck_max.IsChecked == true) { bon = true; this.num_fidelio = 4; this.duree = 3; }
            return bon;
        }
        private void InsererAdhesion()
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
                cmd.Parameters.Add(new MySqlParameter("@id_clients", this.id_cli));
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
            string [] ligne = dateBase.Split('/');
            string dateFinale = (Convert.ToInt32(ligne[0]) + this.duree).ToString();
            dateFinale += "/" + ligne[1] + "/" + ligne[2];
            return dateFinale;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Verif_Adhesion() == true)
            {
                InsererAdhesion();
                MessageBox.Show("Insertion reussie!");
            }
            else { MessageBox.Show("Fidélio non souscrit"); }
        }

        private void bt_exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void bt_retour_Click(object sender, RoutedEventArgs e)
        {
            Gestion_clients c = new Gestion_clients();
            c.Show();
            this.Hide();
        }
    }
}
