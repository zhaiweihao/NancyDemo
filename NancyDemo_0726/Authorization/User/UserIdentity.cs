using Microsoft.AspNet.Identity;
using Nancy.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace NancyDemo_0726.Authorization.User
{
    public class UserIdentity : IUserIdentity
    {
        public IEnumerable<string> Claims { get; set; }
        public string UserName { get; set; }
    }
    public class UserStore<TUser> : IUserStore<TUser, string> where TUser : User
    {
        public Task CreateAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<TUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<TUser> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TUser user)
        {
            throw new NotImplementedException();
        }
    }
}