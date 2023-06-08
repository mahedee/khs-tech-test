using MediatR;

namespace TechTest.Application.Commands
{
    public class DeletePackageCommand : IRequest<String>
    {
        public int Id { get; private set; }

        public DeletePackageCommand(int Id)
        {
            this.Id = Id;
        }
    }
}
