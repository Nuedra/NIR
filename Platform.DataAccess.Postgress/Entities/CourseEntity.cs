namespace Platform.DataAccess.Postgress
{
    public class CourseEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string AuthorEntity { get; set; } = string.Empty;
        public List<AchievementEntity> Achievements { get; set; } = [];
        public Guid? PreviousID { get; set; }
        public CourseEntity? PreviousCourse { get; set; }
    }
}


