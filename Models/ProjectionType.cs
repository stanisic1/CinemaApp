using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CinemaApp.Models
{
    public enum ProjectionTypeEnum
    {
        [Display(Name = "2D")]
        TwoD= 1,

        [Display(Name = "3D")]
        ThreeD = 2,

        [Display(Name = "4D")]
        FourD = 3
    }

    public class ProjectionType
    {
        public int Id { get; set; }

        public ProjectionTypeEnum Type { get; set; }

      
    }

    
}
