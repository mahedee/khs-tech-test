using MediatR;
using TechTest.Application.DTOs;

namespace TechTest.Application.Commands
{
    public class DeleteClientCommand : IRequest<String>
    {
        public int Id { get; private set; }

        public DeleteClientCommand(int Id)
        {
            this.Id = Id;
        }
    }
}
