using Microsoft.EntityFrameworkCore;
using Platform.DataAccess.Postgress;
using Platform.Core.Parsing;
using Platform.Core.Evaluation;
using Platform.Core.Models;
using Platform.API;

namespace Platform.Core
{
    public static class Activities
    {
        public static async Task MainProcess(int studentNumber)
        {
            string connectionString =
                "Host=localhost;Port=5432;Database=platform;Username=postgres;Password=pass";

            await using var db = PlatformDatabase.Connect(connectionString);

            // 3) Грузим ачивки + критерии (только нужное) сырые данные из БД
            var achievementEntities = await db.Achievements
                .AsNoTracking()
                .Include(a => a.Criteria)
                .ToListAsync();

            // 3.1) Маппим в элементы доменной модели
            var achievements = achievementEntities
                .Select(e => new Achievement(e))
                .ToList();

            // 4) Получаем данные студента из JSON
            var listDb = new ListDbConnection();
            listDb.connect();
            var student = JsonDataParser.ParseToDictionary(
                listDb.getUserData(studentNumber)
            );

            // 5) Отбираем подходящие ачивки уже по обёрткам
            var matchedAchievements = achievements
                .Where(a => a.Criteria != null)
                .Where(a => a.Criteria.IsEnabled)
                .Where(a => AchievementsCriteriaEvalEvaluator.
                    Evaluate(a.Criteria.Expression, student)
                ).ToList();

            // (если нужен вывод)
            // foreach (var a in matchedAchievements)
            //     Console.WriteLine($"[{a.Id}] {a.Title} | {a.Criteria.Expression}");
        }
    }
}
