using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class User : IEntity
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public bool ?IsWeddingPlaceOwner { get; set; }
        public string PhoneNumber { get; set; }
        public byte[] PasswordSalt { get; set; } //Temprary field
        public byte[] PasswordHash { get; set; } //Temprary field
        public bool Status { get; set; } //Temprary field
    }
}
