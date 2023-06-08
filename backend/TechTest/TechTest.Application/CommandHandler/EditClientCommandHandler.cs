using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTest.Application.Commands;
using TechTest.Application.DTOs;
using TechTest.Core.Entities;
using TechTest.Core.Interfaces;

namespace TechTest.Application.CommandHandler
{
    public class EditClientCommandHandler : IRequestHandler<EditClientCommand, ClientDTO>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public EditClientCommandHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }
        public async Task<ClientDTO> Handle(EditClientCommand request, CancellationToken cancellationToken)
        {

            var clientEntity = _mapper.Map<Client>(request);

            if (clientEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            try
            {
                await _clientRepository.UpdateAsync(clientEntity);
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }

            var modifiedClient = await _clientRepository.GetAsync(request.Id);
            var clientResponse = _mapper.Map<ClientDTO>(modifiedClient);

            return clientResponse;
        }
    }
}
