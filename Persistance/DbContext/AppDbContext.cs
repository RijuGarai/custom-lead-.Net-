using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lead>()
                .HasIndex(l => l.TenantId);

            modelBuilder.Entity<Lead>()
                .HasMany(l => l.Details);

            modelBuilder.Entity<Lead>()
                .OwnsOne(l => l.RawDetails, d => d.ToJson());


            modelBuilder.Entity<LeadDynamic>()
                .HasIndex(l => l.TenantId);

            modelBuilder.Entity<LeadDynamic>()
                .HasOne(i => i.Lead)
                .WithMany(l => l.Details)
                .HasForeignKey(l => l.LeadId);


            modelBuilder.Entity<TenantField>()
                .HasIndex(l => l.TenantId);


            modelBuilder.Entity<LeadAutditHistory>()
                .HasIndex(l => l.TenantId);


            modelBuilder.Entity<LeadHistoryVisibility>()
                .HasIndex(l => l.TenantId);

        }
        public DbSet<Tenant> Tenants => Set<Tenant>();
        public DbSet<Lead> Leads => Set<Lead>();
        public DbSet<LeadDynamic> LeadDynamics => Set<LeadDynamic>();
        public DbSet<Field> Fields => Set<Field>();
        public DbSet<TenantField> TenantFields => Set<TenantField>();
        public DbSet<LeadAutditHistory> LeadAutditHistories => Set<LeadAutditHistory>();
        public DbSet<LeadHistoryVisibility> LeadHistoryVisibilities => Set<LeadHistoryVisibility>();

    }
}
