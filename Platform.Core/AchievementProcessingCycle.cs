using Microsoft.EntityFrameworkCore;
using Platform.API;
using Platform.Core.Evaluation;
using Platform.Core.Models;
using Platform.Core.Parsing;
using Platform.DataAccess.Postgress;

namespace Platform.Core.Processing;

public sealed class AchievementProcessingCycle
{
    private readonly string _connectionString;

    public AchievementProcessingCycle(string connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new ArgumentException("Connection string is required.", nameof(connectionString));

        _connectionString = connectionString;
    }

    public async Task<AchievementProcessingResult> RunAsync(int studentNumber, CancellationToken cancellationToken = default)
    {
        await using var db = PlatformDatabase.Connect(_connectionString);

        var achievementEntities = await db.Achievements
            .AsNoTracking()
            .Include(a => a.Criteria)
            .ToListAsync(cancellationToken);

        var achievements = achievementEntities
            .Select(entity => new Achievement(entity))
            .ToList();

        var listDb = new ListDbConnection();
        listDb.connect();

        var studentData = JsonDataParser.ParseToDictionary(
            listDb.getUserData(studentNumber)
        );

        var matched = new List<Achievement>();
        var checkedCount = 0;

        foreach (var achievement in achievements)
        {
            var criteria = achievement.Criteria;
            if (criteria == null || !criteria.IsEnabled)
                continue;

            checkedCount++;

            if (AchievementsCriteriaEvalEvaluator.Evaluate(criteria.Expression, studentData))
                matched.Add(achievement);
        }

        return new AchievementProcessingResult(
            TotalAchievements: achievements.Count,
            CheckedAchievements: checkedCount,
            MatchedAchievements: matched
        );
    }
}

public sealed record AchievementProcessingResult(
    int TotalAchievements,
    int CheckedAchievements,
    IReadOnlyList<Achievement> MatchedAchievements
);
