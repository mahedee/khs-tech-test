using MediatR;
using TechTest.Application.Queries;
using TechTest.Core.Entities;
using TechTest.Core.Interfaces;


namespace TechTest.Application.Handlers.QueryHandlers
{ 
    public class GetAllClientHandler : IRequestHandler<GetAllClientQuery, List<Client>>
    {
        private readonly IClientRepository _clientRepository;

        public GetAllClientHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<List<Client>> Handle(GetAllClientQuery request, CancellationToken cancellationToken)
        {
            return (List<Client>)await _clientRepository.GetAllAsync();
        }
    }
}
