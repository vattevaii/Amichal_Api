namespace Amichal.Domain.Entities.UserRoles
{
    public class Customer : User
    {
        public string Address { get; set; } = null!;
        public Rating[] Ratings { get; set; } = new Rating[] { };
        public Cart[] Cart { get; set; } = new Cart[] { };
    }
}
