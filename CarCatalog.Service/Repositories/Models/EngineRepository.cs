﻿using AutoMapper;
using CarCatalog.Database;
using CarCatalog.Database.Entities;
using CarCatalog.Service.Messages.Request;
using CarCatalog.Service.Messages.Response;
using CarCatalog.Service.Repositories.Base;
using CarCatalog.Service.Repositories.Base.Business;
using CarCatalog.Service.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarCatalog.Service.Repositories.Models
{
    public class EngineRepository : BusinessRepository<Engine, EngineResponse, EngineRequest>
    {
        public EngineRepository(RepositoryBase<Engine> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
