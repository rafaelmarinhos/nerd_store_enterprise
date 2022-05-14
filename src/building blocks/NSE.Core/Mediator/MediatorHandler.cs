using FluentValidation.Results;
using MediatR;
using NSE.Core.Messages;

namespace NSE.Core.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishEvent<T>(T _event) where T : Event
        {
            await _mediator.Publish(_event);
        }

        public async Task<ValidationResult> SendCommand<T>(T _command) where T : Command
        {
            return await _mediator.Send(_command);
        }
    }
}
