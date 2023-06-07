using MediatR;
using TechTest.Application.Commands;
using TechTest.Core.Interfaces;

namespace TechTest.Application.CommandHandler
{
    // Customer delete command handler with string response as output
    public class DeleteClientHandler : IRequestHandler<DeleteClientCommand, String>
    {
        private readonly IClientRepository _clientRepository;

        public DeleteClientHandler(IClientRepository customerRepository)
        {
            _clientRepository = customerRepository;
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
