using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorldOfFootball.Entities;
using WorldOfFootball.Models;
using WorldOfFootball.Services;

namespace WorldOfFootball.Controllers
{
    [Route("api/footballClub")]
    [ApiController]
    public class FootballController : ControllerBase
    {
        private readonly IFootballClubService _footballClubService;

        public FootballController(IFootballClubService footballClubService)
        {
            _footballClubService = footballClubService;
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateFootballClubDto dto, [FromRoute]int id)
        {
            _footballClubService.Update(id, dto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _footballClubService.Delete(id);

            return NoContent();
        }

        [HttpPost]
        public ActionResult CreateFootballClub([FromBody]CreateFootballClubDto dto)
        {           
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

            return Ok(footballClub);
        }
    }
}
