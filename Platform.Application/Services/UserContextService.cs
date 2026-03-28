using Platform.Application.Models;

namespace Platform.Application.Services;

public sealed class UserContextService : IUserContextService
{
    public UserContext Current { get; } = new();

    public event Action? OnChanged;

    // Временная заглушка: роль определяется системой по ID, а не выбирается вручную.
    private static readonly Dictionary<Guid, UserRole> KnownRolesByUserId = new();

    public void SetCurrentUserId(Guid? userId)
    {
        Current.UserId = userId;
        Current.Role = ResolveRole(userId);
        OnChanged?.Invoke();
    }

    private static UserRole ResolveRole(Guid? userId)
    {
        if (!userId.HasValue)
        {
            return UserRole.Student;
        }

        return KnownRolesByUserId.GetValueOrDefault(userId.Value, UserRole.Student);
    }
}
