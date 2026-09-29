using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Application.DTOs;
using Library.Domain.Entities;

namespace Library.Application.Profiles
{
    public class AuthorProfile : AutoMapper.Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<AuthorDto, Author>();
        }
    }
}