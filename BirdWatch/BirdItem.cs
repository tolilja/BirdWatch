using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BirdWatch
{
    public class BirdItem
    {
        public BirdItem(string birdName)
        {
            this.BirdName = birdName;
            this.BirdCount = 0;
        }

        public BirdItem(string birdName, int birdCount)
        {
            this.BirdName = birdName;
            this.BirdCount = birdCount;
        }

        public string BirdName { get; }
        public int BirdCount { get; set; }
        public void AddBirdCount()
        {
            this.BirdCount++;
        }
    }
}