﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WorldOfFootball.Entities;
using WorldOfFootball.Models;
using WorldOfFootball.Services;

namespace WorldOfFootball.Controllers
{
    [Route("api/footballClub")]
    [ApiController]
    [Authorize]
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
            _footballClubService.Update(id, dto, User);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _footballClubService.Delete(id, User);

            return NoContent();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateFootballClub([FromBody]CreateFootballClubDto dto)
        {
            var userId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var id = _footballClubService.Create(dto, userId);

            return Created($"/api/footballClub/{id}", null);
        }

        [HttpGet]
        [Authorize(Policy = "Atleast20")]
        public ActionResult<IEnumerable<FootballClubDto>> GetAll([FromQuery]FootballClubQuery query)
        {
            var footballClubDtos = _footballClubService.GetAll(query);

            return Ok(footballClubDtos);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<FootballClubDto> Get([FromRoute] int id)
        {
            var footballClub = _footballClubService.GetById(id);                     

            return Ok(footballClub);
        }
    }
}
