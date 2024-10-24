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

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [Route("email")]
        public async Task<IActionResult> GetAccountByEmail([FromBody] GetAccountByEmailQuery query)
        {
            var result = await this._mediatrSender.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }
    
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [Route("id")]
        public async Task<IActionResult> GetAccountById([FromBody] GetAccountByIdQuery query)
        {
            var result = await this._mediatrSender.Send(query);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [Route("create")]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountCommand command)
        {
            await this._mediatrSender.Send(command);
            return Ok();
        }

        [HttpDelete]
        [Produces(MediaTypeNames.Application.Json)]
        [Route("delete")]
        public async Task<IActionResult> DeleteAccount([FromBody] DeleteAccountCommand command)
        {
            await this._mediatrSender.Send(command);
            return Ok();
        }
    }
}