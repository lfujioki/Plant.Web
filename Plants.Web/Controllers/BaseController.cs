
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plants.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
        }

        protected T GetViewModel<T, U>() where T : new()
        {
            T model = new T();
            return model;
        }
    }
}