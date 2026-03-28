using Platform.Application.Models;

namespace Platform.Application.Services;

public interface IUserContextService
{
    UserContext Current { get; }
    event Action? OnChanged;
    void SetUser(Guid? userId, UserRole role);
}
