using System.ComponentModel.DataAnnotations;
using CourseLibrary.API.ValidationAttributes;

namespace CourseLibrary.API.Models
{
    [CourseTitleMustBeDifferentFromDescriptionAttribute(ErrorMessage = "The provided description should be different from the title.")]
    public class CourseDtoForCreation
    {
        [Required(ErrorMessage = "You should fill out title.")]
        [MaxLength(100, ErrorMessage = "The title shouldn't have more then 100 characters.")]
        public string Title { get; set; }

        [MaxLength(1500, ErrorMessage = "The description shouldn't have more than 1500 characters.")]
        public string Description { get; set; }
    }
}