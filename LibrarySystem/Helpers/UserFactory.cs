using LibrarySystem.Dtos.AuthDtos;
using LibrarySystem.Models;

namespace LibrarySystem.Helpers
{
    public class UserFactory
    {
        public static User GetUserInstance(RegisterUserDto registerUserDto)
        {
          switch (registerUserDto.Role.ToLower())
            {
                case "admin":
                    return new Admin(registerUserDto.Username,registerUserDto.Password, registerUserDto.Email);
                case "customer":
                    return new Customer(registerUserDto.Username, registerUserDto.Password, registerUserDto.Email);
                default:
                    return null;
            }
        }
    }
}
