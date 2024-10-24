using MediatR;
using VeterinarySlices.API.Data;
using VeterinarySlices.API.Entities;

namespace VeterinarySlices.API.Features.Accounts.DeleteAccount
{
    internal sealed class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand>
    {
        private readonly VeterinaryDataContext _databaseContext;

        public DeleteAccountCommandHandler(VeterinaryDataContext context)
        {
            this._databaseContext = context;
        }

        public async Task Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            Account account = new Account()
            {
                Id = request.AccountId
            };

            this._databaseContext.Accounts.Remove(account);
            await this._databaseContext.SaveChangesAsync(cancellationToken);
        }
    }
}