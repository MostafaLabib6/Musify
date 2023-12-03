using Musify.MVC.Repositories;

namespace Musify.MVC.Persistance;

public interface IALLForOne : IDisposable
{
    public IAlbumRepository AlbumRepository { get; }
    public IArtistRepository ArtistRepository { get; }
    public IAuthorRepository AuthorRepository { get; }
    public IPlaylistRepository PlaylistRepository { get; }
    public ISongRepository SongRepository { get; }


}
