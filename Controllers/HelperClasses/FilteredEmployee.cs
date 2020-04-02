using System;

namespace ProjectSale.Controllers
{

        public class FilteredEmployee
        {
            public int id {get; set;}
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string telephone { get; set; }
            public DateTime hired_date { get; set; }
            public DateTime birthdate { get; set; }
            public string address { get; set; }
        }
}
