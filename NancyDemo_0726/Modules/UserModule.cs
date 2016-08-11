using Nancy;
using Nancy.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NancyDemo_0726
{
    [MyAuthorization.JWTAuthorize]
    public class UserModule:NancyModule
    {
        public UserModule():base("/user")
        {
            Get["/{id:int}"] = param =>
              {
                 return  param.id;
              };
            Get["/{email:Email}"] = param =>
              {
                  return param.email;
              };
            Post["/{id}/add/{name}"] = param =>
              {
                  
                  User user = this.Bind<User>("name");
                  return HttpStatusCode.OK;
              };
            Post["/add"] = param =>
              {
                  List<User> user = this.Bind<List<User>>();
                  return HttpStatusCode.OK;
              };
            Get["/id?"] = param =>
              {
                  return param.id;
              };
            After += ctx =>
            {
                
            };
        }
        public class User
        {
            public int id { get; set; }
            public string name { get; set; }
        }
    }
}