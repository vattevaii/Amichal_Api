using Amichal.Domain.Entities.UserRoles;
using System.ComponentModel.DataAnnotations;

namespace Amichal.Domain.Entities
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        public int? ReplyId { get; set; }
        public Rating? reply { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Buyer { get; set; }
        public double Stars { get; set; }
        public string Comment { get; set; } = string.Empty;
    }
}
