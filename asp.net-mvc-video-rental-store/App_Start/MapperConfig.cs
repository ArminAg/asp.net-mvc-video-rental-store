using asp.net_mvc_video_rental_store.Core.Models;
using asp.net_mvc_video_rental_store.Core.ViewModels;
using AutoMapper;

namespace asp.net_mvc_video_rental_store.App_Start
{
    public class MapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(m => 
            {
                m.CreateMap<Customer, CustomerViewModel>().ReverseMap();
                m.CreateMap<Movie, MovieViewModel>().ReverseMap();
            });
        }
    }
}