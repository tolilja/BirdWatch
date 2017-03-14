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
        public void GetBirdItem()
        {
            BirdItem birdItem = new BirdItem();
            birdItem.BirdName = "Test bird";
            birdItem.BirdCount = 0;

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(birdItem));
        }
    }
}
