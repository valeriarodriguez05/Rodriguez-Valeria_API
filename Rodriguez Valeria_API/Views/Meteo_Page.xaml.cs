using Newtonsoft.Json;
using Rodriguez_Valeria_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

using System.Net.Http;
using Newtonsoft.Json;
using Rodriguez_Valeria_API.Models;
using Rodriguez_Valeria_API.Views;

namespace Rodriguez_Valeria_API.Views
{
    public partial class Meteo_Page : UserControl
    {
        private static readonly HttpClient client = new HttpClient();
        private string ville = "annecy";

        public Meteo_Page(string ville)
        {
            InitializeComponent();
            this.ville = ville;
            _ = GetMeteo(ville);
        }

        public async Task GetMeteo(string city)
        {
            try
            {
                var response = await client.GetAsync($"https://www.prevision-meteo.ch/services/json/{city}");

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Erreur lors de la récupération des données pour {city}");
                    return;
                }

                var content = await response.Content.ReadAsStringAsync();
                var root = JsonConvert.DeserializeObject<Root>(content);

                // =====================
                // Données actuelles
                // =====================
                TB_Ville.Text = ville;
                var current = root.current_condition;

                // Température actuelle
                TB_Temp.Text = $"{current.tmp} °C";
                TB_Today.Text = $"{current.tmp} °C";

                // Température ressentie
                TB_FeelsLike.Text = $"{current.tmp} °C";

                // Humidité
                TB_Humidity.Text = $"{current.humidity} %";

                // Vent
                TB_Wind.Text = $"{current.wnd_spd} km/h";
                TB_WindGust.Text = $"Rafales : {current.wnd_gust} km/h";
                TB_WindDirection.Text = $"Direction : {current.wnd_dir}";

                // =====================
                // Précipitations (jour 0)
                // =====================
                var hourlyData = root.fcst_day_0.hourly_data;
                if (hourlyData != null && hourlyData._12H00 != null)
                {
                    TB_Precipitation.Text = $"{hourlyData._12H00.APCPsfc} mm";
                    TB_PrecipitationType.Text = hourlyData._12H00.ISSNOW == 1 ? "Neige" : "Pluie";
                }
                else
                {
                    TB_Precipitation.Text = "-- mm";
                    TB_PrecipitationType.Text = "Indisponible";
                }

                // =====================
                // Prévisions jours suivants
                // =====================
                TB_Tomorrow.Text = $"{root.fcst_day_1.tmax} °C";
                TB_Temp_Day3.Text = $"{root.fcst_day_2.tmax} °C";
                TB_Temp_Day4.Text = $"{root.fcst_day_3.tmax} °C";
                TB_Temp_Day5.Text = $"{root.fcst_day_4.tmax} °C";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ville = TB_Ville.Text;
            _ = GetMeteo(ville);
        }
    }
}
