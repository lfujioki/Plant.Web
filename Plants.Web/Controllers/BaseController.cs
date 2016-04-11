
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Starter.Web.Controllers
{
    public class BaseController : Controller
    {
        protected T GetViewModel<T, U>() where T : new()
        {
            T model = new T();
            return model;
        }
    }
}