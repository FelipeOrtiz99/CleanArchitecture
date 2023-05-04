using MediatR;

namespace CleanArchitecture.Application.Features.Streamers.Commands.Delete
{
    public class DeleteStreamerCommand : IRequest
    {
        public int Id { get; set; }

    }
}
