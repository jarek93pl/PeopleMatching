using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleMatching.Models
{
    public class MatcherData
    {
        public Men Men { get; set; }
        public Women Women { get; set; }
        public bool Matched { get; set; }
    }
}