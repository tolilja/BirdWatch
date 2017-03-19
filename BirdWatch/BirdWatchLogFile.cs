// ----------------------------------------------------------------------------
// <copyright file="BirdWatchLogFile.cs" company="N/A">
// <![CDATA[
//      This file is part of BirdWatch web server-client programming example.
//      Project is open and does not hold copyright.
//      Contact: Tommi Lilja <github@tietoparkki.fi>
// ]]>
// </copyright>
// ----------------------------------------------------------------------------
namespace BirdWatch
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    /// <summary>
    /// This class implements BirdWatch logger.
    /// Log is simple text file.
    /// </summary>
    public class BirdWatchLogFile
    {
        /// <summary>
        /// Write new observation and the total count of all observations to the log file.
        /// </summary>
        /// <param name="birdName">The name of the bird for new observation.</param>
        /// <param name="birdList">The list of all birds and observation counts.</param>
        public static void Write(string birdName, List<BirdWatchItem> birdList)
        {
            try
            {
                // Open the log file
                string filePath = new Uri(Path.GetDirectoryName(
                        Assembly.GetExecutingAssembly().CodeBase)).LocalPath;
                StreamWriter writer = new StreamWriter(filePath + "\\BirdWatch.log", true);

                // Add new observation to the log string
                string logEntry = DateTime.Now.ToShortDateString();
                logEntry += " " + DateTime.Now.ToLongTimeString();
                logEntry += " - uusi havainto: " + birdName;

                // Add all observations to the log string
                logEntry += " - kaikki havainnot: ";
                for (int i = 0; i < birdList.Count; i++)
                {
                    logEntry += birdList[i].BirdName + " ";
                    logEntry += birdList[i].BirdObservations.ToString();
                    if (i < birdList.Count - 1)
                    {
                        logEntry += " kappaletta, ";
                    }
                    else
                    {
                        logEntry += " kappaletta.";
                    }
                }

                writer.WriteLine(logEntry);
                writer.Close();
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Write new bird type addition event to the log file.
        /// </summary>
        /// <param name="newBirdName">The name of the new bird.</param>
        public static void Write(string newBirdName)
        {
            try
            {
                string filePath = new Uri(Path.GetDirectoryName(
                        Assembly.GetExecutingAssembly().CodeBase)).LocalPath;
                StreamWriter writer = new StreamWriter(filePath + "\\BirdWatch.log", true);

                string logEntry = DateTime.Now.ToShortDateString();
                logEntry += " " + DateTime.Now.ToLongTimeString();
                logEntry += " - lajin lisäys: " + newBirdName;

                writer.WriteLine(logEntry);
                writer.Close();
            }
            catch (FileNotFoundException)
            {
            }
        }

        /// <summary>
        /// Read all logged bird observations without count information.
        /// If file does not exist or file is empty, a notification string is added.
        /// </summary>
        /// <returns>
        /// The list of bird observations without count information.
        /// </returns>
        public static List<string> ReadObservations()
        {
            List<string> birdReportList = new List<string>();
            try
            {
                string filePath = new Uri(Path.GetDirectoryName(
                        Assembly.GetExecutingAssembly().CodeBase)).LocalPath;
                StreamReader reader = new StreamReader(filePath + "\\BirdWatch.log");
                string line;

                do
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        if (line.IndexOf(" - kaikki") > 0)
                        {
                            birdReportList.Add(line.Substring(0, line.IndexOf(" - kaikki")));
                        }
                    }
                }
                while (line != null);

                reader.Close();
            }
            catch (FileNotFoundException)
            {
                // File was not found, add notification string
                birdReportList.Add("Lokitiedostoa ei ole vielä olemassa");
            }

            if (birdReportList.Count == 0)
            {
                // File was empty, add notification string
                birdReportList.Add("Lokitiedostoa ei ole vielä olemassa");
            }

            return birdReportList;
        }
    }
}