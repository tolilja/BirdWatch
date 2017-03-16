using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace BirdWatch
{
    public class BirdWatchDataFile
    {
        public static BirdWatchData ReadBirdDataFile()
        {
            BirdWatchData birdWatchData = new BirdWatchData();
            try
            {
                StreamReader reader = new StreamReader("BirdWatch.dat");

                string line;

                do
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        //this.dataBlock.Add(line);
                    }
                }
                while (line != null);

                reader.Close();
            }
            catch (FileNotFoundException e)
            {
                birdWatchData.AddBirdItem("Harakka", 0);
                birdWatchData.AddBirdItem("Varis", 0);
            }

            return birdWatchData;
        }
    }
}