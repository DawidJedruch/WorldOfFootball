using AutoMapper;
using System.Linq.Expressions;
using WorldOfFootball.Entities;
using WorldOfFootball.Exceptions;
using WorldOfFootball.Models;

namespace WorldOfFootball.Services
{
    public interface IFootballClubService
    {
        FootballClubDto GetById(int id);
        PageResult<FootballClubDto> GetAll(FootballClubQuery query);
        int Create(CreateFootballClubDto dto);
        void Delete(int id);
        void Update(int id, UpdateFootballClubDto dto);
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

        public void Update(int id, UpdateFootballClubDto dto)
        {
            var footballClub = _dbContext
                .FootballClubs
                .FirstOrDefault(r => r.Id == id);

            if (footballClub is null)
                throw new NotFoundException("FootballClub not found.");

            footballClub.Name = dto.Name;
            footballClub.StadiumName = dto.StadiumName;
            footballClub.City = dto.City;
            footballClub.Nationality = dto.Nationality;
            footballClub.Description = dto.Description;

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _logger.LogError($"FootballClub with id: {id} DELETE action invoked.");

            var footballClub = _dbContext
                .FootballClubs
                .FirstOrDefault(r => r.Id == id);

            if (footballClub is null)
                throw new NotFoundException("Football Club not found.");

            _dbContext.FootballClubs.Remove(footballClub);
            _dbContext.SaveChanges();
        }

        public FootballClubDto GetById(int id)
        {
            var footballClub = _dbContext
                .FootballClubs
                .FirstOrDefault(r => r.Id == id);

            if (footballClub is null)
                throw new NotFoundException("Football Club not found.");

            var result = _mapper.Map<FootballClubDto>(footballClub);
            return result;
        }

        public PageResult<FootballClubDto> GetAll(FootballClubQuery query)
        {
            var baseQuery = _dbContext
                .FootballClubs
                .Where(f => (query.SearchPhrase == null) || (f.Name.ToLower().Contains(query.SearchPhrase.ToLower())
                    || f.Description.ToLower().Contains(query.SearchPhrase.ToLower())));

            if (!string.IsNullOrEmpty(query.SortBy))
            {
                var columnsSelectors = new Dictionary<string, Expression<Func<FootballClub, object>>>
                {
                    {nameof(FootballClub.Name), f => f.Name},
                    {nameof(FootballClub.Description), f => f.Description},
                    {nameof(FootballClub.Nationality), f => f.Nationality},
                };

                var selectedColumn = columnsSelectors[query.SortBy];

                baseQuery = query.SortDirection == SortDirection.ASC ?
                    baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);
            }

            var footballClubs = baseQuery
                .Skip(query.PageSize * (query.PageNumber - 1))
                .Take(query.PageSize)
                .ToList();

            var totalItemsCount = baseQuery.Count();

            var footballClubDtos = _mapper.Map<List<FootballClubDto>>(footballClubs);

            var result = new PageResult<FootballClubDto>(footballClubDtos, totalItemsCount, query.PageSize, query.PageNumber);

            return result;
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
