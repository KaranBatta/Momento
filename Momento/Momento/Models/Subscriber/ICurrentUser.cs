namespace Momento.Models.Subscriber
{
    public interface ICurrentUser
    {
        bool IsSignedIn { get; }
        bool Email { get; }
        UserSecurityToken UserToken { get; }
    }
}