using asp.net_mvc_video_rental_store.Core.Dtos;
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
                m.CreateMap<Customer, CustomerFormViewModel>().ReverseMap();
                m.CreateMap<Customer, CustomerDto>().ReverseMap();

                m.CreateMap<Movie, MovieViewModel>().ReverseMap();
                m.CreateMap<Movie, MovieFormViewModel>().ReverseMap();
                m.CreateMap<Movie, MovieDto>().ReverseMap();

                m.CreateMap<MembershipType, MembershipTypeViewModel>().ReverseMap();

                m.CreateMap<Genre, GenreViewModel>().ReverseMap();
            });
        }
    }
}