using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeworld.External.MinskTrans
{
  public class TimeInfo
  {
    public void Decode2(string data)
    {
      // decoded_data = "495,600,-540,,12345,1,123457,1,6,,1,,3,,11,,11,,3,,1,,"; //
      var times = data.Split(',');
      var timetable = 
      for(var i=0;i<times.Length;i++)
      {
        var t = times[i];

      }
    }
  }
}
