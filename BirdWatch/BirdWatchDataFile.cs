using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Reflection;

namespace BirdWatch
{
    public class BirdWatchDataFile
    {
        private static string ParseBirdName(string line)
        {
            string[] stringList = line.Split(',');
            return stringList[0];
        }

        private static int ParseBirdObservations(string line)
        {
            string[] stringList = line.Split(',');
            return Int32.Parse(stringList[1]);
        }

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
                birdList.Add(new BirdWatchItem("Harakka", 0));
                birdList.Add(new BirdWatchItem("Varis", 0));
            }

            if(birdList.Count==0)
            {
                birdList.Add(new BirdWatchItem("Harakka", 0));
                birdList.Add(new BirdWatchItem("Varis", 0));
            }
            return birdList;
        }

        public static void Write(List<BirdWatchItem> birdList)
        {
            try
            {
                string filePath = new Uri(Path.GetDirectoryName(
                        Assembly.GetExecutingAssembly().CodeBase)).LocalPath;
                StreamWriter writer = new StreamWriter(filePath + "\\BirdWatch.dat");

                for (int i=0; i< birdList.Count;i++)
                {
                    writer.WriteLine(
                        birdList[i].BirdName + "," + birdList[i].BirdObservations.ToString());
                }
                writer.Close();
            }
            catch (Exception)
            {
                // TODO
            }
        }
    }
}