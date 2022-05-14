using Microsoft.AspNetCore.Mvc;
using NSE.Core.Mediator;
using NSE.Customers.API.Application.Commands;
using NSE.WebAPI.Core.Controllers;

namespace NSE.Customers.API.Controllers
{
    [Route("api/customer")]
    public class CustomerController : MainController
    {
        public readonly IMediatorHandler _mediatorHandler;

        public CustomerController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpPost("")]
        public async Task<IActionResult> Index()
        {
            var result = await _mediatorHandler.SendCommand(
                new NewCustomerCommand(Guid.NewGuid(), "Katherine", "rafael-marinho@outlook.com", "03903251127"));

            return CustomResponse(result);
        }
    }
}
