// ----------------------------------------------------------------------------
// <copyright file="BirdWatchDataFile.cs" company="N/A">
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
    /// This class implements BirdWatch data storage.
    /// Data storage is simple text file based system.
    /// </summary>
    public class BirdWatchDataFile
    {
        /// <summary>
        /// Read all recorded bird types and observation counts from data file.
        /// If file does not exist or file is empty, two default items are added.
        /// </summary>
        /// <returns>
        /// The list of birds and corresponding observation counts.
        /// </returns>
        public static List<BirdWatchItem> Read()
        {
            List<BirdWatchItem> birdList = new List<BirdWatchItem>();
            try
            {
                string filePath = new Uri(Path.GetDirectoryName(
                        Assembly.GetExecutingAssembly().CodeBase)).LocalPath;
                StreamReader reader = new StreamReader(filePath + "\\BirdWatch.dat");
                string line;

                do
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        birdList.Add(new BirdWatchItem(
                            BirdWatchDataFile.ParseBirdName(line),
                            BirdWatchDataFile.ParseBirdObservations(line)));
                    }
                }
                while (line != null);

                reader.Close();
            }
            catch (FileNotFoundException)
            {
                // File was not found, add Harakka and Varis items to the list
                birdList.Add(new BirdWatchItem("Harakka", 0));
                birdList.Add(new BirdWatchItem("Varis", 0));
            }

            if (birdList.Count == 0)
            {
                // File was empty, add Harakka and Varis items to the list
                birdList.Add(new BirdWatchItem("Harakka", 0));
                birdList.Add(new BirdWatchItem("Varis", 0));
            }

            return birdList;
        }

        /// <summary>
        /// Write all recorded bird types and observation counts to data file.
        /// </summary>
        /// <param name="birdList">The list of all birds and observation counts.</param>
        public static void Write(List<BirdWatchItem> birdList)
        {
            try
            {
                string filePath = new Uri(Path.GetDirectoryName(
                        Assembly.GetExecutingAssembly().CodeBase)).LocalPath;
                StreamWriter writer = new StreamWriter(filePath + "\\BirdWatch.dat");

                for (int i = 0; i < birdList.Count; i++)
                {
                    writer.WriteLine(
                        birdList[i].BirdName + "," + birdList[i].BirdObservations.ToString());
                }

                writer.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error writing data file: " + ex.Message);
            }
        }

        /// <summary>
        /// Parses bird name from the string read from data file.
        /// </summary>
        /// <param name="line">The line read from data file.</param>
        /// <returns>
        /// Bird name string.
        /// </returns>
        private static string ParseBirdName(string line)
        {
            string[] stringList = line.Split(',');
            return stringList[0];
        }

        /// <summary>
        /// Parses bird observation count from the string read from data file.
        /// </summary>
        /// <param name="line">The line read from data file.</param>
        /// <returns>
        /// Bird observation count.
        /// </returns>
        private static int ParseBirdObservations(string line)
        {
            string[] stringList = line.Split(',');
            return int.Parse(stringList[1]);
        }
    }
}