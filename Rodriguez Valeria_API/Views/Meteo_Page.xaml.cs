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
        public string Ville = "annecy";
        public Meteo_Page()
        {
            InitializeComponent();
            InitializeComponent();
            // Récupère la ville entrée par l'utilisateur
            Ville = TB_Ville.Text;

            // Lance la récupération météo
            _ = GetMeteo(Ville);
        }

        public async Task<string> GetMeteo(string city)
        {
            HttpClient client = new HttpClient(); // Crée une instance de HttpClient
            HttpResponseMessage response = await client.GetAsync($"https://www.prevision-meteo.ch/services/json/{city}"); // Remplacez 'city' par la ville souhaitée    

            if (response.IsSuccessStatusCode) // Vérifie si la requête a réussi
            {
                var content = await response.Content.ReadAsStringAsync();

                Root root = JsonConvert.DeserializeObject<Root>(content);

                CurrentCondition currentCondition = root.current_condition;
                //jour1
                FcstDay0 fcstDay0 = root.fcst_day_0;
                //Jour2
                FcstDay1 fcstDay1 = root.fcst_day_1;
                FcstDay2 fcstDay2 = root.fcst_day_2;
                FcstDay3 fcstDay3 = root.fcst_day_3;
                FcstDay4 fcstDay4 = root.fcst_day_4;
                var Temp = currentCondition.tmp.ToString();
                var Humidity = currentCondition.humidity.ToString();
                var Temp_Tomorrow = root.fcst_day_1.tmax.ToString();
                var Temp_Day3 = root.fcst_day_2.tmax.ToString();
                var Temp_Day4 = root.fcst_day_3.tmax.ToString();
                var Temp_Day5 = root.fcst_day_4.tmax.ToString();

                var CityInfo = root.city_info;
                var temp_Min = root.fcst_day_0.tmin;
                var temp_Max = root.fcst_day_0.tmax;
                TB_Temp.Text = $"{Temp} °C";
                TB_Today.Text = $"{Temp} °C";
                TB_Tomorrow.Text = $"{Temp_Tomorrow} °C";
                TB_Temp_Day3.Text = $"{Temp_Day3} °C";
                TB_Temp_Day4.Text = $"{Temp_Day4} °C";
                TB_Temp_Day5.Text = $"{Temp_Day5} °C";

                //TB_Humidity.Text = $"Humidité: {Humidity} %";
                //TB_FeelsLike.Text = $"Ressenti: {feels_like} °C";
                //TB_Clouds.Text = $"Couverture nuageuse: {clouds} %";
                //TB_Low.Text = $"Temp minimale: {temp_Min} °C";
                //    TB_High.Text = $"Temp maximale: {temp_Max} °C";
                TB_Ville.Text = Ville;

                //   Root root = JsonConvert.DeserializeObject<Root>(content);

                return "";
            }
            else
            {
                var tt = "error";
            }
            return null;
        }

        private void Btn_Today_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Tomorrow_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Day3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Day4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Day5_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
