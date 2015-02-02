using Newtonsoft.Json;

namespace Homeworld.External.OpenWeather
{
  public class Wind
  {
    [JsonProperty("speed")]
    public decimal Speed { get; set; }
    [JsonProperty("deg")]
    public decimal Degree { get; set; }
  }

}
