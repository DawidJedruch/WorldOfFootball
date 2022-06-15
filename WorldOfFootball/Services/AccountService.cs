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
        private FootballDbContext _context;

        public AccountService(FootballDbContext context)
        {
            _context = context;
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

            _context.Users.Add(newUser);
            _context.SaveChanges();
        }
    }
}
