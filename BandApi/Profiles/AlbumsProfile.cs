using AutoMapper;
using BandApi.Entities;
using BandApi.Models;

namespace BandApi.Profiles
{
    public class AlbumsProfile : Profile
    {
        public AlbumsProfile()
        {
            CreateMap<Album, AlbumDto>();

            CreateMap<CreateAlbumDto, Album>();
            CreateMap<UpdateAlbumDto, Album>().ReverseMap();
        }
    }
}
