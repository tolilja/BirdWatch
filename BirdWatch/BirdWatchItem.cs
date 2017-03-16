using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BirdWatch
{
    public class BirdWatchItem
    {
        public BirdWatchItem(string birdName)
        {
            this.BirdName = birdName;
            this.BirdObservations = 0;
        }

        public BirdWatchItem(string birdName, int birdObservations)
        {
            this.BirdName = birdName;
            this.BirdObservations= birdObservations;
        }

        public string BirdName { get; }

        public int BirdObservations { get; set; }

        public void IncrementBirdObservations()
        {
            this.BirdObservations++;
        }
    }
}