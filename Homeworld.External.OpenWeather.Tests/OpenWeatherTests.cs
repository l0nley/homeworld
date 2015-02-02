using Homeworld.External.MinskTrans;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Homeworld.External.OpenWeather.Tests
{
  [TestClass]
  public class OpenWeatherTests
  {
    public TestContext TestContext { get; set; }

    [TestMethod]
    public void TestCityById()
    {
      var client = new OpenWeatherClient();
      const string id = "625144";
      var weather = client.GetCityWheather(id);
      Assert.IsNotNull(weather);
    }


    [TestMethod]
    public void TestCityByCode()
    {
      var client = new OpenWeatherClient();
      const string id = "625144";
      var weather = client.GetCityWheather("Minsk","BY");
      Assert.IsNotNull(weather);
    }

    [TestMethod]
    public void TestParseStops()
    {
      var client = new MinskTransClient();
      var stops = client.DownloadBusStops();
      Assert.IsTrue(stops.Count() > 0);
    }

    [TestMethod]
    public void TestParseRoutes()
    {
      var client = new MinskTransClient();
      var routes = client.DownloadRoutes();
      Assert.IsTrue(routes.Count() > 0);
    }
  }
}
