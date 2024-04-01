using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATA.DTO;
using ATA.Models;
using AutoMapper;

namespace ATA.MapperConfig
{
    public class MapperConfig: Profile
    {
        public MapperConfig()
        {
            CreateMap<CustomerDto, Customer>().ReverseMap();
            CreateMap<BookingDto, Booking>().ReverseMap();
            CreateMap<DriverDto, Driver>().ReverseMap();
            CreateMap<RouteDto, Models.Route>().ReverseMap();
            CreateMap<VehicleDto, Vehicle>().ReverseMap();
        }
    }
}