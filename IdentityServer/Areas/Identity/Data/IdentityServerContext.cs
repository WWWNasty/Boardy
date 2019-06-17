using IdentityServer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Areas.Identity.Data
{
    public class IdentityServerContext : IdentityDbContext<User>
    {
        public IdentityServerContext(DbContextOptions<IdentityServerContext> options)
            : base(options)
        {
        }
    }
}
