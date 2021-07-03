using AutoMapper;
using LogApp.Application.CostCenters.Commands.CreateCostCenter;
using LogApp.Application.CostCenters.Commands.UpdateCostCenter;
using LogApp.Application.CostCenters.Queries;
using LogApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogApp.Application.MappingProfiles
{
    public class CostCenterMappingProfile : Profile
    {
        public CostCenterMappingProfile()
        {
            CreateMap<CreateCostCenterCommand, CostCenter>();
            CreateMap<UpdateCostCenterViewModel, CostCenter>();
            CreateMap<CostCenter, CostCenterViewModel>().ReverseMap();
        }
    }
}
