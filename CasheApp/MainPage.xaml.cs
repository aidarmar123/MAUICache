using CasheApp.Models;

namespace CasheApp
{
    public partial class MainPage : ContentPage
    {
       

        public MainPage()
        {
            InitializeComponent();
            Refresh();
        }

        private void Refresh()
        {
            CVWeather.ItemsSource = DataManeger.WeatherList;
        }
    }
}