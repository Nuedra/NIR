using Platform.Application.Models;
using Platform.Core.Abstractions;
using Platform.Core.Models;

namespace Platform.Application.Services;

public sealed class UserContextService : IUserContextService
{
    private UserContext MutableCurrent { get; } = new();
    public ICurrentUserContext Current => MutableCurrent;

    public event Action? OnChanged;

    // Временная заглушка: роль определяется системой по ID, а не выбирается вручную.
    private static readonly Dictionary<Guid, UserRole> KnownRolesByUserId = new();

    public void SetCurrentUserId(Guid? userId)
    {
        MutableCurrent.UserId = userId;
        MutableCurrent.Role = ResolveRole(userId);
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
