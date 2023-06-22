using System.ComponentModel.DataAnnotations;

namespace SnnbFailover.Shared;
public class UserLogin
{
    [Required()]
    public string Username { get; set; }
    [Required()]
    public string Password { get; set; }
}
