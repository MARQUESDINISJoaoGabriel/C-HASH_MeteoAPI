using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

class Program
{
    static async Task Main()
    {
        using HttpClient client = new HttpClient();
        //BASE URL->>> string url = "https://api.open-meteo.com/v1/forecast?latitude=48.8566&longitude=2.3522&current_weather=true";

        string clear="\e[1;1H\e[2J";
        Console.WriteLine(clear+"❬ Bienvenue dans l'App Météo - C# ! ❭");
        System.Threading.Thread.Sleep(750);
        Console.WriteLine("-- Selectionnez une option --\n========================\n1.\t Ecrire ses propres lat/long.\n2.\t Selectionner à partir d'une liste\n3.\t Options.\n4.\t Quitter.");
        string userChoice = Console.ReadLine();
        
        
        if (userChoice == "1") {
            Console.WriteLine(clear+"Choix 1");

            Environment.Exit(0);
        } else if (userChoice == "2") {
            Console.WriteLine(clear+"Choix 2");

            Environment.Exit(0);
        } else if (userChoice == "3"){
            Console.WriteLine(clear+"Choix 3");

            Environment.Exit(0);
        } else if (userChoice == "4"){
            Console.WriteLine(clear+"A bientot...");
            System.Threading.Thread.Sleep(450);

            Console.WriteLine(clear);
            Environment.Exit(0);
        }
        else {
            Console.WriteLine("ERR. Le choix n'est soit pas un nombre soit en dehors des choix.");
            System.Threading.Thread.Sleep(1400);
            Main();
        }
        

        // TESTS CUSTOMLAT
        string customLat = "2.4864";
        string customLong = "37.8754";
        string urlCustom = "https://api.open-meteo.com/v1/forecast?latitude="+customLat+"&longitude="+customLong+"&current_weather=true&prettyprint=1";

        try
        {
            string response = await client.GetStringAsync(urlCustom);
            JObject data = JObject.Parse(response);
            
            WeatherData weather = data["current_weather"].ToObject<WeatherData>();
            File.WriteAllText("test.json", Convert.ToString(data));

            Console.WriteLine($"🌡 Température : {weather.Temperature}°C");
            Console.WriteLine($"-> Vent : {weather.WindSpeed} km/h");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur : {ex.Message}");
        }
    }
}
