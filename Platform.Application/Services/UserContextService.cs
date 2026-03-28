using Platform.Application.Models;

namespace Platform.Application.Services;

public sealed class UserContextService : IUserContextService
{
    public UserContext Current { get; } = new();

    public event Action? OnChanged;

    public void SetUser(Guid? userId, UserRole role)
    {
        Current.UserId = userId;
        Current.Role = role;
        OnChanged?.Invoke();
    }
}
