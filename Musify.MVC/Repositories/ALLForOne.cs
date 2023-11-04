using Musify.MVC.Persistance;

namespace Musify.MVC.Repositories;

public class ALLForOne : IALLForOne
{
    public IAlbumRepository AlbumRepository { get; set; }
    public IArtistRepository ArtistRepository { get; set; }
    public IAuthorRepository AuthorRepository { get; set; }
    public IPlaylistRepository PlaylistRepository { get; set; }
    public ISongRepository SongRepository { get; set; }
}
