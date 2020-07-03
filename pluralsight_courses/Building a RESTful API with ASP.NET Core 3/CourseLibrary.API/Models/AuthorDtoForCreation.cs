using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseLibrary.API.Models
{
    public class AuthorDtoForCreation
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string MainCategory { get; set; }

        public ICollection<CourseDtoForCreation> Courses {get; set;}
            = new List<CourseDtoForCreation>();
    }
}