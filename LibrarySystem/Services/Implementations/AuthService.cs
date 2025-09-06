using LibrarySystem.Dtos.AuthDtos;
using LibrarySystem.Exceptions;
using LibrarySystem.Helpers;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Interfaces;
using LibrarySystem.Services.Interfaces;

namespace LibrarySystem.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository userRepository;
        private readonly JwtHelper jwtHelper;
        public AuthService(IUserRepository userRepository,JwtHelper jwtHelper)
        {
            this.userRepository = userRepository;
            this.jwtHelper = jwtHelper;
        }

        public async Task<UserDetails> LoginAsync(LoginUserDto loginUserDto)
        {
            var user = await userRepository.getByUserName(loginUserDto.Username);
            if(user == null)
                throw new UserNotFoundException("User not found");
            Boolean isValid = Hasher.Verify(loginUserDto.Password, user.PasswordHash);
            if (!isValid)
                throw new InvalidPasswordException("Invalid password");
            var token = jwtHelper.GenerateToken(user);
            return new UserDetails
            {
                Username = user.username,
                Email = user.Email,
                Role = user.GetType().Name,
                hashedPassword = user.PasswordHash,
                Token = token
            };
        }

        public async Task<UserDetails> RegisterAsync(RegisterUserDto registerUserDto)
        {
           var user =await userRepository.getByUserName(registerUserDto.Username);
            if (user != null)
                throw new UserAlreadyExistException("User already exists");
            registerUserDto.Password = Hasher.Hash(registerUserDto.Password);
            user =UserFactory.GetUserInstance(registerUserDto);
            if (user == null)
                throw new InvalidRoleException("Invalid role");
            await userRepository.AddAsync(user);
            await userRepository.SaveChangesAsync();
            return new UserDetails
            {
               Username = user.username,
                Email = user.Email,
                Role=registerUserDto.Role,
                hashedPassword = user.PasswordHash,
                Token= "noToken in register"

            };

        }
    }
}
