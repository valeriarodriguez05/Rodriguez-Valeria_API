using Newtonsoft.Json;
using Rodriguez_Valeria_API.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Net.Http;
using Newtonsoft.Json;


namespace Rodriguez_Valeria_API.Views
{
    /// <summary>
    /// Logique d'interaction pour Today.xaml
    /// </summary>
    //public partial class Today : Page
    //{
    //    public Today()
    //    {
    //        InitializeComponent();
    //        AfficherMeteo(MainWindow.MeteoData);
    //    }

    //    private void AfficherMeteo(Root meteoData)
    //    {
    //        Root meteoData = JsonConvert.DeserializeObject<Root>(json);
    //        var temperature = meteoData.current_condition.tmp;
    //        var currentHour = meteoData.fcst_day_0.hourly_data._12H00; // adapte selon l'heure

    //        TB_Temperature.Text = meteoData.current_condition.tmp + "°C";
    //        TB_Humidity.Text = meteoData.current_condition.humidity + " %";
    //        TB_Wind.Text = meteoData.current_condition.wnd_spd + " km/h";
    //        TB_WindGust.Text = "Rafales : " + meteoData.current_condition.wnd_gust + " km/h";
    //        TB_WindDirection.Text = "Direction : " + meteoData.current_condition.wnd_dir;

    //        TB_Precipitation.Text = currentHour.APCPsfc + " mm";
    //        TB_PrecipitationType.Text = currentHour.ISSNOW == 1 ? "Type : Neige ❄" : "Type : Pluie 🌧";

    //        string feelsLike = "--";
    //        if (currentHour.HUMIDEX != null && double.TryParse(currentHour.HUMIDEX.ToString(), out double humidex))
    //            feelsLike = Math.Round(humidex) + "°C";
    //        else if (currentHour.WNDCHILL2m != null && double.TryParse(currentHour.WNDCHILL2m.ToString(), out double windchill))
    //            feelsLike = Math.Round(windchill) + "°C";

    //        TB_FeelsLike.Text = feelsLike;
    //    }

    //}
}
