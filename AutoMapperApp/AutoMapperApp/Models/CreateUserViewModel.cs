using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMapperApp.Models
{
    public class CreateUserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Login { get; set; }

    }
}