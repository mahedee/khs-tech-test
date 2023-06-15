using MediatR;
using TechTest.Application.DTOs;

namespace TechTest.Application.Queries
{
    public record GetAllPackageQuery : IRequest<List<PackageDTO>>
    {

    }
}
