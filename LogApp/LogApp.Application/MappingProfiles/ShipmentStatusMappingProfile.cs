using AutoMapper;
using LogApp.Application.CostCenters.Commands.UpdateCostCenter;
using LogApp.Application.ShipmentStatuses.Commands.CreateShipmentStatus;
using LogApp.Application.ShipmentStatuses.Commands.UpdateShipmentStatus;
using LogApp.Application.ShipmentStatuses.Queries;
using LogApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogApp.Application.MappingProfiles
{
    public class ShipmentStatusMappingProfile : Profile
    {
        public ShipmentStatusMappingProfile()
        {
            CreateMap<CreateShipmentStatusCommand, ShipmentStatus>();
            CreateMap<UpdateCostCenterViewModel, ShipmentStatus>();
            CreateMap<ShipmentStatus, ShipmentStatusViewModel>();
        }
    }
}
