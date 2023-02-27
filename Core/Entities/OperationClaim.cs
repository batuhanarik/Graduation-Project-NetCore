using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class OperationClaim : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
