using Platform.Core.Models;

namespace Platform.Application.Services
{
    public interface ICourseService
    {
        Task<Guid> CreateCourse(Course course);
        Task<Guid> DeleteCourse(Guid id);
        Task<List<Course>> GetAllCourses();
        Task<Guid> UpdateCourse(Guid id, string title, string description);
    }
}