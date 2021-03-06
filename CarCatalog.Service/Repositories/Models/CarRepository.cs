﻿using AutoMapper;
using CarCatalog.Database;
using CarCatalog.Database.Entities;
using CarCatalog.Service.Messages.Request;
using CarCatalog.Service.Messages.Response;
using CarCatalog.Service.Repositories.Base;
using CarCatalog.Service.Repositories.Base.Business;
using System;

namespace CarCatalog.Service.Repositories.Models
{
    public class CarRepository : BusinessRepository<Car, CarCatalogContext, CarResponse, CarRequest>
    {
        public CarRepository(CarCatalogContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }
    }
}
