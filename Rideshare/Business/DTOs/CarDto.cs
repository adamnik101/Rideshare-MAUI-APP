using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rideshare.Business.DTOs
{
    public class CarDto
    {
        public int Id { get; set; }
        public string BrandModel { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
        public string ImagePath { get; set; }
        public int NumberOfSeats { get; set; }
        public string LicencePlate { get; set; }
        public string Owner { get; set; }
        public int FirstRegistration { get; set; }
        public IEnumerable<RestrictionDto> Restrictions { get; set; }
    }
}
