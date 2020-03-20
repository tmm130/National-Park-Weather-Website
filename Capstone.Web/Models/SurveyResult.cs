using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class SurveyResult
    {
        /// <summary>
        /// The park code of the park being tallied
        /// </summary>
        public string ParkCode { get; set; }
        /// <summary>
        /// The name of the park being tallied
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The number of survey votes
        /// </summary>
        public int Count { get; set; }
    }
}
