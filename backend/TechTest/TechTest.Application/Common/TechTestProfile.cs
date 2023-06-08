using AutoMapper;
using TechTest.Application.Commands;
using TechTest.Application.DTOs;
using TechTest.Core.Entities;

namespace TechTest.Application.Common
{
    public class TechTestProfile : Profile
    {
        public TechTestProfile()
        {
            CreateMap<Client, CreateClientCommand>().ReverseMap();
            CreateMap<Client, EditClientCommand>().ReverseMap();
            CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<Package, PackageDTO>().ReverseMap();
            CreateMap<Package, CreatePackageCommand>().ReverseMap();
            CreateMap<Package, EditPackageCommand>().ReverseMap();
        }

    }
}
