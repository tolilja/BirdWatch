// ----------------------------------------------------------------------------
// <copyright file="BirdWatchService.asmx.cs" company="N/A">
// <![CDATA[
//      This file is part of BirdWatch web server-client programming example.
//      Project is open and does not hold copyright.
//      Contact: Tommi Lilja <github@tietoparkki.fi>
// ]]>
// </copyright>
// ----------------------------------------------------------------------------
namespace BirdWatch
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Web.Script.Serialization;
    using System.Web.Services;

    /// <summary>
    /// This class implements the backend service for BirdWatch web application.
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class BirdWatchService : System.Web.Services.WebService
    {
        /// <summary>
        /// Retrieves all recorded bird types and observation counts.
        /// Data is read from data storage and returned as JSON string.
        /// </summary>
        [WebMethod]
        public void GetBirdWatchData()
        {
            List<BirdWatchItem> birdList = BirdWatchDataFile.Read();

            JavaScriptSerializer jsonString = new JavaScriptSerializer();
            Context.Response.Write(jsonString.Serialize(birdList));
        }

        /// <summary>
        /// Increments the observation count for the specified bird.
        /// Writes new count to the data storage.
        /// Appends event to the log file.
        /// </summary>
        /// <param name="birdName">The name of the bird for new observation.</param>
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

        /// <summary>
        /// Adds new bird type to the data storage.
        /// Appends event to the log file.
        /// </summary>
        /// <param name="birdName">The name of the bird for new observation.</param>
        /// <returns>
        /// The bird name validation status.
        /// </returns>
        [WebMethod]
        public string AddNewBirdItem(string birdName)
        {
            List<BirdWatchItem> birdList = BirdWatchDataFile.Read();
            JavaScriptSerializer jsonStream = new JavaScriptSerializer();

            // Validate
            if (string.IsNullOrEmpty(birdName) || !Regex.IsMatch(birdName, @"^[a-öA-Ö]+$"))
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
            return string.Empty;
        }

        /// <summary>
        /// Retrieves all recorded bird log events without count information.
        /// </summary>
        [WebMethod]
        public void GetBirdObservationReport()
        {
            List<string> observationList = BirdWatchLogFile.ReadObservations();

            JavaScriptSerializer jsonStream = new JavaScriptSerializer();
            Context.Response.Write(jsonStream.Serialize(observationList));
        }
    }
}
