// ----------------------------------------------------------------------------
// <copyright file="BirdWatchItem.cs" company="N/A">
// <![CDATA[
//      This file is part of BirdWatch web server-client programming example.
//      Project is open and does not hold copyright.
//      Contact: Tommi Lilja <github@tietoparkki.fi>
// ]]>
// </copyright>
// ----------------------------------------------------------------------------
namespace BirdWatch
{
    /// <summary>
    /// This class implements BirdWatch data item.
    /// </summary>
    public class BirdWatchItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BirdWatchItem"/> class.
        /// </summary>
        /// <param name="birdName">The name of the bird.</param>
        public BirdWatchItem(string birdName)
        {
            this.BirdName = birdName;
            this.BirdObservations = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BirdWatchItem"/> class.
        /// </summary>
        /// <param name="birdName">The name of the bird.</param>
        /// <param name="birdObservations">The count of observations.</param>
        public BirdWatchItem(string birdName, int birdObservations)
        {
            this.BirdName = birdName;
            this.BirdObservations = birdObservations;
        }

        /// <summary>
        /// Gets the bird name.
        /// </summary>
        /// <value>
        /// The bird name.
        /// </value>
        public string BirdName { get; }

        /// <summary>
        /// Gets or sets the observation count.
        /// </summary>
        /// <value>
        /// The observation count.
        /// </value>
        public int BirdObservations { get; set; }

        /// <summary>
        /// Increments the observation count.
        /// </summary>
        public void IncrementBirdObservations()
        {
            this.BirdObservations++;
        }
    }
}