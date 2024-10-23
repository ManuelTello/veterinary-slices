using MediatR;
using Microsoft.EntityFrameworkCore;
using VeterinarySlices.API.Data;
using VeterinarySlices.API.Entities;

namespace VeterinarySlices.API.Features.Accounts.GetAccountById
{
    internal sealed class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQuery, GetAccountByIdQueryResponse?>
    {
        private readonly VeterinaryDataContext _databaseContext;

        private readonly ILogger<GetAccountByIdQueryHandler> _handlerLogger;

        public GetAccountByIdQueryHandler(VeterinaryDataContext context, ILogger<GetAccountByIdQueryHandler> logger)
        {
            this._databaseContext = context;
            this._handlerLogger = logger;
        }

        public async Task<GetAccountByIdQueryResponse?> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
        {
            Account? account = await this._databaseContext.Accounts.SingleOrDefaultAsync(account => account.Id == request.AccountId);
            if (account != null)
            {
                GetAccountByIdQueryResponse response = new GetAccountByIdQueryResponse()
                {
                    Id = account.Id,
                    Email = account.FullName,
                    Password = account.Password,
                    FullName = account.FullName,
                    DateCreated = account.DateCreated
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