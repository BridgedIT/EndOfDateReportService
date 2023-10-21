using EndOfDateReportService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EndOfDateReportService.DataAccess;

public class ReportContext: DbContext
{
    public ReportContext(DbContextOptions<ReportContext> options) : base(options)
    {
        ChangeTracker.LazyLoadingEnabled = false;
    }
    public DbSet<Note> Notes { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Lane> Lanes { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var navigation in entityType.GetNavigations())
            {
                navigation.SetPropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
            }
        }
        modelBuilder.Entity<Branch>().HasMany<Lane>().WithOne(x => x.Branch).HasForeignKey(x => x.BranchId)
            .IsRequired();
           
        modelBuilder.Entity<Lane>().HasMany<PaymentMethod>().WithOne(x => x.Lane).HasForeignKey(x => x.LaneId)
            .IsRequired();
        modelBuilder.Entity<Lane>().Property(x => x.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Lane>().HasOne(x => x.Branch).WithMany(x => x.Lanes)
            .HasForeignKey(x => x.BranchId);


        modelBuilder.Entity<PaymentMethod>().HasOne(x => x.Lane).WithMany(x => x.PaymentMethods)
            .HasForeignKey(x => x.LaneId);
        modelBuilder.Entity<PaymentMethod>().HasIndex(x => new { x.Name, x.LaneId, x.BranchId, x.ReportDate })
            .IsUnique();
        modelBuilder.Entity<PaymentMethod>().Property(x => x.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<PaymentMethod>().HasKey(x => x.Id);

        modelBuilder.Entity<User>().HasKey(x => x.Id);


        modelBuilder.Entity<Branch>().HasData(
            new Branch()
            {
                Id = 1,
                Name = "Moore Wilsons Wellington",
            },
            new Branch()
            {
                Id = 2,
                Name = "Moore Wilsons Porirua"
            }, new Branch()
            {
                Id = 3,
                Name = "Moore Wilsons Lower Hutt"
            }, new Branch()
            {
                Id = 4,
                Name = "Moore Wilsons Masterton"
            }
        );
        
        
        
        
        base.OnModelCreating(modelBuilder);

    }
}