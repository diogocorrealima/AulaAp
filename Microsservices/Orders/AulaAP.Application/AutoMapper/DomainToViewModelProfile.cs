using AulaAP.Application.ViewModels;
using AulaAP.Domain.Commands;
using AulaAP.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AulaAP.Application.AutoMapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<RegisterOrderCommand, OrderCreateViewModel>();

        }
    }
}
