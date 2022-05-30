using AutoMapper;
using WorldOfFootball.Entities;
using WorldOfFootball.Models;

namespace WorldOfFootball.Services
{
    public interface IFootballClubService
    {
        FootballClubDto GetById(int id);
        IEnumerable<FootballClubDto> GetAll();
        int Create(CreateFootballClubDto dto);
        bool Delete(int id);
        bool Update(int id, UpdateFootballClubDto dto);
    }

    public class FootballClubService : IFootballClubService
    {
        private readonly FootballDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public FootballClubService(FootballDbContext dbContext, IMapper mapper, ILogger<FootballClubService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public bool Update(int id, UpdateFootballClubDto dto)
        {
            var footballClub = _dbContext
                .FootballClubs
                .FirstOrDefault(r => r.Id == id);

            if (footballClub is null) return false;

            footballClub.Name = dto.Name;
            footballClub.StadiumName = dto.StadiumName;
            footballClub.City = dto.City;
            footballClub.Nationality = dto.Nationality;
            footballClub.Description = dto.Description;

            _dbContext.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            _logger.LogError($"FootballClub with id: {id} DELETE action invoked.");

            var footballClub = _dbContext
                .FootballClubs
                .FirstOrDefault(r => r.Id == id);

            if (footballClub is null) return false;

            _dbContext.FootballClubs.Remove(footballClub);
            _dbContext.SaveChanges();

            return true;
        }

        public FootballClubDto GetById(int id)
        {
            var footballClub = _dbContext
                .FootballClubs
                .FirstOrDefault(r => r.Id == id);

            if (footballClub is null)
            {
                return null;
            }

            var result = _mapper.Map<FootballClubDto>(footballClub);
            return result;
        }

        public IEnumerable<FootballClubDto> GetAll()
        {
            var footballClubs = _dbContext
                .FootballClubs
                .ToList();

            var footballClubDtos = _mapper.Map<List<FootballClubDto>>(footballClubs);

            return footballClubDtos;
        }

        public int Create(CreateFootballClubDto dto)
        {
            var footballClub = _mapper.Map<FootballClub>(dto);
            _dbContext.FootballClubs.Add(footballClub);
            _dbContext.SaveChanges();

            return footballClub.Id;
        }
    }
}
