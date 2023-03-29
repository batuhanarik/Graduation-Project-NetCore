using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class WeddingPlaceImage : IEntity
    {
        [Key]
        public int PlacePhotoId { get; set; }
        public int WeddingPlaceId { get; set; }
        public string ImagePath { get; set; }
         public DateTime Date { get; set; } = DateTime.Now;
    }
}
