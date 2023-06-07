using AutoMapper;
using MediatR;
using Microsoft.VisualBasic;
using System.Net;
using TechTest.Application.DTOs;
using TechTest.Application.Queries;
using TechTest.Core.Entities;
using TechTest.Core.Interfaces;


namespace Ordering.Application.Handlers.QueryHandlers
{
    public class GetAllPackageHandler : IRequestHandler<GetAllPackageQuery, List<PackageDTO>>
    {
        private readonly IPackageRepository _packageRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public GetAllPackageHandler(IPackageRepository packageRepository, IClientRepository clientRepository, IMapper mapper)
        {
            _packageRepository = packageRepository;
            _clientRepository = clientRepository;
            _mapper = mapper;
        }
        public async Task<List<PackageDTO>> Handle(GetAllPackageQuery request, CancellationToken cancellationToken)
        {
            List<Package> packages = (List<Package>)await _packageRepository.GetAllAsync();

            var packageDTOs = _mapper.Map<List<PackageDTO>>(packages);

            foreach (var packageDTO in packageDTOs)
            {
                var client = (Client) await _clientRepository.GetAsync(packageDTO.ClientId);

                packageDTO.ClientName = client.FirstName + "  " + client.LastName;

            }
            return packageDTOs;
        }

    }
}
