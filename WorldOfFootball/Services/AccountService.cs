using Microsoft.AspNetCore.Identity;
using WorldOfFootball.Entities;
using WorldOfFootball.Models;

namespace WorldOfFootball.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);
    }
    public class AccountService : IAccountService
    {
        private readonly FootballDbContext _context;

        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountService(FootballDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }
        public void RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User()
            {
                Email = dto.Email,
                DateOfBirth = dto.DateOfBirth,
                Nationality = dto.Nationality,
                RoleId = dto.RoleId
            };

            var hashPassword = _passwordHasher.HashPassword(newUser, dto.Password);

            newUser.PasswordHash = hashPassword;
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }
    }
}
