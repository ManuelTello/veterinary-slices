using MediatR;
using VeterinarySlices.API.Data;
using VeterinarySlices.API.Entities;

namespace VeterinarySlices.API.Features.Accounts.DeleteAccount
{
    internal sealed class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, DeleteAccountCommandResponse>
    {
        private readonly VeterinaryDataContext _databaseContext;

        private readonly ILogger<DeleteAccountCommandHandler> _handlerLogger;

        public DeleteAccountCommandHandler(VeterinaryDataContext context, ILogger<DeleteAccountCommandHandler> logger)
        {
            this._databaseContext = context;
            this._handlerLogger = logger;
        }

        public async Task<DeleteAccountCommandResponse> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            Account account = new Account()
            {
                Id = request.AccountId
            };

            this._databaseContext.Accounts.Remove(account);
            await this._databaseContext.SaveChangesAsync(cancellationToken);

            DeleteAccountCommandResponse response = new DeleteAccountCommandResponse()
            {
                RemovedId = request.AccountId
            };

            return response;
        }
    }
}