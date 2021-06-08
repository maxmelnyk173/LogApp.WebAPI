using AutoMapper;
using LogApp.Application.Shipments.Commands;
using LogApp.Application.Shipments.Commands.CreateShipment;
using LogApp.Application.Shipments.Queries.ViewModels;
using LogApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogApp.Application.MappingProfiles
{
    public class ShipmentMappingProfile : Profile
    {
        public ShipmentMappingProfile()
        {
            CreateMap<ShipmentCommandViewModel, Shipment>()
                .ForMember(x => x.Orders, opt => opt.Ignore());

            CreateMap<Carrier, ShipmentCarrierViewModel>();
            CreateMap<CostCenter, ShipmentCCViewModel>();
            CreateMap<Order, ShipmentOrderViewModel>();
            CreateMap<Shipment, ShipmentViewModel>();
        }
    }
}
