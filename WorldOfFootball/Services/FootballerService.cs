using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorldOfFootball.Entities;
using WorldOfFootball.Exceptions;
using WorldOfFootball.Models;

namespace WorldOfFootball.Services
{
    public interface IFootballerService
    {
        int Create(int footballClubId, CreateFootballerDto dto);

        FootballerDto GetById(int footballClubId, int footballerId);

        List<FootballerDto> GetAll(int footballClubId)
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

        public FootballerDto GetById(int footballClubId, int footballerId)
        {
            var footballClub = _context.FootballClubs.FirstOrDefault(f => f.Id == footballClubId);
            if (footballClub is null)
                throw new NotFoundException("FootballClub not found");

            var footballer = _context.Footballers.FirstOrDefault(f => f.Id == footballerId);
            if (footballer is null || footballer.FootballClubId != footballClubId)
            {
                throw new NotFoundException("Footballer not found");
            }

            var footballerDto = _mapper.Map<FootballerDto>(footballer);
            return footballerDto;
        }

        public List<FootballerDto> GetAll(int footballClubId)
        {
            var footballClub = _context
                .FootballClubs
                .Include(f => f.Footballers)
                .FirstOrDefault(f => f.Id == footballClubId);
            if (footballClub is null)
                throw new NotFoundException("FootballClub not found");

            var footballerDtos = _mapper.Map<List<FootballerDto>>(footballClub.Footballers);

            return footballerDtos;
        }
    }
}
