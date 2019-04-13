using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PeopleMatching.Logic
{
    public enum EyesColor
    {
        [Display(Name = "Niebieskie")]
        Blue,
        [Display(Name = "Brązowe")]
        Brown,
        [Display(Name = "Zielone")]
        green
    }
}