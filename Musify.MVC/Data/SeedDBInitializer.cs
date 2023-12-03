using Microsoft.EntityFrameworkCore;
using Musify.MVC.Models.Entities;
namespace Musify.MVC.Data
{
    public static class SeedDBInitializer
    {
        static List<User> Authors = new List<User>
        {
            new User
            {
                UserName = "MBorhamy",
                Email = "borhamy@musify.com"

            },
            new User
            {
                UserName = "MLabib",
                Email = "labib@musify.com"
            },
        };
        static Album Album = new()
        {
            Name = "Plan B",
        };
        static List<Song> Songs = new List<Song>()
        {
            new Song {
                Name="Ta2reban",
                ReleaseAt = DateTime.Now,
                Tag=Tag.Rap,
                Type=Models.Entities.Type.Arabic,

                },
            new Song {
                Name="Fantasy",
                ReleaseAt = DateTime.Now,
                Tag=Tag.Rap,
                Type=Models.Entities.Type.Arabic,
                },
             new Song {
                Name="Plan b",
                ReleaseAt = DateTime.Now,
                Tag=Tag.Rap,
                Type=Models.Entities.Type.Arabic,
                },
        };
        public static void PopulateData(IApplicationBuilder app)
        {
            MusifyDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<MusifyDbContext>();
            if (context.Database.GetPendingMigrations().Any())
                context.Database.Migrate();
            if (!context.Songs.Any())
            {
                context.Authors.AddRange(
                        Authors);
                context.Artists.AddRange(
                    new Artist
                    {
                        UserName = "Lege-Cy",
                        Email = "Lege@musify.com",
                        Followers = Authors,
                        FollowersCount = Authors.Count,
                        Albums = new List<Album>() { Album },
                        Songs = Songs,
                    });
                context.Albums.AddRange(
                    new List<Album> { Album });
                context.Songs.AddRange(
                    Songs);
                context.Playlists.AddRange(
                    new Playlist
                    {
                        Author = Authors[1],
                        IsPublic = true,
                        Songs = Songs,
                        Name = "FAV-Lege-cy",
                        Shuffle = true,
                    });

            }

            context.SaveChanges();

        }


    }
}

