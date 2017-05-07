using Identity;
using Identity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Identity {
    public class ApiUserManager : UserManager<ApiUser>
    {
        public ApiUserManager(IUserStore<ApiUser> store)
            : base(store)
        {
        }
 
        public static ApiUserManager Create(IdentityFactoryOptions<ApiUserManager> options, IOwinContext context)
        {
            var appDbContext = context.Get<IdentityContext>();
            var appUserManager = new ApiUserManager(new UserStore<ApiUser>(appDbContext));
 
            return appUserManager;
        }
    }
}