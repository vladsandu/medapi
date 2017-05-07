using System.Security.Claims;
using System.Threading.Tasks;
using DataAccess.Entities.Character;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Identity.Models {
    public class ApiUser : IdentityUser{
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApiUser> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}