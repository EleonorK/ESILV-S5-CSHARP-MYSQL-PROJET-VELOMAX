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
    /// Logique d'interaction pour Gerer_Commande.xaml
    /// </summary>
    public partial class Gerer_Commande : Window
    {
        public Gerer_Commande()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void bt_exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void bt_retour_Click(object sender, RoutedEventArgs e)
        {
            Accueil a = new Accueil();
            a.Show();
            this.Hide();
        }

        private void bt_mesCmd_Click(object sender, RoutedEventArgs e)
        {
            VoirCommandes v = new VoirCommandes();
            v.Show();
            this.Hide();
        }

        private void bt_cmdClient1(object sender, RoutedEventArgs e)
        {
            Vente v = new Vente();
            v.Show();
            this.Hide();
        }

        private void bt_passeCmd1(object sender, RoutedEventArgs e)
        {
            CommandeGerant cmd = new CommandeGerant();
            cmd.Show();
            this.Hide();
        }

        private void bt_fairecmdClient_Click(object sender, RoutedEventArgs e)
        {
            CommandeClient c = new CommandeClient();
            c.Show();
            this.Hide();
        }

        internal void show()
        {
            throw new NotImplementedException();
        }
    }
}
