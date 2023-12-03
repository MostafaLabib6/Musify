using Microsoft.EntityFrameworkCore;
using Musify.MVC.Data;
using Musify.MVC.Persistance;

namespace Musify.MVC.Repositories;

public class ALLForOne : IALLForOne
{
    private IAlbumRepository _albumReposioty { get; set; }
    private IArtistRepository _artistRepository { get; set; }
    private IAuthorRepository _authorRepository { get; set; }
    private ISongRepository _songRepository { get; set; }
    private IPlaylistRepository _playlistRepository { get; set; }

    private readonly MusifyDbContext _dbContext;

    public ALLForOne(MusifyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IAlbumRepository AlbumRepository
    {
        get
        { return _albumReposioty ?? new AlbumReposioty(_dbContext); }
    }
    public IArtistRepository ArtistRepository { get { return _artistRepository ?? new ArtistRepository(_dbContext); } }
    public IAuthorRepository AuthorRepository { get { return _authorRepository ?? new AuthorRepository(_dbContext); } }
    public IPlaylistRepository PlaylistRepository { get { return _playlistRepository ?? new PlaylistRepository(_dbContext); } }
    public ISongRepository SongRepository { get { return _songRepository ?? new SongRepository(_dbContext); } }

    public void Dispose()
    {
        _dbContext?.Dispose();
        GC.SuppressFinalize(this);
    }
}
