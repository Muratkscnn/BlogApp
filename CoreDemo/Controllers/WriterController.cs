using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]

        public PartialViewResult WriterNavBarPartial()
        {
            return PartialView();

        }
        [AllowAnonymous]

        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();

        }
    }
}
