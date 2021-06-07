using AutoMapper;
using LogApp.Application.Orders.Commands.CreateOrder;
using LogApp.Application.Orders.Commands.UpdateOrder;
using LogApp.Application.Orders.Queries.ViewModels;
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

            CreateMap<CostCenter, OrderCCViewModel>();
            CreateMap<Shipment, OrderShipmentViewModel>();

            CreateMap<Order, OrderViewModel>()
                .ForMember(dest => dest.CostCenter, opt => opt.MapFrom(src => src.CostCenter))
                .ForMember(dest => dest.Shipment, opt => opt.MapFrom(src => src.Shipment));
        }
    }
}
