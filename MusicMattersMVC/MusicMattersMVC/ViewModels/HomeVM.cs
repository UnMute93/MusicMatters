using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicMattersMVC.ViewModels
{
    public class HomeVM : BaseVM
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}