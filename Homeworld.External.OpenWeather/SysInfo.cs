using Newtonsoft.Json;

namespace Homeworld.External.OpenWeather
{
  public class SysInfo
  {
    [JsonProperty("country")]
    public string CountryCode { get; set; }

    [JsonProperty("sunrise")]
    public int Sunrise { get; set; }

    [JsonProperty("sunset")]
    public int SunSet { get; set; }

  }
}
