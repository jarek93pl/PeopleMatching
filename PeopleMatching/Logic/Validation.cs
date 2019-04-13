using PeopleMatching.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PeopleMatching.Logic
{
    public static class Validation
    {
        public static bool ValidationPerson(Person person, ModelStateDictionary modelStateDictionary)
        {
            bool isValid = true;
            isValid &= ValidationPersonDate(person, modelStateDictionary);
            isValid &= ValidationGrowth(person, modelStateDictionary);

            return isValid;
        }

        private static bool ValidationGrowth(Person person, ModelStateDictionary modelStateDictionary)
        {
            if (person.Growth == default(int))
            {
                modelStateDictionary.AddModelError(nameof(person.Growth), "wzrost nie został wpisany");
                return false;
            }
            return true;
        }

        const int minimumAgeInYears = 18;
        private static bool ValidationPersonDate(Person person, ModelStateDictionary modelStateDictionary)
        {
            if (person.DateBirth.AddYears(minimumAgeInYears) > DateTime.Now)
            {
                modelStateDictionary.AddModelError(nameof(person.DateBirth), "osoba nie jest pełnoletnia");
                return false;
            }
            if (person.DateBirth.AddYears(minimumAgeInYears) == default(DateTime))
            {
                modelStateDictionary.AddModelError(nameof(person.DateBirth), "data nie jest uzupełniona");
                return false;
            }
            return true;
        }

    }
}