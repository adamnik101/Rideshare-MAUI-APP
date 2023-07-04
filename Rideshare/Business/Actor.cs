using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rideshare.Business
{
    public class Actor
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime LoginExpiration { get; set; }
        public bool ShouldBeLoggedOut => LoginExpiration < DateTime.UtcNow;
    }
}
