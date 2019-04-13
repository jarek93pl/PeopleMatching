using PeopleMatching.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PeopleMatching.Models
{

    public class Person
    {
        [DisplayName("Imie")]
        public string FirstName { get; set; }

        [DisplayName("Wzrost")]
        public int Growth { get; set; }

        [DisplayName("Data urodzenia")]
        public DateTime DateBirth { get; set; }
        

        public EyesColor EyesColor { get; set; }
    }
}