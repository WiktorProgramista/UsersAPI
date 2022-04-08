using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAPI.Application.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string EmailAddres { get; set; }
        public string FirstName { get; set; }
        public string SureName { get; set; }
        public DateTime BirthDay { get; set; }
        public int NumberOfChilds { get; set; }
    }
}
