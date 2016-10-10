using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicMattersMVC.ViewModels
{
    public abstract class BaseVM
    {
        public int LoggedInUserId { get; set; }
        public string LoggedInUserName { get; set; }
    }
}