using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicMattersMVC.Models;

namespace MusicMattersMVC.ViewModels
{
    public class ProfileVM
    {
        public string UserName { get; set; }
        public string UserAvatar { get; set; }
        public string ProfileBio { get; set; }
        public string ProfileColor { get; set; }
        public bool ProfileShowEmail { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Flag> Flags { get; set; }
        public List<Artist> Artists { get; set; }
    }
}