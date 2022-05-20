using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorldOfFootball.Entities;
using WorldOfFootball.Models;
using WorldOfFootball.Services;

namespace WorldOfFootball.Controllers
{
    [Route("api/footballClubs")]
    [ApiController]
    public class FootballController : ControllerBase
    {
        private readonly IFootballClubService _footballClubService;

        public FootballController(IFootballClubService footballClubService)
        {
            _footballClubService = footballClubService;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _footballClubService.Delete(id);

            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult CreateFootballClub([FromBody]CreateFootballClubDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var id = _footballClubService.Create(dto);

            return Created($"/api/footballClub/{id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<FootballClubDto>> GetAll()
        {
            var footballClubDtos = _footballClubService.GetAll();

            return Ok(footballClubDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<FootballClubDto> Get([FromRoute] int id)
        {
            var footballClub = _footballClubService.GetById(id);
            
            if(footballClub is null)
            {
                return NotFound();
            }

            return Ok(footballClub);
        }
    }
}
