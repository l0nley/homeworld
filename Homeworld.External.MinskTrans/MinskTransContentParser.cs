using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Homeworld.External.MinskTrans
{
  public class MinskTransContentParser
  {
    public IEnumerable<BusStopInfo> ParseBusStops(TextReader stopReaded)
    {
      stopReaded.ReadLine(); // skipping first line with mapping
      string line;
      var result = new List<BusStopInfo>();
      while(string.IsNullOrEmpty(line = stopReaded.ReadLine()) == false)
      {
        var tokens = line.Split(';').ToArray();
        var busstop = new BusStopInfo();
        busstop.Id = SafeLong(tokens[0]);
        busstop.CityCode = SafeLong(tokens[1]);
        busstop.AreaCode = SafeLong(tokens[2]);
        busstop.StreetCode = SafeLong(tokens[3]);
        busstop.Name = tokens[4].Trim();
        busstop.Info = tokens[5].Trim();
        busstop.Longitude = SafeDecimal(tokens[6]);
        busstop.Latitude = SafeDecimal(tokens[7]);
        busstop.Stops = tokens[8].Split(',').Select(l => SafeLong(l)).ToArray();
        busstop.StopNum = tokens[9];
        // busstop.PikasCode = tokens[10];
        result.Add(busstop);
      }

      return result;
    }

    public IEnumerable<RouteInfo> ParseRoutes(TextReader routeReader)
    {
      routeReader.ReadLine(); // skipping first line with names
      string line;
      var result = new List<RouteInfo>();
      RouteInfo cached = null;
      while(string.IsNullOrEmpty(line = routeReader.ReadLine()) == false)
      {
        var tokens = line.Split(';').Select(l => l.Trim()).ToArray();
        var route = CreateOnCache(cached, tokens);
        cached = route;
        result.Add(route);
      }


      return result;
    }

    private RouteInfo CreateOnCache(RouteInfo cache, string[] line)
    {
      var result = new RouteInfo();

      if(cache != null)
      {
        result.Authority = cache.Authority;
        result.City = cache.City;
        result.Commercial = cache.Commercial;
        result.DateStart = cache.DateStart;
        result.Entry = cache.Entry;
        result.Operator = cache.Operator;
        result.PikasCode = cache.PikasCode;
        result.RouteId = cache.RouteId;
        result.RouteName = cache.RouteName;
        result.RouteNum = cache.RouteNum;
        result.RouteTag = cache.RouteTag;
        result.RouteType = cache.RouteType;
        result.SpecialDates = cache.SpecialDates;
        result.Transport = cache.Transport;
        result.ValidityPeriod = cache.ValidityPeriod;
        result.Weekdays = cache.Weekdays;
      }

      CopyIfNotEmpty(result, line[0], (a, b) => a.RouteNum = b);
      CopyIfNotEmpty(result, line[1], (a, b) => a.Authority = b);
      CopyIfNotEmpty(result, line[2], (a, b) => a.City = b);
      CopyIfNotEmpty(result, line[3], (a, b) => a.Transport = b);
      CopyIfNotEmpty(result, line[4], (a, b) => a.Operator = b);
      CopyIfNotEmpty(result, line[5], (a, b) => a.ValidityPeriod = b);
      CopyIfNotEmpty(result, line[6], (a, b) => a.SpecialDates = b);
      CopyIfNotEmpty(result, line[7], (a, b) => a.RouteTag = b);
      CopyIfNotEmpty(result, line[8], (a, b) => a.RouteType = b);
      CopyIfNotEmpty(result, line[9], (a, b) => a.Commercial = b);
      CopyIfNotEmpty(result, line[10], (a, b) => a.RouteName = b);
      CopyIfNotEmpty(result, line[11], (a, b) => a.Weekdays = b);
      CopyIfNotEmpty(result, line[12], (a, b) => a.RouteId = SafeLong(b));
      CopyIfNotEmpty(result, line[13], (a, b) => a.Entry = b);
      result.RouteStops = line[14].Split(',').Select(l => SafeLong(l)).ToArray();
      CopyIfNotEmpty(result, line[15], (a, b) => a.PikasCode = b);
      CopyIfNotEmpty(result, line[16], (a, b) => a.DateStart = b);

      return result;
    }

    private void CopyIfNotEmpty(RouteInfo info, string token, Action<RouteInfo, string> action)
    {
      if(string.IsNullOrEmpty(token))
      {
        return;
      };
      action(info,token);
    }

    private long SafeLong(string input)
    {
      var trimed = input.Trim();
      if (string.IsNullOrEmpty(trimed))
      {
        return 0;
      }
      var result = 0l;
      long.TryParse(trimed, out result);
      return result;
    }

    private decimal SafeDecimal(string input)
    {
      var trimed = input.Trim();
      if (string.IsNullOrEmpty(trimed))
      {
        return 0;
      }
      var result = 0m;
      decimal.TryParse(trimed, out result);
      return result;
    }
  }
}
