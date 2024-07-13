using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Models.DTO
{
    public class UserTicketsDTO
    {
        public int Id { get; set; }
        public string ProjectionMovieTitle { get; set; }
        public DateTime ProjectionDateTime { get; set; }
        public string ProjectionType { get; set; }
        public string Theater { get; set; }
        public int Seat { get; set; }
        public decimal Price { get; set; }

        public static string GetEnumDisplayName<T>(T enumValue) where T : Enum
        {
            return enumValue.GetType()                     
                .GetMember(enumValue.ToString())          
                .First()                                  
                .GetCustomAttribute<DisplayAttribute>()   
                ?.GetName() ??                             
                enumValue.ToString();                    
        }

    }
}
