using Newtonsoft.Json;

namespace Homeworld.External.OpenWeather
{
  public class WeatherDescription
  {
    [JsonProperty("main")]
    public string Main { get; set; }
    [JsonProperty("description")]
    public string Description { get; set; }
    [JsonProperty("icon")]
    public string IconCode { get; set; }
  }
}
