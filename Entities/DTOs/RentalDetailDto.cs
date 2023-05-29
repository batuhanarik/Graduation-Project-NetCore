using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RentalDetailDto
    {
        public int Id { get; set; }
        public string PlaceName { get; set; }
        public string PlateName { get; set; }
        public string CategoryName { get; set; }
        public string CustomerName { get; set; }
        public DateTime RentDate { get; set; }


    }
}
