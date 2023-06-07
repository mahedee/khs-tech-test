using AutoMapper;
using MediatR;
using TechTest.Application.Commands;
using TechTest.Application.DTOs;
using TechTest.Core.Entities;
using TechTest.Core.Interfaces;

namespace TechTest.Application.CommandHandler
{
    public class CreatePackageHandler : IRequestHandler<CreatePackageCommand, PackageDTO>
    {
        private readonly IPackageRepository _packageRepository;
        private readonly IMapper _mapper;
        public CreatePackageHandler(IPackageRepository packageRepository, IMapper mapper)
        {
            _packageRepository = packageRepository;
            _mapper = mapper;
        }
        public async Task<PackageDTO> Handle(CreatePackageCommand request, CancellationToken cancellationToken)
        {
            var packageEntity = _mapper.Map<Package>(request);

            if (packageEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            var newPackage = await _packageRepository.AddAsync(packageEntity);
            var packageResponse = _mapper.Map<PackageDTO>(newPackage);
            return packageResponse;
        }
    }


}
