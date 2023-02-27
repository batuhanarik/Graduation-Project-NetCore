using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class UserOperationClaim : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
