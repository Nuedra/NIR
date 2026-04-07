namespace Platform.DataAccess.Postgress
{
    public class StudentEntity
    {
        public Guid Id { get; set; }
        public int? StudentNumber { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Group { get; set; } = string.Empty;
        public string? AcademicDataJson { get; set; }

        // Временное поле: сохраняем внешний номер "как пришел", формат пока не утвержден.
        // На текущем этапе бизнес-логика это поле не использует.
        public string? ExternalStudentNumberRaw { get; set; }

        public List<StudentAchievementEntity> StudentAchievements { get; set; } = [];
    }
}