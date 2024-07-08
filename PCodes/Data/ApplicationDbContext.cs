using Microsoft.EntityFrameworkCore;
using PCodes.Models;

namespace PCodes.Data;

public partial class ApplicationDbContext : DbContext
{
    public DbSet<District> Districts { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<Town> Towns { get; set; }
    public DbSet<Township> Townships { get; set; }
    public DbSet<Village> Villages { get; set; }
    public DbSet<VillageTract> VillageTracts { get; set; }
    public DbSet<Ward> Wards { get; set; }

    public ApplicationDbContext()
    { }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<District>(entity =>
        {
            entity.HasIndex(e => e.StateId, "IX_Districts_StateId");

            entity.HasOne(d => d.State)
                .WithMany(p => p.Districts)
                .HasForeignKey(d => d.StateId)
                //.OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Districts_States");
        });

        modelBuilder.Entity<Town>(entity =>
        {
            entity.HasIndex(e => e.TownshipId, "IX_Towns_TownshipId");

            entity.HasOne(d => d.Township)
                .WithMany(p => p.Towns)
                .HasForeignKey(d => d.TownshipId)
                //.OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Towns_Townships");
        });

        modelBuilder.Entity<Township>(entity =>
        {
            entity.HasIndex(e => e.DistrictId, "IX_Townships_DistrictId");

            entity.HasOne(d => d.District)
                .WithMany(p => p.Townships)
                .HasForeignKey(d => d.DistrictId)
                //.OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Townships_Districts");
        });

        modelBuilder.Entity<Village>(entity =>
        {
            entity.HasIndex(e => e.VillageTractId, "IX_Villages_VillageTractId");

            entity.HasOne(d => d.VillageTract)
                .WithMany(p => p.Villages)
                .HasForeignKey(d => d.VillageTractId)
                //.OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Villages_VillageTracts");
        });

        modelBuilder.Entity<VillageTract>(entity =>
        {
            entity.HasIndex(e => e.TownshipId, "IX_VillageTracts_TownshipId");

            entity.HasOne(d => d.Township)
                .WithMany(p => p.VillageTracts)
                .HasForeignKey(d => d.TownshipId)
                //.OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VillageTracts_Townships");
        });

        modelBuilder.Entity<Ward>(entity =>
        {
            entity.HasIndex(e => e.TownId, "IX_Wards_TownId");

            entity.HasOne(d => d.Town)
                .WithMany(p => p.Wards)
                .HasForeignKey(d => d.TownId)
                //.OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Wards_Towns");
        });

        // Restrict cascading deletes
        foreach (var relationship in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
