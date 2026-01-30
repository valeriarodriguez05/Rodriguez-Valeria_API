using Newtonsoft.Json;
using Rodriguez_Valeria_API.Models;
using Rodriguez_Valeria_API.Views;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Rodriguez_Valeria_API
{

    public partial class MainWindow : Window
    {
        public string Ville = "annecy";

        public MainWindow()
        {
            InitializeComponent();
            ChargerMeteoPage();
        }

        private void ChargerMeteoPage()
        {
            Grd_Container.Children.Clear();
            Meteo_Page meteopage = new Meteo_Page(Ville); // Passe la ville au constructeur
            Grd_Container.Children.Add(meteopage);
        }

        private void TB_Ville_TextChanged(object sender, TextChangedEventArgs e)
        {
            TB_Placeholder.Visibility = string.IsNullOrWhiteSpace(TB_City.Text)
                ? Visibility.Visible
                : Visibility.Hidden;
        }

        private void Btn_AjouterVille_Click(object sender, RoutedEventArgs e)
        {
            string ville = TB_City.Text.Trim();

            if (string.IsNullOrWhiteSpace(ville))
                return;

            if (!CB_Villes.Items.Contains(ville))
            {
                CB_Villes.Items.Add(ville);
            }

            CB_Villes.SelectedItem = ville;
            TB_City.Clear();
        }

        private void CB_Villes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CB_Villes.SelectedItem != null)
            {
                Ville = CB_Villes.SelectedItem.ToString(); // ← MET À JOUR la variable

                // Sauvegarde (optionnel)
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings.Remove("City");
                configuration.AppSettings.Settings.Add("City", Ville);
                configuration.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");

                // Recharge la page météo avec la nouvelle ville
                ChargerMeteoPage();
            }
        }
    }

}