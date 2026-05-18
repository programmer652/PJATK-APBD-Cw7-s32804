using Microsoft.EntityFrameworkCore;
using WebApplicationCore.Models;

namespace WebApplicationCore.Infrastructure;

public class AppDbContext(DbContextOptions opt) : DbContext(opt)
{
    public DbSet<ComponentManufacturers> ComponentManufacturers { get; set; }
    public DbSet<ComponentTypes> ComponentTypes { get; set; }
    public DbSet<Components> Components { get; set; }
    public DbSet<Pcs> PCs { get; set; }
    public DbSet<PcComponents> PCComponents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ComponentManufacturers>().HasData(
            new ComponentManufacturers
            {
                Id = 1,
                Abbreviation = "M1",
                FullName = "Manufacturer One",
                FoundationDate = new DateOnly(2000, 1, 1)
            },
            new ComponentManufacturers
            {
                Id = 2,
                Abbreviation = "M2",
                FullName = "Manufacturer Two",
                FoundationDate = new DateOnly(2001, 1, 1)
            },
            new ComponentManufacturers
            {
                Id = 3,
                Abbreviation = "M3",
                FullName = "Manufacturer Three",
                FoundationDate = new DateOnly(2002, 1, 1)
            }
        );

        modelBuilder.Entity<ComponentTypes>().HasData(
            new ComponentTypes
            {
                Id = 1,
                Abbreviation = "T1",
                Name = "Type One"
            },
            new ComponentTypes
            {
                Id = 2,
                Abbreviation = "T2",
                Name = "Type Two"
            },
            new ComponentTypes
            {
                Id = 3,
                Abbreviation = "T3",
                Name = "Type Three"
            }
        );

        modelBuilder.Entity<Components>().HasData(
            new Components
            {
                Code = "C000000001",
                Name = "Component A",
                Description = "Test component A",
                ComponentManufacturerId = 1,
                ComponentTypeId = 1
            },
            new Components
            {
                Code = "C000000002",
                Name = "Component B",
                Description = "Test component B",
                ComponentManufacturerId = 2,
                ComponentTypeId = 2
            },
            new Components
            {
                Code = "C000000003",
                Name = "Component C",
                Description = "Test component C",
                ComponentManufacturerId = 3,
                ComponentTypeId = 3
            }
        );

        modelBuilder.Entity<Pcs>().HasData(
            new Pcs
            {
                Id = 1,
                Name = "PC One",
                Weight = 1.1f,
                Warranty = 1,
                CreatedAt = new DateTime(2024, 1, 1),
                Stock = 1
            },
            new Pcs
            {
                Id = 2,
                Name = "PC Two",
                Weight = 2.2f,
                Warranty = 2,
                CreatedAt = new DateTime(2024, 2, 2),
                Stock = 2
            },
            new Pcs
            {
                Id = 3,
                Name = "PC Three",
                Weight = 3.3f,
                Warranty = 3,
                CreatedAt = new DateTime(2024, 3, 3),
                Stock = 3
            }
        );

        modelBuilder.Entity<PcComponents>().HasData(
            new PcComponents { PCId = 1, ComponentCode = "C000000001", Amount = 1 },
            new PcComponents { PCId = 2, ComponentCode = "C000000002", Amount = 1 },
            new PcComponents { PCId = 3, ComponentCode = "C000000003", Amount = 1 }
        );
    }
}