using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicMattersMVC.Models;
using MusicMattersMVC.ViewModels;
using System.Security.Cryptography;

namespace MusicMattersMVC.Controllers
{
    public class HomeController : BaseController
    {
        MusicMattersDBEntities db = new MusicMattersDBEntities();

        // GET: Home
        public ActionResult Index()
        {
            List<HomeVM> model = new List<HomeVM>();

            var users = from row in db.User
                        select new { row.Id, row.Username };

            foreach (var item in users)
            {
                HomeVM user = new HomeVM();
                user.UserId = item.Id;
                user.UserName = item.Username;
                model.Add(user);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            RegisterVM user = new RegisterVM();
            return View(user);
        }

        [HttpPost]
        public ActionResult Register(RegisterVM user)
        {
            ViewBag.ValidateError = "";
            if (ModelState.IsValid)
            {
                if (ValidateUsernameEmail(user))
                {
                    byte[] pass = System.Text.Encoding.Unicode.GetBytes(user.Pass);
                    byte[] salt = GenerateSalt();
                    byte[] hash = GenerateHash(pass, salt);
                    User newUser = new User();

                    newUser.Username = user.Username;
                    newUser.Email = user.Email;
                    newUser.Salt = BitConverter.ToString(salt).Replace("-", "").ToLower();
                    newUser.Pass = BitConverter.ToString(hash).Replace("-", "").ToLower();

                    db.User.Add(newUser);
                    db.SaveChanges();

                    UserProfile newProfile = new UserProfile();
                    newProfile.UserId = newUser.Id;
                    newProfile.ShowEmail = 0;
                    newProfile.BackgroundColor = "#FFFFFF";

                    db.UserProfile.Add(newProfile);
                    db.SaveChanges();
                }
                else
                    ViewBag.ValidateError = "Username or Email address already exists!";
                return Redirect("/");
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult Login()
        {
            LoginVM user = new LoginVM();
            return View(user);
        }

        [HttpPost]
        public ActionResult Login(LoginVM user)
        {
            ViewBag.ValidationError = "";
            if (ModelState.IsValid)
            {
                var saltResult = from item in db.User
                             where item.Username == user.Username
                             select item.Salt;
                if (saltResult.Count() == 1)
                {
                    byte[] salt = Convert.FromBase64String(saltResult.First());
                    byte[] pass = Convert.FromBase64String(user.Pass);
                    byte[] hash = GenerateHash(pass, salt);
                    string hashedPass = BitConverter.ToString(hash).Replace("-", "").ToLower();

                    var loginResult = from item in db.User
                                     where item.Username == user.Username && item.Pass == hashedPass
                                     select item.Count();
                    if (loginResult == 1)
                    {
                        //Authorize
                        return Redirect("/");
                    }
                }
                ViewBag.ValidationError = "Username or password is incorrect.";
            }
            return View(user);
        }

        private byte[] GenerateSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[32];
            rng.GetBytes(salt);
            rng.Dispose();
            return salt;
        }

        private byte[] GenerateHash(byte[] pass, byte[] salt)
        {
            byte[] combined = new byte[pass.Length + salt.Length];
            Buffer.BlockCopy(pass, 0, combined, 0, pass.Length);
            Buffer.BlockCopy(salt, 0, combined, pass.Length, salt.Length);
            HashAlgorithm hashAlgo = new SHA256Managed();
            byte[] hash = hashAlgo.ComputeHash(combined);
            return hash;
        }

        private bool ValidateUsernameEmail(RegisterVM user)
        {
            var result = (from item in db.User
                         where item.Username == user.Username || item.Email == user.Email
                         select item).Count();
            if (result == 1)
                return false;
            else
                return true;
        }

        private void CreateProfile(int userId)
        {
            
        }
    }
}