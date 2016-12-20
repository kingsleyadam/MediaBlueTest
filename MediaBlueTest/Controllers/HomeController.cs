using MediaBlueTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaBlueTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Construct our application db context and home view model to pass to the view
            ApplicationDbContext dbContext = new ApplicationDbContext();
            HomeViewModel homeViewModel = new HomeViewModel();
            
            //Get the list of images from the database
            homeViewModel.ImageList = dbContext.Images.ToList();

            //Populated the scale list for each Image.ScaleItems property with the same scale
            List<Scale> scaleList = dbContext.Scales.ToList();
            foreach (Image r in homeViewModel.ImageList)
            {
                r.ScaleItems = scaleList;
            }

            return View(homeViewModel);
        }

        [HttpPost]
        public ActionResult Index(HomeViewModel model)
        {
            //Construct our application db context
            ApplicationDbContext dbContext = new ApplicationDbContext();

            //Add new SessionSubmit to database
            Session currentSession = dbContext.Sessions.First(s => s.SessionId == Session.SessionID);
            SessionSubmit sSubmit = new Models.SessionSubmit { Session = currentSession, SubmitDate = DateTime.Now };
            dbContext.SessionSubmits.Add(sSubmit);
            dbContext.SaveChanges();

            //Construct our list of SessionSubmitScale
            List<SessionSubmitScale> sessionSubmitScaleList = new List<SessionSubmitScale>();
            List<Scale> scaleList = dbContext.Scales.ToList();
            List<Image> imageList = dbContext.Images.ToList();
            foreach (Image r in model.ImageList)
            {
                if (r.SelectedScaleId != 0)
                {
                    Scale scale = scaleList.First(s => s.ScaleId == r.SelectedScaleId);
                    Image image = imageList.First(i => i.ImageId == r.ImageId);
                    sessionSubmitScaleList.Add(new SessionSubmitScale { SessionSubmit = sSubmit, Scale = scale, Image = image });
                }
            }

            //Add list to database
            dbContext.SessionSubmitScales.AddRange(sessionSubmitScaleList);
            dbContext.SaveChanges();

            //Construct our view model then pass it to the submit view
            HomeViewModelSubmit riViewModelSubmit = new HomeViewModelSubmit { SessionSubmit = sSubmit, SessionSubmitScaleList = sessionSubmitScaleList.OrderByDescending(s => s.Scale.Weight).ToList() };
            return View("View", riViewModelSubmit);
        }
    }
}