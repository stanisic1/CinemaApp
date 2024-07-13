using AutoMapper;
using CinemaApp.Models.DTO;

namespace CinemaApp.Models
{
    public class ProjectionProfile: Profile
    {
        public ProjectionProfile()
        {
            CreateMap<Projection, ProjectionDTO>()
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Movie.Title))
                .ForMember(dest => dest.ProjectionType, opt => opt.MapFrom(src => ProjectionDTO.GetEnumDisplayName(src.ProjectionType.Type)))
                .ForMember(dest => dest.Theater, opt => opt.MapFrom(src => ProjectionDTO.GetEnumDisplayName(src.Theater.Type)))
                .ForMember(dest => dest.UnsoldTicketsCount, opt => opt.MapFrom(src => src.Theater.Capacity - src.Tickets.Count)); 

           
        }
    }
}
