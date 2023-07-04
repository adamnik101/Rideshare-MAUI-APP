using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rideshare.Business.DTOs
{
    public class AddCarDto
    {
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public int FirstRegistration { get; set; }
        public string LicencePlate { get; set; }
        public int ColorId { get; set; }
        public int TypeId { get; set; }
        public IEnumerable<RestrictionDto> Restrictions { get; set; }
    }
}
