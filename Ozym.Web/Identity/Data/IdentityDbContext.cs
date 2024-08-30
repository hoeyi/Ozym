using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ozym.Web.Identity.Data;

public partial class IdentityDbContext(
    DbContextOptions<IdentityDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
}
