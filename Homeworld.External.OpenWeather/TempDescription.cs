using Newtonsoft.Json;

namespace Homeworld.External.OpenWeather
{
  public class TempDescription
  {
    [JsonProperty("temp")]
    public decimal Temp { get; set; }
    [JsonProperty("temp_min")]
    public decimal TempMinimum { get; set; }
    [JsonProperty("temp_max")]
    public decimal TempMaximum { get; set; }
    [JsonProperty("pressure")]
    public decimal Pressure { get; set; }
    [JsonProperty("humidity")]
    public decimal Humidity { get; set; }
  }
}
