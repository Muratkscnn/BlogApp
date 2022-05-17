using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        [HttpGet]
        [AllowAnonymous]

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer writer)
        {
            WriterValidator wv = new WriterValidator();
            ValidationResult results = wv.Validate(writer);
            if (results.IsValid)
            {
                writer.WriterAbout = "Deneme Test";
                writer.WriterStatus = true;
                wm.TAdd(writer);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            
        }
    }
}
