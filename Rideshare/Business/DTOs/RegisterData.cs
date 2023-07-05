using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rideshare.Business.DTOs
{
    public class RegisterData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int GenderId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
    }
}
