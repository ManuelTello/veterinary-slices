using System.Net.Mime;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VeterinarySlices.API.Features.Accounts.CreateAccount;
using VeterinarySlices.API.Features.Accounts.GetAccountByEmail;
using VeterinarySlices.API.Features.Accounts.GetAccountById;
using VeterinarySlices.API.Features.Accounts.DeleteAccount;

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
        [Route("email")]
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

        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [Route("id")]
        public async Task<IActionResult> GetAccountById(GetAccountByIdQuery query)
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

        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [Route("create")]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountCommand command)
        {
            var accountId = await this._mediatrSender.Send(command);
            return Ok(accountId);
        }

        [HttpDelete]
        [Produces(MediaTypeNames.Application.Json)]
        [Route("delete")]
        public async Task<IActionResult> DeleteAccount([FromBody] DeleteAccountCommand command)
        {
            var response = await this._mediatrSender.Send(command);
            return Ok(response);
        }
    }
}