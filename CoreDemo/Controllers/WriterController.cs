using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class WriterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;

        }

        WriterManager wm = new WriterManager(new EfWriterRepository());
        [Authorize]
        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.v = usermail;
            Context c = new Context();
            var writername = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.v2 = writername;
            return View();
        }
        public IActionResult Test()
        {
            return View();
        }

        public  PartialViewResult WriterNavBarPartial()
        {
           
            return PartialView();

        }
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();

        }

        public async Task<IActionResult> EditProfile()
        {

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel()
            {
                namesurname = values.NameSurname,
                username = values.UserName,
                imageurl = values.ImageUrl,
                mail = values.Email,
            };

            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> EditProfile(UserUpdateViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.NameSurname = p.namesurname;
            user.Email = p.mail;
            user.UserName = p.username;
            user.ImageUrl = p.imageurl;
            if (p.Password!=null)
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
            }
            var result=await _userManager.UpdateAsync(user);
            return RedirectToAction("Index","Dashboard");

        }
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer w = new Writer();
            if (p.WriterImage!=null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/WriterImageFiles/{newimagename}");
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newimagename;
            }
            w.WriterMail = p.WriterMail;
            w.WriterName = p.WriterName;
            w.WriterPassword = p.WriterPassword;
            w.WriterStatus = p.WriterStatus;
            w.WriterAbout = p.WriterAbout;

            wm.TAdd(w);
            return RedirectToAction("Index", "Dashboard");

        }
        
    }
}
