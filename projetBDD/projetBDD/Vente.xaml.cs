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
    /// Logique d'interaction pour Vente.xaml
    /// </summary>
    public partial class Vente : Window
    {
        public Vente()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
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

        private void Button_Click(object sender, RoutedEventArgs e)
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
                Console.WriteLine("Erreur de connexion : " + msg.ToString());
                return;
            }
            #endregion

            string selection = "SELECT id_commande, date_commande, date_livraison FROM commande";

            #region selection


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
                //MessageBox.Show(tableau);
                AfficheGrille(dgVente, selection);
                dgVente.IsReadOnly = true;
            }
            else
            {
                MessageBox.Show("Aucun résultat");
            }
            #endregion
            maConnexion.Close();

        }

        private void bt_retour_Click(object sender, RoutedEventArgs e)
        {
            Gerer_Commande c = new Gerer_Commande();
            c.Show();
            this.Hide();
        }

        private void bt_exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
