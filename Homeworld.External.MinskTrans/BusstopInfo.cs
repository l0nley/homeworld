namespace Homeworld.External.MinskTrans
{
  public class BusStopInfo
  {
    public long Id { get; set; }

    public long CityCode { get; set; }

    public long AreaCode { get; set; }

    public long StreetCode { get; set; }

    public string Name { get; set; }

    public string Info { get; set; }

    public decimal Longitude { get; set; }
    public decimal Latitude { get; set; }

    public long[] Stops { get; set; }

    public string StopNum { get; set; }

    public string PikasCode { get; set; }
  }
}
