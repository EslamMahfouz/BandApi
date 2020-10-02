using AutoMapper;
using BandApi.Entities;
using BandApi.Helpers;
using BandApi.Models;

namespace BandApi.Profiles
{
    public class BandsProfile : Profile
    {
        public BandsProfile()
        {
            CreateMap<Band, BandDto>()
                .ForMember(
                    d => d.FoundedYearsAgo,
                    o => o
                        .MapFrom(s => $"{s.Founded:yyy} ({s.Founded.GetYearsAgo()} years ago)"
                    ));

            CreateMap<CreateBandDto, Band>();

        }
    }
}
