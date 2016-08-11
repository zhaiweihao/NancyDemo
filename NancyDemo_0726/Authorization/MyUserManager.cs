using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.OptionsModel;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NancyDemo_0726.Authorization
{
    public  class MyUserManager<TUser,TKey> : UserManager<TUser,string> where TUser:User.User
    {
        public MyUserManager(IUserStore<TUser, string> store) : base(store)
        {
        }
        public async Task<LoginResult> CreateLoginResult(TUser user)
        {
            return new LoginResult(user, await CreateIdentityAsync(user, "success"), "success");
        }
        public  override async  Task<ClaimsIdentity> CreateIdentityAsync(TUser user, string authenticationType)
        {
            var identity=await  base.CreateIdentityAsync(user, authenticationType);
            identity.AddClaim(new Claim("UserRole", "TestUser"));
            return identity;
        }
        public class LoginResult
        {
            public LoginResult(TUser user, ClaimsIdentity identity,string result)
            {
                Identity = identity;
                User = user;
                Result = result;
            }
            public ClaimsIdentity Identity { get; private set; }
            public string Result { get; private set; }
            public TUser User { get; private set; }
        }
    }
}