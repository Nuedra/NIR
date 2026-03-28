using Platform.Core.Models;

namespace Platform.Core.Abstractions;

public interface IAccessPolicyService
{
    bool Can(UserRole role, Permission permission);
}
