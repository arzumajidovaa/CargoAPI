using AutoMapper;
using CargoAPI.DTOs;
using CargoAPI.Entities;

namespace CargoAPI.Cargo.Service.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entity -> DTO Dönüşümü
            CreateMap<Order, OrderDto>();
            CreateMap<Carrier, CarrierDto>();
            CreateMap<CarrierConfiguration, CarrierConfigurationDto>();

            // DTO -> Entity Dönüşümü (Eğer ihtiyaç varsa)
            CreateMap<OrderDto, Order>();
            CreateMap<CarrierDto, Carrier>();
            CreateMap<CarrierConfigurationDto, CarrierConfiguration>();
        }
    }
}
