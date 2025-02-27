using Entite;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public record UserDTO(int UserId, string UserName, string FirstName,string LastName, List<OrderDTO> Orders);
    public record RegisterUserDTO([EmailAddress] string UserName, string FirstName, string LastName, string Password);
}
