using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace Momento.Code.Authentication
{
    public interface IAuthenticationService
    {
        void Login(string username, string password, bool isPersistant);
        void Logout();
    }
}