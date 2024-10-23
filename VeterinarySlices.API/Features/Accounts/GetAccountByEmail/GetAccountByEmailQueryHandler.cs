using MediatR;
using Microsoft.EntityFrameworkCore;
using VeterinarySlices.API.Data;
using VeterinarySlices.API.Entities;

namespace VeterinarySlices.API.Features.Accounts.GetAccountByEmail
{
    internal sealed class GetAccountByEmailQueryHandler : IRequestHandler<GetAccountByEmailQuery, GetAccountByEmailQueryResponse?>
    {
        private readonly VeterinaryDataContext _databaseContext;

        private readonly ILogger<GetAccountByEmailQueryHandler> _handlerLogger;

        public GetAccountByEmailQueryHandler(VeterinaryDataContext context, ILogger<GetAccountByEmailQueryHandler> logger)
        {
            this._databaseContext = context;
            this._handlerLogger = logger;
        }

        public async Task<GetAccountByEmailQueryResponse?> Handle(GetAccountByEmailQuery request, CancellationToken cancellationToken)
        {
            Account? account = await this._databaseContext.Accounts.SingleOrDefaultAsync(account => account.Email == request.AccountEmail);
            if (account != null)
            {
                GetAccountByEmailQueryResponse response = new GetAccountByEmailQueryResponse()
                {
                    Id = account.Id,
                    Email = account.Email,
                    Password = account.Password,
                    FullName = account.FullName,
                    DateCreated = account.DateCreated,
                };
                return response;
            }
            else
            {
                return null;
            }
        }
    }
}