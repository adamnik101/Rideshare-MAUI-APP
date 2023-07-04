using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rideshare.Business.DTOs
{
    public class RideDto : PagedSearch
    {   
        public BaseDto StartCity { get; set; }
        public BaseDto DestinationCity { get; set; }
        public DriverDto Driver { get; set; }
        public CarDto Car { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Price { get; set; }
        public int NumberOfAvailableSeats { get; set; }
        public IEnumerable<RestrictionDto> Restrictions { get; set; }
    }
}
