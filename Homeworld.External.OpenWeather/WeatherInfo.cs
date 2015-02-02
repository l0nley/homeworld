using Newtonsoft.Json;
using System;

namespace Homeworld.External.OpenWeather
{
  public class WeatherInfo
  {
    [JsonProperty("coord")]
    public Coords Coordinates { get; set; }

    [JsonProperty("sys")]
    public SysInfo Sys { get; set; }

    public WeatherDescription[] Weather { get; set; }

    [JsonProperty("wind")]
    public Wind Wind { get; set; }

    [JsonProperty("main")]
    public TempDescription Temperature { get; set; }

    [JsonProperty("rain")]
    [JsonConverter(typeof(ForecastConverter))]
    public Forecast Rain { get; set; }

    [JsonProperty("snow")]
    [JsonConverter(typeof(ForecastConverter))]
    public Forecast Snow { get; set; }

    [JsonProperty("clouds")]
    [JsonConverter(typeof(ForecastConverter))]
    public Forecast Clouds { get; set; }

    [JsonProperty("name")]
    public string CityName { get; set; }

    [JsonProperty("id")]
    public string CityId { get; set; }

  }
}