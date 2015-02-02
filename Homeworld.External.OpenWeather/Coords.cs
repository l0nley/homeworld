using Newtonsoft.Json;

namespace Homeworld.External.OpenWeather
{
 
  public class Coords
  {
    [JsonProperty("lon")]
    public decimal Longitude { get; set; }

    [JsonProperty("lat")]
    public decimal Latitude { get; set; }
  }
}
