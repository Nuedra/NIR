using Microsoft.EntityFrameworkCore;

namespace Platform.DataAccess.Postgress
{
    public class AchievementRepository
    {
        private readonly PlatformDbContext _db;

        public AchievementRepository(PlatformDbContext db)
        {
            _db = db;
        }

            public Task<AchievementEntity?> GetAchievementFullAsync(Guid achievementId)
        {
            return _db.Achievements
                .AsNoTracking()
                .Include(a => a.Course)
                .Include(a => a.Criteria)
                .Include(a => a.StudentAchievements)
                    .ThenInclude(sa => sa.Student)
                .FirstOrDefaultAsync(a => a.Id == achievementId);
        }

            public Task<List<AchievementEntity>> GetCourseAchievementsAsync(Guid courseId)
        {
            return _db.Achievements
                .AsNoTracking()
                .Where(a => a.CourseID == courseId)
                .Include(a => a.Criteria)
                .OrderBy(a => a.Year)
                .ToListAsync();
        }

            public Task<List<StudentAchievementEntity>> GetStudentAchievementsAsync(Guid studentId)
        {
            return _db.StudentAchievements
                .AsNoTracking()
                .Where(x => x.StudentID == studentId)
                .Include(x => x.Achievement)
                    .ThenInclude(a => a.Course)
                .OrderByDescending(x => x.AchievementGotDate)
                .ToListAsync();
        }
    }
}
