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
        BirdWatchData birdWatchData;

        [WebMethod]
        public void GetBirdWatchData()
        {
            birdWatchData = BirdWatchDataFile.ReadBirdDataFile();

            JavaScriptSerializer jsonStream = new JavaScriptSerializer();
            Context.Response.Write(jsonStream.Serialize(birdWatchData.GetBirdItemList()));
        }

        [WebMethod]
        public void AddNewBirdItem(string newBirdName)
        {
            if(birdWatchData.AddNewBirdItem(newBirdName))
            {
                // add writer and UI refresh
            }
            else
            {
                // add handling for duplicates
            }
        }
    }
}
