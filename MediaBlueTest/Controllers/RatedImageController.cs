using MediaBlueTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaBlueTest.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image/Details/5
        public ActionResult Details(int id)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            Image image = (from i in dbContext.Images where i.ImageId == id select i as Image).FirstOrDefault();
            return View(image);
        }
    }
}
