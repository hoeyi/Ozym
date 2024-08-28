using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ozym.Web.Identity.Data;

namespace Ozym.Web.Identity.Data;

public partial class IdentityDbContext(
    DbContextOptions<IdentityDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
}
