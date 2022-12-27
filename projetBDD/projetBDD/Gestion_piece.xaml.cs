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
    /// Logique d'interaction pour Gestion_piece.xaml
    /// </summary>
    public partial class Gestion_piece : Window
    {
        public Gestion_piece()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        static void AfficheGrille(DataGrid dgPiece, string requete)
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
                dgPiece.ItemsSource = dtbl.DefaultView;

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

            string selection = "";
            if (tbnom_piece.Text == "" && tbid_siret.Text == "")
            {
                selection = "SELECT * FROM piece";
            }
            else
            {
                if (tbnom_piece.Text == "" && tbid_siret.Text != "")
                {
                    selection = "SELECT * FROM piece WHERE id_siret =" + tbid_siret.Text + ";";
                }
                if (tbnom_piece.Text != "" && tbid_siret.Text == "")
                {
                    selection = "SELECT * FROM piece WHERE nom_piece = '" + tbnom_piece.Text + "';";
                }
                if (tbnom_piece.Text != "" && tbid_siret.Text != "")
                {
                    selection = "SELECT * FROM piece WHERE id_siret =" + tbid_siret.Text + " AND nom_piece = '" + tbnom_piece.Text + "';";
                }
            }
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

            string suppression = "DELETE FROM piece WHERE id_piece=@id_piece;";
            MySqlCommand command3 = maConnexion.CreateCommand();
            command3.CommandText = suppression;
            command3.Parameters.AddWithValue("@id_piece", Convert.ToString(lsid_piece.Text));
            MySqlDataReader exeRequete = command3.ExecuteReader();
            MessageBox.Show("suppression réussie");

            if (dgPiece != null && dgPiece.SelectedItems != null && dgPiece.SelectedItems.Count == 1)
            {
                DataGridRow dgr = dgPiece.ItemContainerGenerator.ContainerFromItem(dgPiece.SelectedItem) as DataGridRow;
                dgr.IsSelected = false;
            }
            AfficheGrille(dgPiece, "SELECT * FROM piece;");
            dgPiece.IsReadOnly = true;

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
            string maj = "UPDATE piece SET id_piece = @id_piece, id_siret = @id_siret, num_pieceFournisseur = @num_pieceFournisseur, prix_piece = @prix_piece, description_piece = @description_piece, delai_piece = @delai_piece, stock_piece = @stock_piece WHERE id_piece = @id_piece;";
            MySqlCommand command1 = maConnexion.CreateCommand();
            command1.CommandText = maj;
            command1.Parameters.AddWithValue("@id_velo", Convert.ToString(lsid_piece.Text));
            command1.Parameters.AddWithValue("@id_siret", lsid_siret.Text);
            command1.Parameters.AddWithValue("@num_pieceFournisseur", lsnum_pieceFournisseur.Text);
            command1.Parameters.AddWithValue("@prix_piece", lsprix_piece.Text);
            command1.Parameters.AddWithValue("@description_piece", lsdescription.Text);
            command1.Parameters.AddWithValue("@delai_piece", lsdelai.Text);
            command1.Parameters.AddWithValue("@stock_piece", lsstock_piece.Text);
            MySqlDataReader exeRequete = command1.ExecuteReader();
            MessageBox.Show("mise à jour réussie", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            #endregion
            if (dgPiece != null && dgPiece.SelectedItems != null && dgPiece.SelectedItems.Count == 1)
            {
                DataGridRow dgr = dgPiece.ItemContainerGenerator.ContainerFromItem(dgPiece.SelectedItem) as DataGridRow;
                dgr.IsSelected = false;
            }

            AfficheGrille(dgPiece, "SELECT * FROM piece;");
            dgPiece.IsReadOnly = true;

            maConnexion.Close();
        }

        private void dgPiece_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = dgPiece.SelectedItem;
            try
            {
                lsid_piece.Text = (dgPiece.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                lsid_siret.Text = (dgPiece.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                lsnum_pieceFournisseur.Text = (dgPiece.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                lsprix_piece.Text = (dgPiece.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
                lsdescription.Text = (dgPiece.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text;
                lsdelai.Text = (dgPiece.SelectedCells[9].Column.GetCellContent(item) as TextBlock).Text;
                lsstock_piece.Text = (dgPiece.SelectedCells[10].Column.GetCellContent(item) as TextBlock).Text;
            }
            catch
            {
                lsid_piece.Text = "";
                lsnum_pieceFournisseur.Text = "";
                lsprix_piece.Text = "";
                lsdescription.Text = "";
                lsdelai.Text = "";
                lsstock_piece.Text = "";
            }
        }

        private void bt_exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void bt_retour_Click(object sender, RoutedEventArgs e)
        {
            Gerer_produits p = new Gerer_produits();
            p.Show();
            this.Hide();
        }
    }
}
