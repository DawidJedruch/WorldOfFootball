using AutoMapper;
using WorldOfFootball.Entities;
using WorldOfFootball.Exceptions;
using WorldOfFootball.Models;

namespace WorldOfFootball.Services
{
    public interface IFootballerService
    {
        int Create(int footballClubId, CreateFootballerDto dto);
    }

    public class FootballerService : IFootballerService
    {
        private FootballDbContext _context;
        private IMapper _mapper;

        public FootballerService(FootballDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Create(int footballClubId, CreateFootballerDto dto)
        {
            var footballClub = _context.FootballClubs.FirstOrDefault(f => f.Id == footballClubId);
            if (footballClub is null)
                throw new NotFoundException("FootballClub not found");

            var footballerEntity = _mapper.Map<Footballer>(dto);

            footballerEntity.FootballClubId = footballClubId;

            _context.Footballers.Add(footballerEntity);
            _context.SaveChanges();

            return footballerEntity.Id;
        }
    }
}
