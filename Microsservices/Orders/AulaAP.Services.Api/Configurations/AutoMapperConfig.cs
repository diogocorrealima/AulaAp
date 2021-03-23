using AulaAP.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AulaAP.Services.Api.Configurations.AutoMapperConfig
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection service) =>
            service.AddAutoMapper(typeof(DomainToViewModelProfile), typeof(ViewModelToDomainProfile));
    }
}
