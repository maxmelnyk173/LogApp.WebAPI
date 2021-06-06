using AutoMapper;
using LogApp.Application.Carriers.Commands.CreateCarrier;
using LogApp.Application.Carriers.Commands.UpdateCarrier;
using LogApp.Application.Carriers.Queries;
using LogApp.Domain.Entities;

namespace LogApp.Application.MappingProfiles
{
    public class CarriersMappingProfile : Profile
    {
        public CarriersMappingProfile()
        {
            CreateMap<CreateCarrierCommand, Carrier>();
            CreateMap<Carrier, CarrierViewModel>();
        }
    }
}
