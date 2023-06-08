using AutoMapper;
using MediatR;
using TechTest.Application.DTOs;
using TechTest.Core.Interfaces;

namespace Location.Application.Queries.Countries
{
    public class GetPackageByIdQuery : IRequest<PackageDTO>
    {
        public int Id { get; private set; }

        public GetPackageByIdQuery(int id)
        {
            this.Id = id;
        }
    }
   

}
