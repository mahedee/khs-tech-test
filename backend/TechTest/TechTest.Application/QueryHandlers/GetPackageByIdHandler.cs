using AutoMapper;
using Location.Application.Queries.Countries;
using MediatR;
using TechTest.Application.DTOs;
using TechTest.Core.Interfaces;

namespace TechTest.Application.QueryHandlers
{
    public class GetPackageByIdHandler : IRequestHandler<GetPackageByIdQuery, PackageDTO>
    {
        private readonly IPackageRepository _packageRepository;
        private readonly IMapper _mapper;

        public GetPackageByIdHandler(IPackageRepository packageRepository, IMapper mapper)
        {
            _packageRepository = packageRepository;
            _mapper = mapper;
        }
        public async Task<PackageDTO> Handle(GetPackageByIdQuery request, CancellationToken cancellationToken)
        {
            var client = await _packageRepository.GetAsync(request.Id);
            var clientReponse = _mapper.Map<PackageDTO>(client);
            return clientReponse;
        }
    }
}
