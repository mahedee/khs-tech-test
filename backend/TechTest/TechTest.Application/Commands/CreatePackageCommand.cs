using MediatR;
using TechTest.Application.DTOs;

namespace TechTest.Application.Commands
{
    public class CreatePackageCommand : IRequest<PackageDTO>
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string PackageName { get; set; }
    }
}
