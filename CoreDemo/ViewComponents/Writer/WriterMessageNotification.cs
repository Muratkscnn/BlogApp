using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Message2Manager mm = new Message2Manager(new EfMessage2Repository());
            int id = 2;
            var values = mm.GetInBoxListByWriter(id);
            return View(values);
        }
    }
}
