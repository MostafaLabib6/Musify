using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Musify.MVC.Models.Entities;

namespace Musify.MVC.Data;

public class MusifyDbContext : DbContext
{
    public DbSet<Song> Songs { get; set; }
    public DbSet<Playlist> Playlists { get; set; }
    public DbSet<Album> Albums { get; set; }

    public MusifyDbContext(DbContextOptions<MusifyDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}
