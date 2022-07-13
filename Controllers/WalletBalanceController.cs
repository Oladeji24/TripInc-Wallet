using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using TripInc_Wallet.Application.CQRS.WalletBalanceCommands;
using TripInc_Wallet.Application.CQRS.WalletBalanceQueries;

namespace TripInc_Wallet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletBalanceController : ControllerBase
    {
        private readonly IMediator _mediator;
        public WalletBalanceController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateWalletBalanceCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllWalletBalanceQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetWalletBalanceByIdQuery { Id = id }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteWalletBalanceByIdCommand { Id = id }));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(int id, UpdateWalletBalanceCommand command)
        {
            if (id != command.id)
            {
                return BadRequest();
            }
            return Ok(await _mediator.Send(command));
        }
    }
}
