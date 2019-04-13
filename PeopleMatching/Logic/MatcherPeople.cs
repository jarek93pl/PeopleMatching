using PeopleMatching.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleMatching.Logic
{
    public static class MatcherPeople
    {
        const int minimalSimilarity = 2;
        public static bool MatchCouple(Men men, Women womem)
        {
            int similarity = 0;
            if (MatchEyes(men, womem))
            {
                similarity++;
            }
            if (MatchGrowth(men, womem))
            {
                similarity++;
            }
            if (MatchAge(men, womem))
            {
                similarity++;
            }
            return similarity >= minimalSimilarity;
        }

        private static bool MatchAge(Men men, Women womem)
        {
            DateTime minAge;
            DateTime maxAge;
            if (men.DateBirth < womem.DateBirth)
            {
                minAge = men.DateBirth;
                maxAge = womem.DateBirth;
            }
            else
            {
                maxAge = men.DateBirth;
                minAge = womem.DateBirth;
            }
            return minAge.AddYears(10) > maxAge;
        }

        private static bool MatchGrowth(Men men, Women womem)
        {
            return men.Growth - 10 > womem.Growth;
        }

        private static bool MatchEyes(Men men, Women womem)
        {
            return men.EyesColor == womem.EyesColor;
        }
    }
}