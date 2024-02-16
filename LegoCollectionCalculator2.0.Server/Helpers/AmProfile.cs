using AutoMapper;
using LegoCollectionCalculator2._0.Server.Entities.Bricklink;
using LegoCollectionCalculator2._0.Server.RsModels;

namespace LegoCollectionCalculator2._0.Server.Helpers
{
    public class AmProfile : Profile
    {
        public AmProfile()
        {
            CreateMap<BricklinkSetDbo, GetSetRsModel>()
                .ForMember(dest => dest.SetId,
                    x => x.MapFrom(src => src.Data.No))
                .ForMember(dest => dest.Name,
                    x => x.MapFrom(src => src.Data.Name))
                .ForMember(dest => dest.ImageUrl,
                    x => x.MapFrom(src => src.Data.Image_url))
                .ForMember(dest => dest.ThumbnailUrl,
                    x => x.MapFrom(src => src.Data.Thumbnail_url))
                .ForMember(dest => dest.Weight,
                    x => x.MapFrom(src => src.Data.Weight))
                .ForMember(dest => dest.Dim_x,
                    x => x.MapFrom(src => src.Data.Dim_x))
                .ForMember(dest => dest.Dim_y,
                    x => x.MapFrom(src => src.Data.Dim_y))
                .ForMember(dest => dest.Dim_z,
                    x => x.MapFrom(src => src.Data.Dim_z))
                .ForMember(dest => dest.YearReleased,
                    x => x.MapFrom(src => src.Data.Year_released))
                .ForMember(dest => dest.IsObsolete,
                    x => x.MapFrom(src => src.Data.Is_obsolete));
        }
    }
}
