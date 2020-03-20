using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Park
    {
        /// <summary>
        /// A short string that uniquely identifies a park
        /// </summary>
        public string ParkCode { get; set; }
        /// <summary>
        /// The name of the park
        /// </summary>
        public string ParkName { get; set; }
        /// <summary>
        /// The state in which the park is located
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// The size of the park in acres
        /// </summary>
        public int Acreage { get; set; }
        /// <summary>
        /// The park's elevation above sea level (in feet)
        /// </summary>
        public int ElevationInFeet { get; set; }
        /// <summary>
        /// The combined length of all hiking trails in the park
        /// </summary>
        public float MilesOfTrail { get; set; }
        /// <summary>
        /// The total number of campsites available for visitors in the park
        /// </summary>
        public int NumberOfCampsites { get; set; }
        /// <summary>
        /// A general description of the park's climate
        /// </summary>
        public string Climate { get; set; }
        /// <summary>
        /// The year the park joined the National Park System
        /// </summary>
        public int YearFounded { get; set; }
        /// <summary>
        /// The average number of visitors to the park on an annual basis
        /// </summary>
        public int AnnualVisitorCount { get; set; }
        /// <summary>
        /// A famous quote related to the park
        /// </summary>
        public string InspirationalQuote { get; set; }
        /// <summary>
        /// The person to whom the quote is attributed
        /// </summary>
        public string InspirationalQuoteSource { get; set; }
        /// <summary>
        /// A description of the park
        /// </summary>
        public string ParkDescription { get; set; }
        /// <summary>
        /// The cost to enter the park in dollars
        /// </summary>
        public int EntryFee { get; set; }
        /// <summary>
        /// The number of different animal species that can be found within the boundaries of the park
        /// </summary>
        public int NumberOfAnimalSpecies { get; set; }
    }
}
