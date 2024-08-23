using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechsysLogProj.Domain.Interfaces;

namespace TechsysLogProj.Application.Services
{
    public abstract class BaseService
    {
        protected readonly IMapper Mapper;
        protected readonly IConfiguration Configuration;
        protected BaseService(IMapper mapper, IConfiguration configuration)
        {
            Mapper = mapper;
            Configuration = configuration;
        }
    }
}
