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
            User user = new User();
            return View(user);
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            //TODO Validate before hash
            byte[] pass = System.Text.Encoding.Unicode.GetBytes(user.Pass);
            byte[] salt = GenerateSalt();
            byte[] hash = GenerateHash(pass, salt);

            user.Salt = salt.ToString();
            user.Pass = hash.ToString();

            db.User.Add(user);

            //ModelError()
            return Redirect("/");
        }

        private byte[] GenerateSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[64];
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
    }
}