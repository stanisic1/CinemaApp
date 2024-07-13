using AutoMapper;
using CinemaApp.Models.DTO;

namespace CinemaApp.Models
{
    public class TicketProfile: Profile
    {
        public TicketProfile()
        {
            CreateMap<Ticket, UserTicketsDTO>()
               .ForMember(dest => dest.ProjectionMovieTitle, opt => opt.MapFrom(src => src.Projection.Movie.Title))
               .ForMember(dest => dest.ProjectionDateTime, opt => opt.MapFrom(src => src.Projection.DateTime))
               .ForMember(dest => dest.ProjectionType, opt => opt.MapFrom(src => src.Projection.ProjectionType != null ? UserTicketsDTO.GetEnumDisplayName(src.Projection.ProjectionType.Type) : null))
               .ForMember(dest => dest.Theater, opt => opt.MapFrom(src => src.Projection.Theater != null ? UserTicketsDTO.GetEnumDisplayName(src.Projection.Theater.Type) : null))
               .ForMember(dest => dest.Seat, opt => opt.MapFrom(src => src.Seat.Number))
               .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Projection.Price));
        }
        
    }
}
