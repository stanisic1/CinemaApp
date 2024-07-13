using AutoMapper;
using CinemaApp.Models.DTO;

namespace CinemaApp.Models
{
    public class SeatProfile: Profile
    {
        public SeatProfile()
        {
            CreateMap<Seat, SeatDTO>()
                 .ForMember(dest => dest.Theater, opt => opt.MapFrom(src => SeatDTO.GetEnumDisplayName(src.Theater.Type)));
        }
    }
}
