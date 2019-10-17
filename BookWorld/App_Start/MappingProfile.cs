using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BookWorld.Dtos;
using BookWorld.Models;

namespace BookWorld.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Member, MemberDto>();
            CreateMap<MemberDto, Member>();

            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();

            CreateMap<MembershipType, MembershipTypeDto>();
            CreateMap<Genre, GenreDto>();
        }
    }
}