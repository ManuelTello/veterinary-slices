using MediatR;
using Microsoft.EntityFrameworkCore;
using VeterinarySlices.API.Data;
using VeterinarySlices.API.Entities;

namespace VeterinarySlices.API.Features.Accounts.GetAccountByEmail
{
    internal sealed class GetAccountByEmailQueryHandler : IRequestHandler<GetAccountByEmailQuery, GetAccountByEmailQueryResponse?>
    {
        private readonly VeterinaryDataContext _databaseContext;

        public GetAccountByEmailQueryHandler(VeterinaryDataContext context)
        {
            this._databaseContext = context;
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
                    FullName = account.FullName,
                    Password = account.Password,
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