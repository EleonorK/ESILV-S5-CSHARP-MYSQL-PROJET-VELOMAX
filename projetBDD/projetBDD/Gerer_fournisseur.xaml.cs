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

namespace projetBDD
{
    /// <summary>
    /// Logique d'interaction pour Gerer_fournisseur.xaml
    /// </summary>
    public partial class Gerer_fournisseur : Window
    {
        public Gerer_fournisseur()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void bt_retour_Click(object sender, RoutedEventArgs e)
        {
            Accueil fenetre = new Accueil();
            fenetre.Show();
            this.Hide();
        }

        private void bt_exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void bt_nvxFournisseur_Click(object sender, RoutedEventArgs e)
        {
            Creation_fournisseur fenetre = new Creation_fournisseur();
            fenetre.Show();
            this.Hide();
        }

        private void bt_searchFournisseur_Click(object sender, RoutedEventArgs e)
        {
            GestionFournisseur f = new GestionFournisseur();
            f.Show();
            this.Hide();

        }
    }
}
