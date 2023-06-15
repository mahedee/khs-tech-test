using MediatR;
using TechTest.Core.Entities;

namespace TechTest.Application.Queries
{
    public record GetAllClientQuery : IRequest<List<Client>>
    {

    }
}
