using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Platform.DataAccess.Postgress;

namespace Platform.API;

public sealed class ListDbConnection
{
    private readonly string _connectionString;

    public ListDbConnection()
        : this(
            Environment.GetEnvironmentVariable("PLATFORM_DB_CONNECTION")
            ?? "Host=localhost;Port=5432;Database=platform;Username=postgres;Password=pass")
    {
    }

    public ListDbConnection(string connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new ArgumentException("Connection string is required.", nameof(connectionString));

        _connectionString = connectionString;
    }

    public void connect()
    {
    }

    public async Task<string> GetUserDataJsonAsync(int studentNumber, CancellationToken cancellationToken = default)
    {
        await using var db = PlatformDatabase.Connect(_connectionString);

        var student = await db.Students
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.StudentNumber == studentNumber, cancellationToken)
            .ConfigureAwait(false);

        if (student is null)
            throw new InvalidOperationException($"Student with number {studentNumber} was not found.");

        if (!string.IsNullOrWhiteSpace(student.AcademicDataJson))
            return student.AcademicDataJson;

        return JsonSerializer.Serialize(
            new
            {
                id = student.StudentNumber,
                name = student.Name,
                surname = student.Surname,
                group = student.Group,
            },
            new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
    }

    public string getUserData(int id) => GetUserDataJsonAsync(id).GetAwaiter().GetResult();
}
