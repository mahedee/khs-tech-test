using AutoMapper;
using MediatR;
using TechTest.Application.Commands;
using TechTest.Application.DTOs;
using TechTest.Core.Entities;
using TechTest.Core.Interfaces;

namespace TechTest.Application.CommandHandler
{
    public class CreateClientHandler : IRequestHandler<CreateClientCommand, ClientDTO>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public CreateClientHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }
        public async Task<ClientDTO> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var clientEntity = _mapper.Map<Client>(request);

            if (clientEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            var newClient = await _clientRepository.AddAsync(clientEntity);
            var clientResponse = _mapper.Map<ClientDTO>(newClient);
            return clientResponse;
        }
    }
}
