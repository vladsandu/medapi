using Identity.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Identity {
    public class IdentityContext : IdentityDbContext<ApiUser>{
        public IdentityContext()
            : base("name=DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public static IdentityContext Create()
        {
            return new IdentityContext();
        }
    }
}