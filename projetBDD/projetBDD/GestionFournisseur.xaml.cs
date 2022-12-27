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
    /// Logique d'interaction pour GestionFournisseur.xaml
    /// </summary>
    public partial class GestionFournisseur : Window
    {
        public GestionFournisseur()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            cbFournisseur.Items.Add("très bon");
            cbFournisseur.Items.Add("bon");
            cbFournisseur.Items.Add("moyen");
            cbFournisseur.Items.Add("mauvais");
            cbFournisseur.Items.Add("voir tous");
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
            if (cbFournisseur.SelectedItem.ToString() == "voir tous" || cbFournisseur.SelectedIndex == -1)
            {
                selection = "SELECT * FROM fournisseur";
            }
            else
            {
                selection = "SELECT * FROM fournisseur WHERE libelle_fournisseur = '" + cbFournisseur.SelectedItem.ToString() + "';";
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
                AfficheGrille(dgFournisseur, selection);
                dgFournisseur.IsReadOnly = true;
            }
            else
            {
                MessageBox.Show("Aucun résultat");
            }
            #endregion
            maConnexion.Close();
        }


        private void dgFournisseur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = dgFournisseur.SelectedItem;

            try
            {
                lsid_siret.Text = (dgFournisseur.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                lsid_adresse.Text = (dgFournisseur.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                lsnom_entreprise.Text = (dgFournisseur.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                lscontact_fournisseur.Text = (dgFournisseur.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                lslibelle_fournisseur.Text = (dgFournisseur.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
            }
            catch
            {
                lsid_siret.Text = "";
                lsid_adresse.Text = "";
                lsnom_entreprise.Text = "";
                lscontact_fournisseur.Text = "";
                lslibelle_fournisseur.Text = "";
            }
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
            string maj = "UPDATE fournisseur SET contact_fournisseur = @contact_fournisseur, libelle_fournisseur = @libelle_fournisseur WHERE id_siret = @id_siret;";
            MySqlCommand command1 = maConnexion.CreateCommand();
            command1.CommandText = maj;
            command1.Parameters.AddWithValue("@id_siret", lsid_siret.Text);
            command1.Parameters.AddWithValue("@contact_fournisseur", Convert.ToString(lscontact_fournisseur.Text));
            command1.Parameters.AddWithValue("@libelle_fournisseur", lslibelle_fournisseur.Text);
            MySqlDataReader exeRequete = command1.ExecuteReader();
            MessageBox.Show("mise à jour réussie", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            #endregion
            if (dgFournisseur != null && dgFournisseur.SelectedItems != null && dgFournisseur.SelectedItems.Count == 1)
            {
                DataGridRow dgr = dgFournisseur.ItemContainerGenerator.ContainerFromItem(dgFournisseur.SelectedItem) as DataGridRow;
                dgr.IsSelected = false;
            }


            AfficheGrille(dgFournisseur, "SELECT * FROM fournisseur;");
            dgFournisseur.IsReadOnly = true;

            maConnexion.Close();

        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            //requete suppression avec l'id_velo de la ligne selectionnée 

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

            string suppression = "DELETE FROM fournisseur WHERE id_siret=@id_siret;";
            MySqlCommand command3 = maConnexion.CreateCommand();
            command3.CommandText = suppression;
            command3.Parameters.AddWithValue("@id_siret", Convert.ToString(lsid_siret.Text));
            MySqlDataReader exeRequete = command3.ExecuteReader();
            MessageBox.Show("suppression réussie");

            if (dgFournisseur != null && dgFournisseur.SelectedItems != null && dgFournisseur.SelectedItems.Count == 1)
            {
                DataGridRow dgr = dgFournisseur.ItemContainerGenerator.ContainerFromItem(dgFournisseur.SelectedItem) as DataGridRow;
                dgr.IsSelected = false;
            }
            AfficheGrille(dgFournisseur, "SELECT * FROM fournisseur;");
            dgFournisseur.IsReadOnly = true;

            #endregion
            maConnexion.Close();

        }

        private void bt_retour_Click(object sender, RoutedEventArgs e)
        {
            Gerer_fournisseur f = new Gerer_fournisseur();
            f.Show();
            this.Hide();
        }

        private void bt_exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
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
                MySqlCommand command = new MySqlCommand("SELECT * FROM fournisseur;", connection);
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
                StreamWriter swXML = new StreamWriter(@"D:\Utilisateurs\Documents\A3\S6\BDD\projet\GestionFournisseur.xml");
                swXML.WriteLine(strXML.ToString());
                swXML.Close();

                string strJson = GetJSON_FromDataTable(dtRetour);
                StreamWriter swJson = new StreamWriter(@"D:\Utilisateurs\Documents\A3\S6\BDD\projet\GestionFournisseur.json");
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
