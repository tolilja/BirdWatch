using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BirdWatch
{
    public class BirdWatchData
    {
        private List<BirdItem> birdItems;

        public BirdWatchData()
        {
            this.birdItems = new List<BirdItem>();
        }

        public int BirdWatchCount()
        {
            return this.birdItems.Count;
        }

        public List<BirdItem> GetBirdItemList()
        {
            return this.birdItems;
        }

        public BirdItem BirdItem(int id)
        {
            try
            {
                return this.birdItems[id];
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void AddBirdItem(string birdName, int birdCount)
        {
            this.birdItems.Add(new BirdItem(birdName, birdCount));
        }


        public bool AddNewBirdItem(string newBirdName)
        {
            foreach(BirdItem birdItem in this.birdItems)
            {
                if (birdItem.BirdName == newBirdName)
                {
                    return false;
                }
            }

            this.birdItems.Add(new BirdItem(newBirdName));
            return true;
        }
    }
}