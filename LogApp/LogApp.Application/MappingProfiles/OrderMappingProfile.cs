using AutoMapper;
using LogApp.Application.Orders.Commands.CreateOrder;
using LogApp.Application.Orders.Commands.UpdateOrder;
using LogApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogApp.Application.MappingProfiles
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<CreateOrderCommand, Order>();
            CreateMap<UpdateOrderViewModel, Order>();
        }
    }
}
