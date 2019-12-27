﻿using AutoMapper;
using CarCatalog.Database.Entities;
using CarCatalog.Service.Messages.Request;
using CarCatalog.Service.Messages.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarCatalog.Utils.Registers.Profiles
{
    public class CarMessageProfile : Profile
    {
        public CarMessageProfile()
        {
            CreateMap<Car, CarResponse>();
            CreateMap<CarRequest, Car>()
                .ForMember(c => c.Catalog, r => r.Ignore())
                .ForMember(c => c.Engine, r => r.Ignore())
                .ForMember(c => c.Category, r => r.Ignore());
        }
    }
}
