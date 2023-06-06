using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class WeddingPlaceStatsDto
    {
        public int Id { get; set; }
        public int TotalIncome { get; set; }
        public int TotalRentals { get; set; }
    }
}
