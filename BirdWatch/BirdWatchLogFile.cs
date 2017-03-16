using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Reflection;

namespace BirdWatch
{
    public class BirdWatchLogFile
    {
        public static void Write(string birdName, List<BirdWatchItem> birdList)
        {
            try
            {
                string filePath = new Uri(Path.GetDirectoryName(
                        Assembly.GetExecutingAssembly().CodeBase)).LocalPath;
                StreamWriter writer = new StreamWriter(filePath + "\\BirdWatch.log", true);

                string logEntry = DateTime.Now.ToShortDateString();
                logEntry += " " + DateTime.Now.ToLongTimeString();
                logEntry += " - uusi havainto: " + birdName;
                logEntry += " - kaikki havainnot: ";

                for (int i = 0; i < birdList.Count; i++)
                {
                    logEntry += birdList[i].BirdName + " ";
                    logEntry += birdList[i].BirdObservations.ToString();
                    if(i < birdList.Count-1)
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
                        birdReportList.Add(line);
                    }
                }
                while (line != null);

                reader.Close();
            }
            catch (FileNotFoundException)
            {
            }

            return birdReportList;
        }
    }
}