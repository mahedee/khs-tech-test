using AutoMapper;
using MediatR;
using TechTest.Application.Commands;
using TechTest.Application.DTOs;
using TechTest.Core.Entities;
using TechTest.Core.Interfaces;

namespace TechTest.Application.CommandHandler
{
    public class EditPackageCommandHandler : IRequestHandler<EditPackageCommand, PackageDTO>
    {
        private readonly IPackageRepository _packageRepository;
        private readonly IMapper _mapper;

        public EditPackageCommandHandler(IPackageRepository packageRepository, IMapper mapper)
        {
            _packageRepository = packageRepository;
            _mapper = mapper;
        }
        public async Task<PackageDTO> Handle(EditPackageCommand request, CancellationToken cancellationToken)
        {

            var packageEntity = _mapper.Map<Package>(request);

            if (packageEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            try
            {
                await _packageRepository.UpdateAsync(packageEntity);
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }

            var modifiedPackage = await _packageRepository.GetAsync(request.Id);
            var packageResponse = _mapper.Map<PackageDTO>(modifiedPackage);

            return packageResponse;
        }
    }
}
