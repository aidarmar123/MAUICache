using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasheApp.Models
{
    public static class DataManeger
    {
        public static readonly string WeatherImportPath = "wether.json";
        public static string WeathCashePath { get => Path.Combine(FileSystem.Current.AppDataDirectory, "file.json"); }
        public static List<Weather> WeatherList;
        public static List<Weather> Wethers
        {
            get
            {
                if (WeatherList == null)
                    WeatherList = GetData<List<Weather>>(WeathCashePath);
                return WeatherList;
            }
            set
            {
                WeatherList = value;
                SetData(WeathCashePath, WeatherList);
            }
        }

        private static void SetData<T>(string weathCashePath, T weatherList)
        {
            var jsonData = JsonConvert.SerializeObject(weatherList);
            File.WriteAllText(weathCashePath, jsonData);
        }

        private static T GetData<T>(string weathCashePath)
        {
            var data = JsonConvert.DeserializeObject<T>(File.ReadAllText(WeathCashePath));
            return data;
        }

        internal static async void InitDataFile(string output, string source)
        {
            if (!File.Exists(output))
            {
                var file = File.Create(output);
                file.Close();
                File.WriteAllText(output, await ReadAsset(source));
            }
        }

        private static async Task<string> ReadAsset(string source)
        {
            using (var stream = await FileSystem.OpenAppPackageFileAsync(source))
            {
                using(var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
