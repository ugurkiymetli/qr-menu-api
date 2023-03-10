using AutoMapper;
using QrMenu.Models;
using QrMenu.ViewModels;

namespace QrMenu.Utils.Mapping
{
    public static class MappingExtensions
    {
        private static readonly IMapper _mapper;

        static MappingExtensions()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserViewModel>();
                cfg.CreateMap<UserInsertModel, User>();
                cfg.CreateMap<User, UserAuthViewModel>(); 
                //cfg.CreateMap<Restaurant, RestaurantViewModel>();
                //Add more mappings as needed
            });

            _mapper = config.CreateMapper();
        }

        public static TDestination Map<TSource, TDestination>(this TSource from)
        {
            return _mapper.Map<TDestination>(from);
        }
        public static List<TDestination> Map<TSource, TDestination>(this List<TSource> fromList)
        {
            return _mapper.Map<List<TDestination>>(fromList);
        }

    }

}

