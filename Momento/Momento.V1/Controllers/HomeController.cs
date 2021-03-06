﻿using System.Collections.Generic;
using System.Web.Mvc;
using Momento.V1.Models;

namespace Momento.V1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome User to this awesome app!";
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index(Memories viewModel)
        {
            if (viewModel == null || viewModel.MemoryList == null)
            {
                return View(new Memories{MemoryList = new List<Memory>{new Memory()}});
            }

            if (viewModel.MemoryList.Count >= 1)
            {
                return View(viewModel);
            }

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddMemory(Memories viewModel)
        {
            return View("Index", viewModel);
        }
    }
}
