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
    }
}