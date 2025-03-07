using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

class Program
{
    static async Task Main()
    {
        using HttpClient client = new HttpClient();
        string url = "https://api.open-meteo.com/v1/forecast?latitude=48.8566&longitude=2.3522&current_weather=true";

        // TESTS CUSTOMLAT
        string customLat = "2.4864";
        string customLong = "37.8754";
        string urlCustom = "https://api.open-meteo.com/v1/forecast?latitude="+customLat+"&longitude="+customLong+"&current_weather=true";

        try
        {
            string response = await client.GetStringAsync(urlCustom);
            JObject data = JObject.Parse(response);
            
            WeatherData weather = data["current_weather"].ToObject<WeatherData>();

            Console.WriteLine($"🌡 Température : {weather.Temperature}°C");
            Console.WriteLine($"-> Vent : {weather.WindSpeed} km/h");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur : {ex.Message}");
        }
    }
}
