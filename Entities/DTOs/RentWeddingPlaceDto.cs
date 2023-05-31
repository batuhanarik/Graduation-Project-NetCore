using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RentWeddingPlaceDto
    {
        public Rental Rental { get; set; }
        public CreditCard CreditCard { get; set; }
    }
}
