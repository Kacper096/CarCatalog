﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarCatalog.Database.Entities;
using CarCatalog.Service.Messages.Request;
using CarCatalog.Service.Messages.Response;
using CarCatalog.Service.Repositories.Base.Business;
using CarCatalog.Service.Repositories.Models;
using CarCatalog.WebAPI.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarCatalog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BusinessBaseController<User, UserRepository, UserResponse, UserRequest>
    {
        public UserController(UserRepository repository)
            : base(repository)
        {
        }
    }
}