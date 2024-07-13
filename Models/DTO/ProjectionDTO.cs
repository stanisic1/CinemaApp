using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace CinemaApp.Models.DTO
{
    public class ProjectionDTO
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string ProjectionType { get; set; }
        public string Theater { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Price { get; set; }
        public int UnsoldTicketsCount { get; set; }

        public static string GetEnumDisplayName<T>(T enumValue) where T : Enum
        {
            return enumValue.GetType()                     // Get the type of the enum value
                .GetMember(enumValue.ToString())          // Get the member (enum value) as a MemberInfo object
                .First()                                  // Take the first member
                .GetCustomAttribute<DisplayAttribute>()   // Get the DisplayAttribute associated with the member
                ?.GetName() ??                             // If DisplayAttribute exists, get its Name property
                enumValue.ToString();                     // If DisplayAttribute doesn't exist, return the enum value as string
        }

    }
}
