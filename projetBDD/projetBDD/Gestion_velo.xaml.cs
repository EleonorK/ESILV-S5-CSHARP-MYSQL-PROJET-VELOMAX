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
    /// Logique d'interaction pour Gestion_velo.xaml
    /// </summary>
    public partial class Gestion_velo : Window
    {
        public Gestion_velo()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            cbligne_velo.Items.Add("VTT");
            cbligne_velo.Items.Add("Vélo de course");
            cbligne_velo.Items.Add("Classique");
            cbligne_velo.Items.Add("BMX");
            cbgrandeur.Items.Add("Adultes");
            cbgrandeur.Items.Add("Hommes");
            cbgrandeur.Items.Add("Dames");
            cbgrandeur.Items.Add("Jeunes");
            cbgrandeur.Items.Add("Garçons");
            cbgrandeur.Items.Add("Filles");
            Export.Visibility = Visibility.Hidden;
        }
        static void AfficheGrille(DataGrid dgVelo, string requete)
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
                dgVelo.ItemsSource = dtbl.DefaultView;

            }
            catch (MySqlException msg)
            {
                Console.WriteLine("Erreur de connexion : " + msg.ToString());

            }
            finally
            {
                maConnexion.Close();
            }
        }
        private void Rechercher_Click(object sender, RoutedEventArgs e)
        {
            lsid_velo.Text = "";
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

            string chaine = "";
            int compteur = 0;
            if (tbnom_velo.Text != "")
            {
                if (cbgrandeur.SelectedIndex == -1 && cbligne_velo.SelectedIndex == -1)
                {
                    chaine = "SELECT * FROM velo WHERE nom_velo = '" + tbnom_velo.Text + "';";
                }
                if (cbgrandeur.SelectedIndex != -1 && cbligne_velo.SelectedIndex == -1)
                {
                    chaine = "SELECT * FROM velo WHERE nom_velo = '" + tbnom_velo.Text + "' AND ";
                    compteur++;
                }
                if (cbgrandeur.SelectedIndex == -1 && cbligne_velo.SelectedIndex != -1)
                {
                    chaine = "SELECT * FROM velo WHERE nom_velo = '" + tbnom_velo.Text + "' AND ";
                }
                if (cbgrandeur.SelectedIndex != -1 && cbligne_velo.SelectedIndex != -1)
                {
                    chaine = "SELECT * FROM velo WHERE nom_velo = '" + tbnom_velo.Text + "' AND ";
                }
            }
            else
            {
                chaine = "SELECT * FROM velo WHERE ";
            }

            int combobox = 0;
            ComboBox[] tab = { cbligne_velo, cbgrandeur };
            for (int i = 0; i < tab.Length; i++)
            {
                if (tab[i].SelectedIndex != -1)// quelque chose selectionné
                {
                    if (i == 1)
                    {
                        if (compteur == 1) // ligne,grandeur et nom déjà remplis
                        {
                            chaine = chaine + Convert.ToString(tab[i].Name).Replace("cb", "") + " = '" + tab[i].SelectedItem.ToString() + "'";
                        }
                        else
                        {
                            if (combobox == 0)
                            {
                                chaine = chaine + Convert.ToString(tab[i].Name).Replace("cb", "") + " = '" + tab[i].SelectedItem.ToString() + "'";
                            }
                            else
                            {
                                chaine = chaine + " AND " + Convert.ToString(tab[i].Name).Replace("cb", "") + " = '" + tab[i].SelectedItem.ToString() + "'";
                            }

                        }
                    }
                    else
                    {
                        chaine = chaine + Convert.ToString(tab[i].Name).Replace("cb", "") + "= '" + tab[i].SelectedItem.ToString() + "'";
                    }
                    combobox++;
                }
            }
            chaine = chaine + ";";
            //MessageBox.Show("cb select = " + chaine);

            string selection = "";
            #region selection

            if (tbnom_velo.Text == "" && cbligne_velo.SelectedIndex == -1 && cbgrandeur.SelectedIndex == -1)
            {
                selection = "SELECT * FROM velo";
            }
            else
            {
                selection = chaine;
            }
            MessageBox.Show("selection ligne 164 = " + selection);

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
                AfficheGrille(dgVelo, selection);
                dgVelo.IsReadOnly = true;

                /*
                object item = dgVelo.SelectedItem;
                (dgVelo.SelectedCells[0].Column.GetCellContent(item) as TextBox).IsEnabled = false;
                */
            }
            else
            {
                MessageBox.Show("Aucun résultat");
            }
            #endregion
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

            string suppression = "DELETE FROM velo WHERE id_velo=@id_velo;";
            MySqlCommand command3 = maConnexion.CreateCommand();
            command3.CommandText = suppression;
            command3.Parameters.AddWithValue("@id_velo", Convert.ToString(lsid_velo.Text));
            MySqlDataReader exeRequete = command3.ExecuteReader();
            MessageBox.Show("suppression réussie");

            if (dgVelo != null && dgVelo.SelectedItems != null && dgVelo.SelectedItems.Count == 1)
            {
                DataGridRow dgr = dgVelo.ItemContainerGenerator.ContainerFromItem(dgVelo.SelectedItem) as DataGridRow;
                dgr.IsSelected = false;
            }
            AfficheGrille(dgVelo, "SELECT * FROM velo;");
            dgVelo.IsReadOnly = true;

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
            string maj = "UPDATE velo SET nom_velo = @nom_velo, prix_velo = @prix_velo, grandeur = @grandeur, ligne_velo = @ligne_velo, dateDebut_velo = @dateDebut_velo, dateFin_velo = @dateFin_velo, stock_velo = @stock_velo WHERE id_velo = @id_velo;";
            MySqlCommand command1 = maConnexion.CreateCommand();
            command1.CommandText = maj;
            command1.Parameters.AddWithValue("@id_velo", Convert.ToString(lsid_velo.Text));
            command1.Parameters.AddWithValue("@nom_velo", lsnom_velo.Text);
            command1.Parameters.AddWithValue("@prix_velo", lsprix_velo.Text);
            command1.Parameters.AddWithValue("@grandeur", lsgrandeur.Text);
            command1.Parameters.AddWithValue("@ligne_velo", lsligne_velo.Text);
            command1.Parameters.AddWithValue("@dateDebut_velo", lsdateDebut.Text);
            command1.Parameters.AddWithValue("@dateFin_velo", lsdateFin.Text);
            command1.Parameters.AddWithValue("@stock_velo", Convert.ToString(lsstock.Text));
            MySqlDataReader exeRequete = command1.ExecuteReader();
            MessageBox.Show("mise à jour réussie", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            #endregion
            if (dgVelo != null && dgVelo.SelectedItems != null && dgVelo.SelectedItems.Count == 1)
            {
                DataGridRow dgr = dgVelo.ItemContainerGenerator.ContainerFromItem(dgVelo.SelectedItem) as DataGridRow;
                dgr.IsSelected = false;
            }


            AfficheGrille(dgVelo, "SELECT * FROM velo;");
            dgVelo.IsReadOnly = true;

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
        private void dgVelo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = dgVelo.SelectedItem;
            //(dgVelo.SelectedCells[0].Column.GetCellContent(item) as TextBox).IsReadOnly = false;

            try
            {
                lsid_velo.Text = (dgVelo.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                lsnom_velo.Text = (dgVelo.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                lsprix_velo.Text = (dgVelo.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                lsgrandeur.Text = (dgVelo.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                lsligne_velo.Text = (dgVelo.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                lsdateDebut.Text = conversiondate((dgVelo.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text);
                lsdateFin.Text = conversiondate((dgVelo.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text);
                lsstock.Text = (dgVelo.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text;
            }
            catch
            {
                lsid_velo.Text = "";
                lsnom_velo.Text = "";
                lsprix_velo.Text = "";
                lsgrandeur.Text = "";
                lsligne_velo.Text = "";
                lsdateDebut.Text = "";
                lsdateFin.Text = "";
                lsstock.Text = "";
            }
        }
        private void VerifStock_Click(object sender, RoutedEventArgs e)
        {
            Export.Visibility = Visibility.Visible;
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

            string selection = "SELECT * FROM velo WHERE stock_velo<=2;";
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

        private void bt_exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void bt_retour_Click(object sender, RoutedEventArgs e)
        {
            Gerer_produits g = new Gerer_produits();
            g.Show();
            this.Hide();
        }

        private void Exports_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789");
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM velo WHERE stock_velo<=2;", connection);
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
                StreamWriter swXML = new StreamWriter(@"D:\Utilisateurs\Documents\A3\S6\BDD\projet\GestionVelos.xml");
                swXML.WriteLine(strXML.ToString());
                swXML.Close();

                string strJson = GetJSON_FromDataTable(dtRetour);
                StreamWriter swJson = new StreamWriter(@"D:\Utilisateurs\Documents\A3\S6\BDD\projet\GestionVelos.json");
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
