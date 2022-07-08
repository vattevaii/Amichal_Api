namespace Amichal.Domain.Entities.UserRoles
{
    public class Seller : User
    {
        public string OrganizationName { get; set; } = string.Empty;
        public double MyRating { get; set; }
        public Product[] Products { get; set; }
    }
}
