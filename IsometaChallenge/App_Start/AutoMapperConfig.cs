using AutoMapper;
using IsometaChallenge.Models;

namespace IsometaChallenge
{
    public static class AutoMapper
    {
        public static MapperConfiguration Config { get; set; }
        public static IMapper Mapper { get; set; }
        public static void RegisterMappings()
        {
            Config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Artist, ArtistViewModel>();
                cfg.CreateMap<ArtistViewModel, Artist>();
            });

            Mapper = Config.CreateMapper();
        }
    }
}