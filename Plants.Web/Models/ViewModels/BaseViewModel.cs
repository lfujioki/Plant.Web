using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plants.Web.Models.ViewModels
{
    public class BaseViewModel
    {
        public string PageTitle { get; set; }
        public string UserName { get; set; }
        public string ApplicationName { get; set; }
    }
}