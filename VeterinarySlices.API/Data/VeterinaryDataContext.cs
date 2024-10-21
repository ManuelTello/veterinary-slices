using Microsoft.EntityFrameworkCore;
using VeterinarySlices.API.Entities;

namespace VeterinarySlices.API.Data
{
    public class VeterinaryDataContext : DbContext
    {
        public VeterinaryDataContext(DbContextOptions<VeterinaryDataContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Audit> Audits { get; set; }
        public DbSet<AccountAudit> AccountAudits { get; set; }
    }
}
