using Microsoft.AspNetCore.Mvc;
using WorldOfFootball.Entities;

namespace WorldOfFootball.Controllers
{
    [Route("api/footballClubs")]
    public class FootballController : ControllerBase
    {
        private readonly FootballDbContext _dbcontext;

        public FootballController(FootballDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FootballClub>> GetAll()
        {
            var footballClubs = _dbcontext
                .FootballClubs
                .ToList();

            return Ok(footballClubs);
        }

        [HttpGet("{id}")]
        public ActionResult<FootballClub> Get([FromRoute] int id)
        {
            var footballClub = _dbcontext
                .FootballClubs
                .FirstOrDefault(r => r.Id == id);

            if(footballClub is null)
            {
                return NotFound();
            }

            return Ok(footballClub);
        }
    }
}
