using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Context
{
    public class jwtcontext : IdentityDbContext<AppUser>
    {
        public jwtcontext(DbContextOptions<jwtcontext> options)
         : base(options)
        {
        }

        // i dont make set of product because i implement on only users and jwt
    }
}
