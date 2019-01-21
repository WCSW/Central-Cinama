using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using SuperMovie.Dtos;
using SuperMovie.Models;

namespace SuperMovie.App_Start
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping()
        {
            //Domain to Dto
            Mapper.CreateMap<Customer, CustomersDto>();
            Mapper.CreateMap<CustomersDto, Customer>();

            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>();


            Mapper.CreateMap<TvShow, TvShowDto>();
            Mapper.CreateMap<TvShowDto, TvShow>();
            
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();


            //Dto to Domain

            Mapper.CreateMap<CustomersDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}