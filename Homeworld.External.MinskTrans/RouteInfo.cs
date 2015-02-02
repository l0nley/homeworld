using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeworld.External.MinskTrans
{
  public class RouteInfo
  {
    public string RouteNum { get; set; }

    public string Authority { get; set; }

    public string City { get; set; }

    public string Transport { get; set; }

    public string Operator { get; set; }

    public string ValidityPeriod { get; set; }

    public string SpecialDates { get; set; }

    public string RouteTag { get; set; }

    public string RouteType { get; set; }

    public string Commercial { get; set; }

    public string RouteName { get; set; }

    public string Weekdays { get; set; }

    public long RouteId { get; set; }

    public string Entry { get; set; }

    public long[] RouteStops { get; set; }
    public string PikasCode { get; set; }

    public string DateStart { get; set; }
  }
}
