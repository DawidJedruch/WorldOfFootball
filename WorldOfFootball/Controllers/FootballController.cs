using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorldOfFootball.Entities;
using WorldOfFootball.Models;

namespace WorldOfFootball.Controllers
{
    [Route("api/footballClubs")]
    public class FootballController : ControllerBase
    {
        private readonly FootballDbContext _dbcontext;
        private readonly IMapper _mapper;

        public FootballController(FootballDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FootballClubDto>> GetAll()
        {
            var footballClubs = _dbcontext
                .FootballClubs
                .ToList();

            var footballClubDtos = _mapper.Map<List<FootballClubDto>>(footballClubs);

            return Ok(footballClubDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<FootballClubDto> Get([FromRoute] int id)
        {
            var footballClub = _dbcontext
                .FootballClubs
                .FirstOrDefault(r => r.Id == id);

            if(footballClub is null)
            {
                return NotFound();
            }

            var footballClubDtos = _mapper.Map<List<FootballClubDto>>(footballClub);

            return Ok(footballClubDtos);
        }
    }
}
