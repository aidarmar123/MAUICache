using CasheApp.Models;

namespace CasheApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            DataManeger.InitDataFile(Path.Combine(FileSystem.Current.AppDataDirectory,"copy.json"),DataManeger.WeatherImportPath);
        }
    }
}