using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NancyDemo_0726.Authorization.User
{
    public class User:IUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public string Id { get; set; }
    }
}