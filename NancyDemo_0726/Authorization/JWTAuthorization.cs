using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace NancyDemo_0726.MyAuthorization
{
    public class JWTAuthorizeAttribute:AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //base.OnAuthorization(actionContext);
            try
            {
                string token = actionContext.Request.Headers.Authorization.ToString();
                byte[] secretKey = System.Text.Encoding.Default.GetBytes("scretkey");
                JWT.JsonWebToken.Decode(token, secretKey);
            }
            catch (Exception ex)
            {
                base.OnAuthorization(actionContext);
            }
        }
    }
}