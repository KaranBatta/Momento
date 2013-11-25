using System;
using System.Web.Mvc;
using LoginApiApplication;
using Momento.Models;
using IUserCoordinator = Momento.Models.Subscriber.UserActions.IUserCoordinator;
using UserCoordinator = Momento.Models.Subscriber.UserActions.UserCoordinator;

namespace Momento.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Login(MemberViewModel viewModel)
        {
            IUserCoordinator userCoordinator = new UserCoordinator(new UserContext());
            var user = userCoordinator.RetrieveSimpleUser(viewModel.Username, viewModel.Password);
            if (user != null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                throw new Exception("Login didn't work... :-(");
            }
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Index");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Signup(MemberViewModel viewModel)
        {
            IUserCoordinator userCoordinator = new UserCoordinator(new UserContext());
            var user = userCoordinator.AddSimpleUser(
                new User
                {
                    UserId = Guid.NewGuid(),
                    Email = viewModel.Username
                },
                new UserAccount
                {
                    UserAccountId = Guid.NewGuid(),
                    IsAdmin = false,
                    SignupDate = DateTime.Today,
                    IsAuthorized = true,
                    Locked = false,
                    Username = viewModel.Username,
                    Password = viewModel.Password,
                    LastLogin = DateTime.UtcNow
                });

            if (user)
            {
                return RedirectToAction("Index", "Account", viewModel);
            }
            else
            {
                throw new Exception("Signup threw some exception :-(");
            };
        }
    }
}
