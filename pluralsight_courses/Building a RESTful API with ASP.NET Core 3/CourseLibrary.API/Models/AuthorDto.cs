using System;

namespace CourseLibrary.API.Models
{
    public  class AuthorDto
    {        
        public Guid Id { get; set; }

        public string FirstName { get; set; }
     
        public string LastName { get; set; }

        public int Age { get; set; }
        public string Name { get; internal set; }

        public string MainCategory { get; set; }


    }
}