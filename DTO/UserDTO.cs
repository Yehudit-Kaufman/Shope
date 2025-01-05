using Entite;

namespace DTO
{
    public record UserDTO(int UserId, string UserName, string FirstName,string LastName, List<OrderDTO> Orders);
    public record RegisterUserDTO(string UserName, string FirstName, string LastName, string Password);
}
