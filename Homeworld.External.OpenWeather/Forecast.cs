using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using Newtonsoft.Json.Linq;

namespace Homeworld.External.OpenWeather
{
  public class Forecast
  {
    public Dictionary<string, decimal> Forecasts { get; set; }

    public Forecast()
    {
      Forecasts = new Dictionary<string, decimal>();
    }
  }

  public class ForecastConverter : JsonConverter
  {
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
      var obj = JObject.Load(reader);
      var target = Activator.CreateInstance(objectType) as Forecast;
      target.Forecasts = new Dictionary<string, decimal>();
      foreach(var prop in obj.Properties())
      {
        target.Forecasts.Add(prop.Name, Decimal.Parse(prop.Value.ToString()));
      }

      return target;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      throw new NotImplementedException();
    }

    public override bool CanConvert(Type objectType)
    {
      return objectType.IsSubclassOf(typeof(Forecast));
    }
  }

}
