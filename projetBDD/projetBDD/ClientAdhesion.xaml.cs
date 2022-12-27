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
using MySql.Data.MySqlClient;

namespace projetBDD
{
    /// <summary>
    /// Logique d'interaction pour ClientAdhesion.xaml
    /// </summary>
    public partial class ClientAdhesion : Window
    {
        public ClientAdhesion()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            cbFidelio.Items.Add("Fidélio");
            cbFidelio.Items.Add("Fidélio Or");
            cbFidelio.Items.Add("Fidélio Platine");
            cbFidelio.Items.Add("Fidélio Max");
            cbFidelio.Items.Add("Voir tous");
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
                Console.WriteLine("Erreur de connexion : " + msg.ToString());
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

        private string AdditionDate(string dateBase, int duree)
        {
            string[] ligne = dateBase.Split('-');
            string dateFinale = (Convert.ToInt32(ligne[0]) + duree).ToString();
            return dateFinale;
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
                Console.WriteLine("Erreur de connexion : " + msg.ToString());
                return;
            }
            string selection = "";
            #endregion
            if (cbFidelio.SelectedItem.ToString() == "Voir tous")
            {
                selection = "SELECT nom_clients, prenom_clients, F.description_fidelio, F.rabais, A.date_adhesion, A.date_expiration FROM clients C, adhesion A, fidelio F WHERE C.id_clients = A.id_clients AND A.id_fidelio = F.id_fidelio;";
            }
            else
            {
                selection = "SELECT nom_clients, prenom_clients, F.description_fidelio, F.rabais, A.date_adhesion, A.date_expiration FROM clients C, adhesion A, fidelio F WHERE C.id_clients = A.id_clients AND A.id_fidelio = F.id_fidelio AND F.description_fidelio = '" + cbFidelio.SelectedItem.ToString() + "';";
            }

            MySqlCommand command2 = maConnexion.CreateCommand();
            command2.CommandText = selection;
            MySqlDataReader exeRequete = command2.ExecuteReader();

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
                AfficheGrille(dgAdhesion, selection);
                dgAdhesion.IsReadOnly = true;
            }
            else
            {
                MessageBox.Show("Aucun résultat");
            }
            #endregion
            maConnexion.Close();
        }
        static string conversiondate(string chaine)
        {
            string date = chaine;
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
        private void date_Click(object sender, RoutedEventArgs e)
        {
            string date = "2021-01-12";
            int duree = 3;
            string dateFinale = AdditionDate(date, duree);
            MessageBox.Show(dateFinale);
        }

        private void bt_exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void bt_retour_Click(object sender, RoutedEventArgs e)
        {
            Statistiques s = new Statistiques();
            s.Show();
            this.Hide();
        }

        public static string GetXML_FromDataTable(DataTable dt)
        {
            StringBuilder strXML = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                strXML.Append("<Table>");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strXML.Append("<Row>");

                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        strXML.Append("<" + dt.Columns[j].ColumnName.ToString() + ">" + dt.Rows[i][j].ToString() + "</" + dt.Columns[j].ColumnName.ToString() + ">");
                    }

                    strXML.Append("</Row>");
                }
                strXML.Append("</Table>");
            }
            return strXML.ToString();
        }
        public static string GetJSON_FromDataTable(DataTable dt)
        {
            StringBuilder strJSON = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                strJSON.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strJSON.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        strJSON.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString() + "\"");

                        if (j < dt.Columns.Count - 1)
                        {
                            strJSON.Append(",");
                        }
                    }
                    strJSON.Append("}");
                    if (i != dt.Rows.Count - 1)
                    {
                        strJSON.Append(",");
                    }
                }
                strJSON.Append("]");
            }
            return strJSON.ToString();
        }

        private void Exports_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789");
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM adhesion;", connection);
                command.CommandType = CommandType.Text;
                command.Connection.Open();
                DataTable dtRetour = new DataTable("TEST");
                MySqlParameter Param = new MySqlParameter();
                MySqlDataAdapter daMessage = new MySqlDataAdapter(command);
                daMessage.Fill(dtRetour);
                if (dtRetour.Rows.Count == 0)

                {
                    MessageBox.Show("Erreur Param - Nb lignes lu 0");
                }
                string strXML = GetXML_FromDataTable(dtRetour);
                StreamWriter swXML = new StreamWriter(@"D:\Utilisateurs\Documents\A3\S6\BDD\projet\ClientsAdhesion.xml");
                swXML.WriteLine(strXML.ToString());
                swXML.Close();

                string strJson = GetJSON_FromDataTable(dtRetour);
                StreamWriter swJson = new StreamWriter(@"D:\Utilisateurs\Documents\A3\S6\BDD\projet\ClientsAdhesion.json");
                swJson.WriteLine(strJson.ToString());
                swJson.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur Param - " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
