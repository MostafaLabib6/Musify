using AutoMapper;
using Musify.MVC.Models.Entities;
using Musify.MVC.Models.ModelViews.SongModelView;

namespace Musify.MVC.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Song, SongViewModel>().ReverseMap();
    }
}
