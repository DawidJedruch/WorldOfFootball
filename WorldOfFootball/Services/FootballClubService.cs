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

    }

    public class FootballClubService : IFootballClubService
    {
        private readonly FootballDbContext _dbContext;
        private readonly IMapper _mapper;

        public FootballClubService(FootballDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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
