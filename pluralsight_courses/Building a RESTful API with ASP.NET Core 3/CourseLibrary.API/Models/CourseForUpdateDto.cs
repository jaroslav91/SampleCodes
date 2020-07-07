using System.ComponentModel.DataAnnotations;

namespace CourseLibrary.API.Models
{
    public class CourseForUpdateDto : CourseForModificationDto
    {
        [Required(ErrorMessage = "You should fill out description.")]
        public override string Description { get { return base.Description; } set { base.Description = value; } }
    }
}