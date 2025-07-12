using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GuestManagement.Data
{
    public class ApplicationDbContext(DbContextOptions options) : IdentityDbContext(options)
    {
    }
}