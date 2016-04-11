using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plants.Web.Models.ViewModels
{
    public class ItemsViewModel<T, U> : BaseViewModel
    {
        public List<T> Items { get; set; }

        public U Item { get; set; }
    }
}