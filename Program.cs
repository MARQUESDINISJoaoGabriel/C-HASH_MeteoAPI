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
        Console.Write("Selection: ");
        string userChoice = Console.ReadLine();
        
        if (userChoice == "1") {
            Console.WriteLine(clear+"-- Insérez vos coordonnées (LAT°/LON°) --");
            System.Threading.Thread.Sleep(200);

            Console.Write("Insérez la Latitude (ex: 40.4040): ");
            string customLat = Console.ReadLine();
            Console.Write("Insérez la Longitude (ex: 40.4040): ");
            string customLong = Console.ReadLine();
            
            Console.WriteLine(clear);
            await APIcall(client, customLat, customLong);
            Environment.Exit(0);
        } else if (userChoice == "2") {
            await ListSelect(client);

        } else if (userChoice == "3"){
            Console.WriteLine(clear+"Choix 3");

            Environment.Exit(0);
        } else if (userChoice == "4"){
            Console.WriteLine(clear+"A bientot...");
            System.Threading.Thread.Sleep(2000);

            Console.WriteLine(clear);
            Environment.Exit(0);
        } else {
            Console.WriteLine("ERR. Le choix n'est soit pas un nombre soit en dehors des choix.");
            System.Threading.Thread.Sleep(1400);
            Main();
        }
    }

    static async Task APIcall(HttpClient client, string latitude, string longitude)
        {
            string clear = "\e[1;1H\e[2J";
            string urlCustom = "https://api.open-meteo.com/v1/forecast?latitude="+latitude+"&longitude="+longitude+"&current_weather=true&hourly=precipitation,cloudcover,is_day&timezone=auto";

            try
            {
                
                string response = await client.GetStringAsync(urlCustom);
                WeatherApiResponse data = Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherApiResponse>(response);

                var weather = data.CurrentWeather;
                var hourly = data.Hourly;

                weather.Precipitation = hourly.Precipitation[0];
                weather.CloudCover = hourly.CloudCover[0];

                Console.WriteLine("COORDONNÉES -- \n⬆ ["+latitude+"] ➡ ["+longitude+"]\n========================\n"+$"🌡 Température : {weather.Temperature}°C\n-> Vent : {weather.WindSpeed} km/h\n{weather.TimeOfDay}\n🌧 Pluies : {weather.Precipitation} mm\n☁ Nuages: {weather.CloudCover}%");

                System.Threading.Thread.Sleep(250);
                Console.WriteLine(" \n \nMenu Principal ? (y/n)");
                string userChoice = Console.ReadLine();
                if (userChoice == "y"){
                    Console.WriteLine(clear);
                    await Main();
                } else if (userChoice == "n"){
                    Console.WriteLine(clear);
                } else {
                    Console.WriteLine("ERR. "+userChoice+" n'est pas une option dans (y/n)");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
            }
        }


    static async Task ListSelect(HttpClient client){
        string clear = "\e[1;1H\e[2J";

        var cities = new Dictionary<string, (string lat, string lon, string ville, string pays)>
        {
            { "1", ("48.8566", "2.3522", "Paris", "France") }, 
            { "2", ("51.5074", "-0.1278", "Londres", "Grande-Bretagne") },
            { "3", ("38.7169", "-9.1399", "Lisbonne", "Portugal") },
            { "4", ("35.6528", "139.6500", "Tokyo", "Japon")},
            { "5", ("37.5503", "126.9971", "Seoul", "Corée du Sud")},
            { "6", ("47.4979", "19.0402", "Budapest", "Hongrie")},
            { "7", ("52.5200", "13.4050", "Berlin", "Allemagne")},
            { "8", ("40.4167", "-3.7033", "Madrid", "Espagne")},
            { "9", ("47.7511", "-120.7401", "Washington", "Etats-Unis d'Amérique (U.S.A.)")}
        };

        Console.Write(clear + "-- Choisissez dans la liste suivante ᯓ ✈︎ --");
        System.Threading.Thread.Sleep(200);
        Console.WriteLine("\n========================\n1.\tParis, France.\n2.\tLondres, Grande-Bretagne \n3.\tLisbonne, Portugal\n4.\tTokyo, Japon\n5.\tSeoul, Corée du Sud\n6.\tBudapest, Hongrie\n7.\tBerlin, Allemagne\n8.\tMadrid, Espagne\n9.\tWashington, Etats-Unis d'Amérique (U.S.A.)\n10.\tQuitter.");
        Console.Write("Selection: ");
        string choix = Console.ReadLine();

        if (cities.ContainsKey(choix))
        {
            var (lat, lon, ville, pays) = cities[choix];
            Console.WriteLine(clear);
            Console.WriteLine($"𓊹 {ville}, {pays}\n");
            await APIcall(client, lat, lon);
        }
        else if (choix == "10")
        {
            Console.WriteLine(clear);
            await Main();
        }
        else
        {
            Console.WriteLine("Choix invalide.");
            await ListSelect(client);
        }
    }
}

