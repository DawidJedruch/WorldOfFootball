using Microsoft.AspNetCore.Mvc;
using WorldOfFootball.Models;
using WorldOfFootball.Services;

namespace WorldOfFootball.Controllers
{
    [Route("api/footballClub/{footballClubId}/footballer")]
    [ApiController]
    public class FootballerController : ControllerBase
    {
        private IFootballerService _footballerService;

        public FootballerController(IFootballerService footballerService)
        {
            _footballerService = footballerService;
        }
        [HttpPost]
       public ActionResult Post([FromRoute]int footballClubId,[FromBody]CreateFootballerDto dto)
        {
            var newFootballerId = _footballerService.Create(footballClubId, dto);

            return Created($"api/footballClub/{footballClubId}/footballer/{newFootballerId}", null);
        }

        [HttpGet("{footballerId}")]
        public ActionResult<FootballerDto> Get([FromRoute] int footballClubId, [FromRoute]int footballerId)
        {
            FootballerDto footballer = _footballerService.GetById(footballClubId, footballerId);
            return Ok(footballer);
        }

        [HttpGet]
        public ActionResult<FootballerDto> Get([FromRoute] int footballClubId)
        {
            var result = _footballerService.GetAll(footballClubId);
            return Ok(result);
        }

        [HttpDelete]
        public ActionResult Delete([FromRoute]int footballerId)
        {
            _footballerService.RemoveAll(footballerId);

            return NoContent();
        }
    }
}
