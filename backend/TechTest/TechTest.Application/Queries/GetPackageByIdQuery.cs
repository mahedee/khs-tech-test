using MediatR;
using TechTest.Application.DTOs;

namespace TechTest.Application.Queries.Countries
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
