using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ODataAggregationSample.Models {
    public class Person 
    {
        public Person() {
            Emails = new List<string>();

            Concurrency = DateTime.UtcNow.Ticks;
        }

        [Key]
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        [Required]
        public PersonGender Gender { get;  set; }

        //public Stream Photo { get; set; }

        public string Introduction { get; set; }

        public List<string> Emails { get; set; }

        [ConcurrencyCheck]
        public long Concurrency { get; set; }

        public static int TotalAge(IEnumerable<int> age) {
            return age.Sum();
        }
        
    }

    public enum PersonGender {
        Male = 0,
        Female = 1,
        Unknown = 2,
    }
}