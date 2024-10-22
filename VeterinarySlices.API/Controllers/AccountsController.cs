using System.Net.Mime;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VeterinarySlices.API.Features.Accounts.CreateAccount;

namespace VeterinarySlices.API.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountsController : ControllerBase
    {
        private readonly ISender _mediatrSender;

        private readonly ILogger<AccountsController> _accountsLogger;

        public AccountsController(ISender sender, ILogger<AccountsController> logger)
        {
            this._mediatrSender = sender;
            this._accountsLogger = logger;
        }

        [HttpPost]
        [Route("/create")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountCommand command)
        {
            try
            {
                var accountId = await this._mediatrSender.Send(command);
                return Ok(accountId);
            }
            catch (TaskCanceledException exception)
            {
                this._accountsLogger.LogCritical(exception.Message);
                return StatusCode(500);
            }
        }
    }
}