using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace Homeworld.External.OpenWeather
{
  public class OpenWeatherClient
  {
    public static string ApiVersion { get; set; }
    public static string ApiUri { get; set; }

    static OpenWeatherClient()
    {
      ApiVersion = "2.5";
      ApiUri = "http://api.openweathermap.org/data/";
    }

    private string GetApiUrl
    {
      get
      {
        return ApiUri + ApiVersion;
      }
    }

    public WeatherInfo GetCityWheather(string id)
    {
      var url = GetApiUrl + "/weather?id=" + id;
      var request = WebRequest.Create(url);
      try
      {
        var response = request.GetResponse();
        using (var stream = response.GetResponseStream())
        {
          using (TextReader reader = new StreamReader(stream))
          {
            using (var jreader = new JsonTextReader(reader))
            {
              var serializer = JsonSerializer.Create();
              return serializer.Deserialize<WeatherInfo>(jreader);
            }
          }
        }
      }
      catch(Exception e)
      {
        Debug.WriteLine(e.Message);
        return null;
      }
    }

    public WeatherInfo GetCityWheather(string cityName, string countryCode)
    {
      var url = GetApiUrl + "/weather?q=" + cityName+","+countryCode;
      var request = WebRequest.Create(url);
      try
      {
        var response = request.GetResponse();
        using (var stream = response.GetResponseStream())
        {
          using (TextReader reader = new StreamReader(stream))
          {
            using (var jreader = new JsonTextReader(reader))
            {
              var serializer = JsonSerializer.Create();
              return serializer.Deserialize<WeatherInfo>(jreader);
            }
          }
        }
        response.Close();
      }
      catch (Exception e)
      {
        Debug.WriteLine(e.Message);
        return null;
      }
    }
  }
}
