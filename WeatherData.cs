using Newtonsoft.Json;

public class WeatherData
{
    [JsonProperty("temperature")]
    public double Temperature { get; set; }

    [JsonProperty("windspeed")]
    public double WindSpeed { get; set; }
}
