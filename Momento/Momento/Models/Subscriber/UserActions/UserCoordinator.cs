using System;
using System.Linq;
using LoginApiApplication;
using PasswordHash = Momento.Models.Subscriber.Extensions.PasswordHash;
using StringExtensions = Momento.Models.Subscriber.Extensions.StringExtensions;

namespace Momento.Models.Subscriber.UserActions
{
    /// <summary>
    /// 
    /// </summary>
    public class UserCoordinator : IUserCoordinator
    {
        private readonly UserContext _context;

        public UserCoordinator(UserContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="userAccount"></param>
        public bool AddSimpleUser(User user, UserAccount userAccount)
        {
            var existingUser = RetrieveSimpleUser(user.Email);

            if (existingUser != null)
            {
                throw new Exception("This user with the assosiated Email Address already exists.");
            }

            if (!StringExtensions.IsValidEmail(user.Email))
            {
                throw new Exception("Email Address entered isn't valid.");
            }

            var addUser = new User
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                Address = user.Address,
                Email = user.Email,
                Company = user.Company,
                PhoneNumber = user.PhoneNumber,
            };

            var addUserAccount = new UserAccount()
            {
                IsAdmin = userAccount.IsAdmin,
                ConfirmedEmail = userAccount.ConfirmedEmail,
                IsAuthorized = userAccount.IsAuthorized,
                LastLogin = userAccount.LastLogin,
                SignupDate = userAccount.SignupDate,
                Locked = userAccount.Locked,
                LoginAttempts = userAccount.LoginAttempts,
                Username = userAccount.Username,
                Password = PasswordHash.CreateHash(userAccount.Password),
                UserAccountId = userAccount.UserAccountId,
                UserUserId = user.UserId,
            };
            try
            {
                _context.Users.Add(addUser);
                _context.UserAccounts.Add(addUserAccount);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public User RetrieveSimpleUser(string email)
        {
            var existingUser = from user in _context.Users where user.Email.Equals(email) select user;
            return Enumerable.FirstOrDefault(existingUser);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User RetrieveSimpleUser(string email, string password)
        {
            var existingUser = from user in _context.Users where user.Email.Equals(email) select user;

            foreach (var user in existingUser)
            {
                var isPasswordValid = PasswordHash.ValidatePassword(password, user.UserAccounts.First().Password);
                if (isPasswordValid)
                {
                    return user;
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="updatedUser"></param>
        public bool EditSimpleUserDetails(User updatedUser)
        {
            var existingUser = RetrieveSimpleUser(updatedUser.Email);

            if (existingUser == null)
            {
                throw new Exception("This user does not exist so cannot edit.");
            }

            existingUser.FirstName = updatedUser.FirstName;
            existingUser.LastName = updatedUser.LastName;
            existingUser.DateOfBirth = updatedUser.DateOfBirth;
            existingUser.Address = updatedUser.Address;
            existingUser.Email = updatedUser.Email;
            existingUser.Company = updatedUser.Company;
            existingUser.PhoneNumber = updatedUser.PhoneNumber;

            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="previousPassword"></param>
        /// <param name="newPassword"></param>
        public bool ChangePassword(string username, string previousPassword, string newPassword)
        {
            var existingUser = RetrieveSimpleUser(username, previousPassword);

            if (existingUser == null)
            {
                throw new Exception("This user does not exist so cannot change password.");
            }

            try
            {
                var newPasswordHash = PasswordHash.CreateHash(newPassword);

                existingUser.UserAccounts.FirstOrDefault().Password = newPasswordHash;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;   
            }
        }
    }
}