using Platform.Core.Models;

namespace Platform.Core.Abstractions;

public interface ICurrentUserContext
{
    Guid? UserId { get; }
    UserRole Role { get; }
}
