using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Starter.Web.Core.Mvc.Filters
{
    public class BaseAuthorizationAttribute : AuthorizeAttribute
    {
        public string EntityIdField { get; set; }

        public int EntityTypeId { get; set; }

        public EntityActionType Action { get; set; }

        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
            return base.AuthorizeCore(httpContext);
        }


       
    }
}
