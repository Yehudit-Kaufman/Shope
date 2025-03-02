using Entite;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public record UserDTO(int UserId, [EmailAddress] string UserName, [StringLength(20, ErrorMessage = "LastName can be betwenn 2 till 20 letters", MinimumLength = 2)] string FirstName, [StringLength(20, ErrorMessage = "LastName can be betwenn 2 till 20 letters", MinimumLength = 2)] string LastName);
    public record RegisterUserDTO([EmailAddress] string UserName, [StringLength(20, ErrorMessage = "FirstName can be betwenn 2 till 20 letters", MinimumLength = 2),]string FirstName, [StringLength(20, ErrorMessage = "LastName can be betwenn 2 till 20 letters", MinimumLength = 2)]string LastName, string Password);
}
