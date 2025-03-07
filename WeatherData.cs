using Newtonsoft.Json;
using System.Collections.Generic;

public class WeatherData
{
    [JsonProperty("temperature")]
    public double Temperature { get; set; }

    [JsonProperty("windspeed")]
    public double WindSpeed { get; set; }

    public string TimeOfDay => IsDay == 1 ? "✧ JOUR" : "☾ NUIT";

    public double Precipitation { get; set; }

    public int CloudCover { get; set; }

    [JsonProperty("is_day")]
    public int IsDay { get; set; }
}

public class WeatherApiResponse
{
    [JsonProperty("current_weather")]
    public WeatherData CurrentWeather { get; set; }

    [JsonProperty("hourly")]
    public HourlyData Hourly { get; set; }
}

public class HourlyData
{
    [JsonProperty("precipitation")]
    public List<double> Precipitation { get; set; }

    [JsonProperty("cloudcover")]
    public List<int> CloudCover { get; set; }

    [JsonProperty("is_day")]
    public List<int> IsDay { get; set; }
}
