using Amichal.Domain.Entities.UserRoles;
using System.ComponentModel.DataAnnotations;

namespace Amichal.Domain.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid SellerId { get; set; }
        public Seller Seller { get; set; }
        public Rating[] Ratings = new Rating[] {};
    }
}
