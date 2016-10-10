using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicMattersMVC.Models;
using MusicMattersMVC.ViewModels;

namespace MusicMattersMVC.Controllers
{
    public class ProfileController : BaseController
    {
        MusicMattersDBEntities db = new MusicMattersDBEntities();
        // GET: Profile
        public ActionResult Index(int id)
        {
            var profile = from row in db.UserProfile
                          where row.UserId == id
                          select row;

            ViewBag.Profile = profile;
            return View();
        }
    }
}