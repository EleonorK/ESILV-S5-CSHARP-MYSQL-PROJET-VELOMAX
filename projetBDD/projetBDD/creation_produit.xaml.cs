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
using System.Globalization;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace projetBDD
{
    /// <summary>
    /// Logique d'interaction pour creation_produit.xaml
    /// </summary>
    public partial class creation_produit : Window
    {
        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        public creation_produit()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            grid_piece.Visibility = Visibility.Hidden;
            grid_velo.Visibility = Visibility.Hidden;
            grid_original.Visibility=Visibility.Hidden;
            grid_choix.Visibility = Visibility.Visible;
            for (int i = 0; i<=200; i++)
            {
                cb_stock.Items.Add(i);
            }
            for (int i = 1000; i <= 1200; i++)
            {
                cb_numPieceFournisseur.Items.Add(i);
            }
        }
        private void bt_exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void bt_retour_Click(object sender, RoutedEventArgs e)
        {
            Gerer_produits fenetre = new Gerer_produits();
            fenetre.Show();
            this.Hide();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool verif = true;
            if (cb_produit.Text == "VELO")
            {
                if(verif == true)
                {
                    bool stock = Verif_stock();
                    bool prix = Verif_prix();
                    if (cb_grandeur.Text == "") { MessageBox.Show("veuillez saisir une grandeur"); verif = false; }
                    //if (tx_numProduit.Text == "") { MessageBox.Show("veuillez saisir l'id du produit"); verif = false; }
                    if (tx_nomVelo.Text == "") { MessageBox.Show("veuillez saisir le nom du velo"); verif = false; }
                    if (tx_ligneVelo.Text == "") { MessageBox.Show("veuillez saisir la ligne de velo"); verif = false; }
                    if (tx_dateDebut.Text == "") { MessageBox.Show("veuillez saisir une date de debut production "); verif = false; }
                    if (cb_stock.Text == "" || stock == false) { MessageBox.Show("veuillez saisir un stock"); verif = false; }
                    if (tx_prix.Text == "" || prix == false) { MessageBox.Show("veuillez saisir le prix du velo"); verif = false; }
                }
                if(verif == true)
                {
                    InsererVelo();
                    MessageBox.Show("Insertion Reussie !");
                    //FAIRE RENTRER DANS LA BDD
                }
            }
            else
            {
                if(verif == true)
                {
                    bool stock = Verif_stock();
                    bool prix = Verif_prix();
                    if (tx_numProduit.Text == "") { MessageBox.Show("veuillez saisir la référence"); }
                    if (tx_idSiret.Text == "") { MessageBox.Show("veuillez saisir votre identifiant"); }
                    if (cb_numPieceFournisseur.Text == "") { MessageBox.Show("veuillez saisir le numero de produit dans votre catalogue"); }
                    if (tx_prix.Text == "" || prix == false) { MessageBox.Show("veuillez saisir le prix de la piece"); }
                    if (tx_dateDebut.Text == "") { MessageBox.Show("veuillez saisir une date de debut production "); }
                    if (cb_stock.Text == "" || stock == false) { MessageBox.Show("veuillez saisir un stock"); }
                    if (tx_nomPiece.Text == "") { MessageBox.Show("Veuillez saisir un nom de piece"); }
                }
                if (verif == true)
                {
                    InsererPiece();
                    MessageBox.Show("Insertion Reussie !");
                }
            }
        }

        private void bt_verifProduit_Click(object sender, RoutedEventArgs e)
        {
            if (cb_produit.Text != "")
            {
                MessageBox.Show("produit defini");
                cb_produit.IsEnabled = false;
                bt_verifProduit.Visibility = Visibility.Hidden;
                if(cb_produit.Text == "VELO")
                {
                    grid_velo.Visibility = Visibility.Visible;
                    grid_original.Visibility = Visibility.Visible;
                    tx_nomPiece.Visibility = Visibility.Hidden;
                    tx_numProduit.Visibility = Visibility.Hidden;
                }
                if (cb_produit.Text == "PIECE")
                {
                    grid_piece.Visibility = Visibility.Visible;
                    grid_original.Visibility = Visibility.Visible;
                }
            }
            else
            {
                MessageBox.Show("Veuiller choisir le type");
            }
        }
        #region methodes de verification
        private bool Verif_stock()
        {
            try
            {
                int.Parse(cb_stock.Text);
                return true;
            }
            catch { return false; }
        }
        private bool Verif_prix()
        {
            try
            {
                float.Parse(tx_prix.Text);
                return true;
            }
            catch { return false; }
        }
        #endregion
        #region insertion
        private void InsererVelo()
        {
            MySqlConnection maConnexion =null;
            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                maConnexion = new MySqlConnection(connexionInfo);
                maConnexion.Open();
                string query = "INSERT INTO velo(nom_velo,prix_velo,grandeur,ligne_velo,dateDebut_velo,dateFin_velo,stock_velo) VALUES (@nom_velo,@prix_velo,@grandeur,@ligne_velo,@dateDebut_velo,@dateFin_velo,@stock_velo)";
                MySqlCommand cmd = new MySqlCommand(query, maConnexion);
                cmd.Parameters.Add(new MySqlParameter("@nom_velo", tx_nomVelo.Text));
                cmd.Parameters.Add(new MySqlParameter("@prix_velo", tx_prix.Text + "€"));
                cmd.Parameters.Add(new MySqlParameter("@grandeur", cb_grandeur.Text));
                cmd.Parameters.Add(new MySqlParameter("@ligne_velo", tx_ligneVelo.Text));
                cmd.Parameters.Add(new MySqlParameter("@dateDebut_velo", conversiondate(tx_dateDebut.Text)));
                cmd.Parameters.Add(new MySqlParameter("@dateFin_velo", conversiondate(tx_dateFin.Text)));
                cmd.Parameters.Add(new MySqlParameter("@stock_velo", cb_stock.Text));
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
            MySqlConnection maConnexion = null;
            try
            {
                string connexionInfo = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;UID=root;PASSWORD=123456789";
                maConnexion = new MySqlConnection(connexionInfo);
                maConnexion.Open();
                string query = "INSERT INTO piece(id_siret,nom_piece,ref,num_pieceFournisseur,prix_piece,description_piece,dateDebut_piece,dateFin_piece,delai_piece,stock_piece) VALUES (@id_siret,@nom_piece,@ref,@num_pieceFournisseur,@prix_piece,@description_piece,@dateDebut_piece,@dateFin_piece,@delai_piece,@stock_piece)";
                MySqlCommand cmd = new MySqlCommand(query, maConnexion);
                cmd.Parameters.Add(new MySqlParameter("@id_siret", tx_idSiret.Text));
                cmd.Parameters.Add(new MySqlParameter("@nom_piece", tx_nomPiece.Text));
                cmd.Parameters.Add(new MySqlParameter("@ref", tx_numProduit.Text));
                cmd.Parameters.Add(new MySqlParameter("@num_pieceFournisseur", cb_numPieceFournisseur.Text));
                cmd.Parameters.Add(new MySqlParameter("@prix_piece", tx_prix.Text+"€"));
                cmd.Parameters.Add(new MySqlParameter("@description_piece", tx_desPiece.Text));
                cmd.Parameters.Add(new MySqlParameter("@dateDebut_piece", conversiondate(tx_dateDebut.Text)));
                cmd.Parameters.Add(new MySqlParameter("@dateFin_piece", conversiondate(tx_dateFin.Text)));
                cmd.Parameters.Add(new MySqlParameter("@delai_piece", tx_delaiPiece.Text));
                cmd.Parameters.Add(new MySqlParameter("@stock_piece", cb_stock.Text));
                cmd.ExecuteNonQuery();
                maConnexion.Close();
            }
            catch (MySqlException msg)
            {
                MessageBox.Show("Erreur de connexion : " + msg.ToString());
                return;
            }
        }
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
        #endregion
    }

}
namespace MaterialDesignDemo.Domain
{
    public class NotEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return string.IsNullOrWhiteSpace((value ?? "").ToString())
                ? new ValidationResult(false, "Field is required.")
                : ValidationResult.ValidResult;
        }
    }
}
