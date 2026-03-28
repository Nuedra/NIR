using Platform.Core.Abstractions;
using Platform.Core.Models;

namespace Platform.Application.Models;

public sealed class UserContext : ICurrentUserContext
{
    public Guid? UserId { get; set; }
    public UserRole Role { get; set; } = UserRole.Student;
}
