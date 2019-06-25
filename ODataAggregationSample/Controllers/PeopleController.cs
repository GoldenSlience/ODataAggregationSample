using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using ODataAggregationSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ODataAggregationSample.Controllers {
    public class PeopleController : ODataController {
        private static List<Person> People = new List<Person> {
            new Person { UserName="SHS", Gender = PersonGender.Female, Age = 3 },
            new Person { UserName="STN", Gender = PersonGender.Male, Age = 4 },
            new Person { UserName="MNDT", Gender = PersonGender.Female, Age = 5 },
            new Person { UserName="MVC", Gender = PersonGender.Male, Age = 6 },
        };

        [EnableQuery]
        public IQueryable<Person> Get(ODataQueryOptions<Person> options) {
            return People.AsQueryable<Person>();
        }

        
    }
}