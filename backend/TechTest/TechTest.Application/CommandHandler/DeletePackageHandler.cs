using MediatR;
using TechTest.Application.Commands;
using TechTest.Core.Interfaces;

namespace TechTest.Application.CommandHandler
{
    public class DeletePackageHandler : IRequestHandler<DeletePackageCommand, String>
    {
        private readonly IPackageRepository _packageRepository;

        public DeletePackageHandler(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        public async Task<string> Handle(DeletePackageCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var clientEntity = await _packageRepository.GetAsync(request.Id);

                await _packageRepository.DeleteAsync(clientEntity);
            }
            catch (Exception exp)
            {
                throw (new ApplicationException(exp.Message));
            }

            return "Client information has been deleted!";
        }
    }
}
