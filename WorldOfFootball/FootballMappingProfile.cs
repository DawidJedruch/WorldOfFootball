using AutoMapper;
using WorldOfFootball.Entities;
using WorldOfFootball.Models;

namespace WorldOfFootball
{
    public class FootballMappingProfile : Profile
    {
        public FootballMappingProfile()
        {
            CreateMap<FootballClub, FootballClubDto>();

            CreateMap<Footballer, FootballerDto>();

            CreateMap<CreateFootballClubDto, FootballClub>();
        }
    }
}
