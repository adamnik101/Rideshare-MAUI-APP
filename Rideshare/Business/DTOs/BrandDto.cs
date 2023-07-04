using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rideshare.Business.DTOs
{
    public class BrandDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<BaseDto> Models { get; set; }
    }
}
