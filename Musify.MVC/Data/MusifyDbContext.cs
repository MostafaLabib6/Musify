using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Musify.MVC.Models.Entities;

namespace Musify.MVC.Data;

public class MusifyDbContext : IdentityDbContext<User>
{
    public DbSet<Song> Songs { get; set; }
    public DbSet<Playlist> Playlists { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<User> Authors { get; set; }
    public MusifyDbContext(DbContextOptions<MusifyDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Song>()
        .HasIndex(e => e.ReleaseAt); //sort by the newest.
    }

}
