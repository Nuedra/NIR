using Platform.Application.Models;
using Platform.Core.Abstractions;

namespace Platform.Application.Services;

public interface IUserContextService
{
    ICurrentUserContext Current { get; }
    event Action? OnChanged;
    void SetCurrentUserId(Guid? userId);
}
