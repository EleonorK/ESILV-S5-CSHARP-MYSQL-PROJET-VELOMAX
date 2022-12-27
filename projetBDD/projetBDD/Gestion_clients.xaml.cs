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
    /// Logique d'interaction pour Gestion_clients.xaml
    /// </summary>
    public partial class Gestion_clients : Window
    {
        public Gestion_clients()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        static void AfficheGrille(DataGrid dgClients, string requete)
        {
            DataTable myDT = new DataTable();


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
                dgClients.ItemsSource = dtbl.DefaultView;
            }
            catch (MySqlException msg)
            {
                MessageBox.Show("Erreur de connexion : " + msg.ToString());
                return;
            }
            finally
            {
                maConnexion.Close();
            }
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

            //MessageBox.Show("cb select = " + chaine);

            string selection = "";
            #region selection

            if (tbnom_clients.Text == "" && tbprenom_clients.Text == "")
            {
                selection = "SELECT id_clients, nom_clients, prenom_clients, nom_boutique, id_adresse, contact_clients, couriel_clients, adhesion FROM clients";
            }

            if (tbnom_clients.Text != "" && tbprenom_clients.Text == "")
            {
                selection = "SELECT nom_clients, prenom_clients, nom_boutique ,id_adresse, contact_clients, couriel_clients, adhesion FROM clients WHERE nom_clients LIKE '" + tbnom_clients.Text + "%';";
            }
            if (tbnom_clients.Text == "" && tbprenom_clients.Text != "")
            {
                selection = "SELECT nom_clients, prenom_clients, nom_boutique, id_adresse, contact_clients, couriel_clients, adhesion FROM clients WHERE prenom_clients LIKE '" + tbprenom_clients.Text + "%';";
            }
            if (tbnom_clients.Text != "" && tbprenom_clients.Text != "")
            {
                selection = "SELECT nom_clients, prenom_clients, nom_boutique, id_adresse, contact_clients, couriel_clients, adhesion FROM clients WHERE nom_clients LIKE '" + tbnom_clients.Text + "%' AND prenom_clients LIKE '" + tbprenom_clients.Text + "%';";
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
                    ligne = ligne + exeRequete.GetValue(i).ToString();
                }
                tableau = tableau + ligne;
            }
            tableau = tableau.Replace(" ", "");
            exeRequete.Close();
            if (tableau != "")
            {
                //MessageBox.Show(tableau);
                AfficheGrille(dgClients, selection);
                dgClients.IsReadOnly = true;
            }
            else
            {
                MessageBox.Show("Aucun résultat");
            }
            #endregion
            maConnexion.Close();

        }

        private void dgClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = dgClients.SelectedItem;
            try
            {
                lsid_clients.Text = (dgClients.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                lsnom_clients.Text = (dgClients.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                lscontact_clients.Text = (dgClients.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
                if ((dgClients.SelectedCells[7].Column.GetCellContent(item) as CheckBox).IsChecked == true)
                {
                    lsadhesion.Text = "1";
                }
                else
                {
                    lsadhesion.Text = "0";
                }
            }
            catch
            {
                lsid_clients.Text = "";
                lsnom_clients.Text = "";
                lscontact_clients.Text = "";
                lsadhesion.Text = "";
            }
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
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
                Console.WriteLine("Erreur de connexion : " + msg.ToString());
                return;
            }
            #endregion

            #region suppression


            string suppression = "DELETE FROM clients WHERE id_clients=@id_clients;";
            MySqlCommand command3 = maConnexion.CreateCommand();
            command3.CommandText = suppression;
            command3.Parameters.AddWithValue("@id_clients", Convert.ToString(lsid_clients.Text));
            MySqlDataReader exeRequete = command3.ExecuteReader();
            MessageBox.Show("suppression réussie");


            #endregion
            maConnexion.Close();
        }

        private void MAJ_Click(object sender, RoutedEventArgs e)
        {
            //requete maj avec l'id_velo de la ligne selectionnée

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

            #region mise à jour
            string maj = "UPDATE clients SET contact_clients = @contact_clients, adhesion = @adhesion WHERE id_clients = @id_clients;";
            MySqlCommand command1 = maConnexion.CreateCommand();
            command1.CommandText = maj;
            command1.Parameters.AddWithValue("@contact_clients", Convert.ToString(lscontact_clients.Text));
            command1.Parameters.AddWithValue("@adhesion", lsadhesion.Text);
            command1.Parameters.AddWithValue("@id_clients", lsid_clients.Text);
            MySqlDataReader exeRequete = command1.ExecuteReader();
            MessageBox.Show("mise à jour réussie", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            #endregion
            if (dgClients != null && dgClients.SelectedItems != null && dgClients.SelectedItems.Count == 1)
            {
                DataGridRow dgr = dgClients.ItemContainerGenerator.ContainerFromItem(dgClients.SelectedItem) as DataGridRow;
                dgr.IsSelected = false;
            }
            AfficheGrille(dgClients, "SELECT id_clients, nom_clients, prenom_clients, nom_boutique, id_adresse, contact_clients, couriel_clients, adhesion FROM clients;");
            dgClients.IsReadOnly = true;

        }

        private void bt_exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void bt_retour_Click(object sender, RoutedEventArgs e)
        {
            Gerer_clients c = new Gerer_clients();
            c.Show();
            this.Hide();
        }

        private void MAJad_Click(object sender, RoutedEventArgs e)
        {
            Maj_fidelio f = new Maj_fidelio(Convert.ToInt32(lsid_clients.Text));
            f.Show();
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
                MySqlCommand command = new MySqlCommand("SELECT id_clients, nom_clients, prenom_clients, nom_boutique, id_adresse, contact_clients, couriel_clients, adhesion FROM clients;", connection);
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
                StreamWriter swXML = new StreamWriter(@"D:\Utilisateurs\Documents\A3\S6\BDD\projet\Clients.xml");
                swXML.WriteLine(strXML.ToString());
                swXML.Close();

                string strJson = GetJSON_FromDataTable(dtRetour);
                StreamWriter swJson = new StreamWriter(@"D:\Utilisateurs\Documents\A3\S6\BDD\projet\Clients.json");
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
