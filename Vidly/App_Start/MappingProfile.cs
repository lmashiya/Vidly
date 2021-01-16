﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();

            CreateMap<Customer, CustomerDto>().ForMember(c => c.Id, 
                opt => opt.Ignore());
            CreateMap<Movie, MovieDto>().ForMember(c => c.Id, 
                opt => opt.Ignore());
        }
    }
}