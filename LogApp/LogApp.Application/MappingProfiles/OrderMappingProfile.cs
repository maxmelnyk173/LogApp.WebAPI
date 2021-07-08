using AutoMapper;
using LogApp.Application.Orders.Commands.CreateOrder;
using LogApp.Application.Orders.Commands.UpdateOrder;
using LogApp.Application.Orders.ViewModels;
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
            CreateMap<CreateOrderCommand, Order>().ReverseMap();
            CreateMap<UpdateOrderViewModel, Order>().ReverseMap();

            CreateMap<CostCenter, OrderCCViewModel>().ReverseMap();
            CreateMap<Shipment, OrderShipmentViewModel>().ReverseMap();

            CreateMap<Order, OrderViewModel>()
                .ForMember(dest => dest.CostCenter, opt => opt.MapFrom(src => src.CostCenter))
                .ForMember(dest => dest.Shipment, opt => opt.MapFrom(src => src.Shipment))
                .ReverseMap();
        }
    }
}
