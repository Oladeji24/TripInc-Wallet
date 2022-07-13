using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using TripInc_Wallet.Application.CQRS.WalletUserInfoCommands;
using TripInc_Wallet.Application.CQRS.WalletUserInfoQueries;

namespace TripInc_Wallet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletUserInfoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public WalletUserInfoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddWalletUserInfoCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllWalletUserInfoQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetWalletUserInfoByIdQuery { Id = id }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteWalletUserInfoByIdCommand { Id = id }));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(int id, UpdateWalletUserInfoCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await _mediator.Send(command));
        }
    }
}