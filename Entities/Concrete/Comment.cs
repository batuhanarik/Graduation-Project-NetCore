using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Comment
    {

        [Key]
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int WeddingPlaceId { get; set; }
        public string CommentTitle { get; set; }
        public string CommentContent { get; set; }
        public bool CommentStatus { get; set; }
    }
}
