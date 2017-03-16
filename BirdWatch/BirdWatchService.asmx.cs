using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;

namespace BirdWatch
{
    /// <summary>
    /// Summary description for BirdWatchService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class BirdWatchService : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetBirdWatchData()
        {
            List<BirdWatchItem> birdList = BirdWatchDataFile.Read();

            JavaScriptSerializer jsonStream = new JavaScriptSerializer();
            Context.Response.Write(jsonStream.Serialize(birdList));
        }

        [WebMethod]
        public void IncrementBirdObservations(string birdName)
        {
            List<BirdWatchItem> birdList = BirdWatchDataFile.Read();

            for (int i = 0; i < birdList.Count; i++)
            {
                if (birdList[i].BirdName == birdName)
                {
                    birdList[i].IncrementBirdObservations();
                    break;
                }
            }

            BirdWatchLogFile.Write(birdName, birdList);
            BirdWatchDataFile.Write(birdList);
        }

        [WebMethod]
        public string AddNewBirdItem(string birdName)
        {
            List<BirdWatchItem> birdList = BirdWatchDataFile.Read();
            JavaScriptSerializer jsonStream = new JavaScriptSerializer();

            // Validate
            if(string.IsNullOrEmpty(birdName))
            {
                return "Virhe: virheellinen linnun nimi";
            }

            for (int i = 0; i < birdList.Count; i++)
            {
                if (birdList[i].BirdName == birdName)
                {
                    return "Virhe: yritit lisätä duplikaattia";
                }
            }

            birdList.Add(new BirdWatchItem(birdName, 0));
            BirdWatchLogFile.Write(birdName);
            BirdWatchDataFile.Write(birdList);
            return "OK: uusi laji lisätty";
        }

  
        [WebMethod]
        public void GetBirdObservationReport()
        {
            List<string> observationList = BirdWatchLogFile.ReadObservations();

            JavaScriptSerializer jsonStream = new JavaScriptSerializer();
            Context.Response.Write(jsonStream.Serialize(observationList));
        }
    }
}
