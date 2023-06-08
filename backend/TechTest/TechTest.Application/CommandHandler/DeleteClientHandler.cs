using MediatR;
using TechTest.Application.Commands;
using TechTest.Core.Interfaces;

namespace TechTest.Application.CommandHandler
{
    public class DeleteClientHandler : IRequestHandler<DeleteClientCommand, String>
    {
        private readonly IClientRepository _clientRepository;

        public DeleteClientHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<string> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var clientEntity = await _clientRepository.GetAsync(request.Id);

                await _clientRepository.DeleteAsync(clientEntity);
            }
            catch (Exception exp)
            {
                throw (new ApplicationException(exp.Message));
            }

            return "Client information has been deleted!";
        }
    }
}
