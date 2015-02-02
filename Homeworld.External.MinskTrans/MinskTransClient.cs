using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace Homeworld.External.MinskTrans
{
  public class MinskTransClient
  {
    public static string ApiUri;

    static MinskTransClient()
    {
      ApiUri = "http://www.minsktrans.by/city/minsk/";
    }

    public IEnumerable<BusStopInfo> DownloadBusStops()
    {
      IEnumerable<BusStopInfo> result;
      var req = WebRequest.Create(ApiUri + "stops.txt");
      try
      {
        var resp = req.GetResponse();
        using (var stream = resp.GetResponseStream())
        {
          using (TextReader reader = new StreamReader(stream))
          {
            var parser = new MinskTransContentParser();
            result = parser.ParseBusStops(reader);
          }
        }
      }
      catch
      {
        result = Enumerable.Empty<BusStopInfo>();
      }

      return result;
    }

    public IEnumerable<RouteInfo> DownloadRoutes()
    {
      IEnumerable<RouteInfo> result;
      var req = WebRequest.Create(ApiUri + "routes.txt");
      try
      {
        var resp = req.GetResponse();
        using (var stream = resp.GetResponseStream())
        {
          using (TextReader reader = new StreamReader(stream))
          {
            var parser = new MinskTransContentParser();
            result = parser.ParseRoutes(reader);
          }
        }
      }
      catch
      {
        result = Enumerable.Empty<RouteInfo>();
      }

      return result;
    }
  }
}
