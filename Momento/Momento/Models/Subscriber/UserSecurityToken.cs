using System;
using LoginApiApplication;

namespace Momento.Models.Subscriber
{
    public class UserSecurityToken
    {
        public UserSecurityToken(User user)
        {
            UserId = user.UserId;
        }

        public Guid UserId { get; set; }
    }
}