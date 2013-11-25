using LoginApiApplication;

namespace Momento.Models.Subscriber.UserActions
{
    public interface IUserCoordinator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="userAccount"></param>
        bool AddSimpleUser(User user, UserAccount userAccount);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        User RetrieveSimpleUser(string email);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        User RetrieveSimpleUser(string email, string password);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="updateUser"></param>
        bool EditSimpleUserDetails(User updateUser);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="previousPassword"></param>
        /// <param name="newPassword"></param>
        bool ChangePassword(string username, string previousPassword, string newPassword);
    }
}