using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class PlaceType : IEntity
    {
        [Key]
        public int PlaceTypeId { get; set; }
        public string PlaceTypeName { get; set; }
        public List<WeddingPlace> WeddingPlaces { get; set; }

    }
}
