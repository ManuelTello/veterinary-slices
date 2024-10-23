using System.Net.Mime;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VeterinarySlices.API.Features.Accounts.CreateAccount;
using VeterinarySlices.API.Features.Accounts.GetAccountByEmail;
using VeterinarySlices.API.Features.Accounts.GetAccountById;

namespace VeterinarySlices.API.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountsController : ControllerBase
    {
        private readonly ISender _mediatrSender;

        public AccountsController(ISender sender)
        {
            this._mediatrSender = sender;
        }

        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [Route("/email")]
        public async Task<IActionResult> GetAccountByEmail(GetAccountByEmailQuery query)
        {
            var account = await this._mediatrSender.Send(query);
            if (account == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(account);
            }
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetAccountById(string id)
        {
            var account = await this._mediatrSender.Send(new GetAccountByIdQuery() { AccountId = Guid.Parse(id) });
            if (account == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(account);
            }
        }

        [HttpPost]
        [Route("/create")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountCommand command)
        {
            var accountId = await this._mediatrSender.Send(command);
            return Ok(accountId);
        }
    }
}