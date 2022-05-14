using FluentValidation.Results;
using NSE.Core.Messages;

namespace NSE.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T _event) where T : Event;
        Task<ValidationResult> SendCommand<T>(T _command) where T : Command;
    }
}
