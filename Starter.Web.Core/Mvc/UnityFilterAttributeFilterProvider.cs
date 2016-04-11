using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Starter.Web.Core.Mvc
{
    public class UnityFilterAttributeFilterProvider : FilterAttributeFilterProvider
    {
        private readonly IUnityContainer container;

        public UnityFilterAttributeFilterProvider(IUnityContainer container)
        {
            this.container = container;
        }

        public override IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var filters = base.GetFilters(controllerContext, actionDescriptor);

            foreach (var filter in filters)
            {
                container.BuildUp(filter.Instance.GetType(), filter.Instance);
            }

            return filters;
        }
        //public new IEnumerable<FilterInfo> GetFilters(HttpConfiguration configuration, HttpActionDescriptor actionDescriptor)
        //{
        //    var filters = base.GetFilters(configuration, actionDescriptor);

        //    foreach (var filter in filters)
        //    {
        //        container.BuildUp(filter.Instance.GetType(), filter.Instance);
        //    }

        //    return filters;
        //}

    }
}
