using MediatR;
using TechTest.Application.DTOs;
using TechTest.Core.Entities;

namespace TechTest.Application.Queries
{
    // Customer query with List<Customer> response
    public record GetAllPackageQuery : IRequest<List<PackageDTO>>
    {

    }
}
