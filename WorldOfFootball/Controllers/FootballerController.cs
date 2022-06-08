using Microsoft.AspNetCore.Mvc;
using WorldOfFootball.Models;
using WorldOfFootball.Services;

namespace WorldOfFootball.Controllers
{
    [Route("api/footballClub/{footballClubId}/footballer")]
    [ApiController]
    public class FootballerController : Controller
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

            return Created($"api/{footballClubId}/footballer/{newFootballerId}", null);
        }
    }
}
