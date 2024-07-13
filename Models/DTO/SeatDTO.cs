using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CinemaApp.Models.DTO
{
    public class SeatDTO
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public bool IsAvailable { get; set; }
        public string Theater { get; set; }

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
