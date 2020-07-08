using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CourseLibrary.API.Models;
using CourseLibrary.API.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace CourseLibrary.API.Controllers
{
    [ApiController]
    [Route("api/authors/{authorId}/courses")]
    public class CoursesController : ControllerBase
    {

        private readonly ICourseLibraryRepository _courseLibraryRepository;
        private readonly IMapper _mapper;

        public CoursesController(ICourseLibraryRepository courseLibraryRepository, IMapper mapper)
        {
            _courseLibraryRepository = courseLibraryRepository ??
                throw new ArgumentNullException(nameof(courseLibraryRepository));
            _mapper = mapper ??
                 throw new ArgumentNullException(nameof(mapper));

        }

        [HttpGet()]
        public ActionResult<IEnumerable<CourseDto>> GetCourses(Guid authorId)
        {
            if (!_courseLibraryRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var coursesFromRepo = _courseLibraryRepository.GetCourses(authorId);

            return Ok(_mapper.Map<IEnumerable<CourseDto>>(coursesFromRepo));
        }

        [HttpGet("{courseId}", Name = "GetCourseForAuthor")]
        public ActionResult<CourseDto> GetCourseForAuthor(Guid authorId, Guid courseId)
        {

            if (!_courseLibraryRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var courseForAuthorFromRepo = _courseLibraryRepository.GetCourse(authorId, courseId);

            if (courseForAuthorFromRepo == null)
            {
                return NotFound();
            }

            var courseForReturn = _mapper.Map<CourseDto>(courseForAuthorFromRepo);

            return Ok(courseForReturn);

        }


        [HttpPost]
        public ActionResult<CourseDto> CreateCourseForAuthor(Guid authorId, CourseForCreationDto courseDtoForCreation)
        {
            var courseEntity = _mapper.Map<Course>(courseDtoForCreation);
            _courseLibraryRepository.AddCourse(authorId, courseEntity);
            _courseLibraryRepository.Save();
            var courseToReturn = _mapper.Map<CourseDto>(courseEntity);

            return CreatedAtRoute("GetCourseForAuthor", new { authorId = authorId, courseId = courseToReturn.Id }, courseToReturn);

        }


        [HttpOptions]
        public IActionResult GetCoursesOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST");
            return Ok();
        }

        [HttpPut("{courseId}")]
        public ActionResult UpdateCourseForAuthor(Guid authorId, Guid courseId, CourseForUpdateDto courseForUpdateDto)
        {
            if (!_courseLibraryRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var courseToUpdateFromRepo = _courseLibraryRepository.GetCourse(authorId, courseId);
            if (courseToUpdateFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(courseForUpdateDto, courseToUpdateFromRepo);

            _courseLibraryRepository.UpdateCourse(courseToUpdateFromRepo);

            _courseLibraryRepository.Save();

            return NoContent();

        }

        [HttpPatch("{courseId}")]
        public ActionResult PartllyUpdateCourseForAuthor(
            Guid authorId, Guid courseId, 
            JsonPatchDocument<CourseForUpdateDto> patchDocument)
        {

            if (!_courseLibraryRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var courseToUpdateFromRepo = _courseLibraryRepository.GetCourse(authorId, courseId);
            if (courseToUpdateFromRepo == null)
            {
                return NotFound();
            }

            var courseToPatch = _mapper.Map<CourseForUpdateDto>(courseToUpdateFromRepo);

            patchDocument.ApplyTo(courseToPatch);

            _mapper.Map(courseToPatch, courseToUpdateFromRepo);

            _courseLibraryRepository.UpdateCourse(courseToUpdateFromRepo);

            _courseLibraryRepository.Save();
            return NoContent();

        }
    }
}