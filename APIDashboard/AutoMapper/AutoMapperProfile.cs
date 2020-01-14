using APIDashboard.Dto;
using APIDashboard.Models;
using AutoMapper;

namespace APIDashboard.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
        }
    }
}