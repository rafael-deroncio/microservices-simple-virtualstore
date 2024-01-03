namespace VirtualStore.Identity.Core.Managers.Interfaces;

/// <summary>
/// Represents a manager interface for initializing seed users.
/// </summary>
public interface IUserManager
{
    /// <summary>
    /// Initializes seed users in the system.
    /// </summary>
    /// <returns>An asynchronous task representing the initialization operation.</returns>
    Task InitializeSeedUsers();
}