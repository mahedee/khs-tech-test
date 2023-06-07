using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTest.Application.DTOs;

namespace TechTest.Application.Commands
{
    public class EditPackageCommand : IRequest<PackageDTO>
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string PackageName { get; set; }
    }
}
