using Platform.Core.Abstractions;
using Platform.Core.Models;

namespace Platform.Application.Services
{
    public class CoursesService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CoursesService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<List<Course>> GetAllCourses()
        {
            return await _courseRepository.Get();
        }

        public async Task<Guid> CreateCourse(Course course)
        {
            return await _courseRepository.Create(course);
        }

        public async Task<Guid> UpdateCourse(Guid id, string title, string description)
        {
            return await _courseRepository.Update(id, title, description);
        }

        public async Task<Guid> DeleteCourse(Guid id)
        {
            return await _courseRepository.Delete(id);
        }
    }
}