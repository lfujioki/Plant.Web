using Starter.Web.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Starter.Web.Core.Mvc.Filters
{

    public class ViewAuthAttribute : BaseAuthorizationAttribute
    {

        [Microsoft.Practices.Unity.Dependency]
        public IIdentityProvider<string> IdentityProvider { get; set; }


        [Microsoft.Practices.Unity.Dependency]
        public ISecureEntities<string> ISecureEntities { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            if (filterContext != null)
            {
                if (!ValidateArguments(filterContext))
                {
                    filterContext.Result = new HttpUnauthorizedResult();
                }
            }
        }

        protected virtual bool ValidateArguments(AuthorizationContext filterContext)
        {
            bool isValid = false;

            object id = null;
            string userId = this.IdentityProvider.GetCurrentUserId();


            id = GetEntityId(filterContext);

            if(id != null)
            {
                isValid = this.ISecureEntities.IsAuthorized(userId, id, this.Action, this.EntityTypeId);
            }
            

            return isValid;
        }

        protected virtual object GetEntityId(AuthorizationContext filterContext)
        {
            object id = null;
            
            string idField = this.EntityIdField ?? "id";

            ValueProviderResult val = filterContext.Controller.ValueProvider.GetValue(idField);

            if(val!= null && !String.IsNullOrEmpty( val.AttemptedValue))
            {
                id = val.AttemptedValue;
            }

            return id;
        }
    }
}
