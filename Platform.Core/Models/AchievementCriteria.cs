namespace Platform.Core.Models;

public class AchievementCriteria
{
    public AchievementCriteria(Platform.DataAccess.Postgress.AchievementCriteriaEntity entity)
    : this(
        entity.Id,
        entity.IsEnabled,
        entity.Expression,
        entity.AchievementID,
        entity.Achievement != null
            ? new Achievement(entity.Achievement)
            : null!
    )
    {
    }

    private AchievementCriteria(Guid id, bool isEnabled, string expression, Guid achievementID, Achievement achievement)
    {
        Id = id;
        IsEnabled = isEnabled;
        Expression = expression;
        AchievementID = achievementID;
        Achievement = achievement;
    }
    public Guid Id { get;}
    public bool IsEnabled { get; } = true;
    public string Expression { get; } = string.Empty;
    public Guid AchievementID { get; }
    public Achievement Achievement { get; }
}

