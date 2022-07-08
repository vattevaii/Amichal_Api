using System.ComponentModel.DataAnnotations;

namespace Amichal.Domain.Entities;
public class User
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; }=null!;
    public string LastName { get; set; } =null!;
    public string Email { get; set; }    =null!;
    public string Password { get; set; } = null!;
    
    //I used Discriminator so, this is not necessary
    //public Roles UserRole { get; set; } = 0;

}

public enum Roles
{
    Admin = 10, GroupAdmin = 1, Seller = 2, Buyer = 0
}
