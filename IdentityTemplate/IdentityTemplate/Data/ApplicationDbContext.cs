using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityTemplate.Data
{
    public class ApplicationDbContext(DbContextOptions options) : IdentityDbContext(options)
    {
    }
}