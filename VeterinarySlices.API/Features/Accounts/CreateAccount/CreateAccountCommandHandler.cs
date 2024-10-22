using MediatR;
using VeterinarySlices.API.Data;
using VeterinarySlices.API.Entities;

namespace VeterinarySlices.API.Features.Accounts.CreateAccount
{
    internal sealed class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, CreateAccountResponse>
    {
        private readonly VeterinaryDataContext _databaseContext;

        private readonly ILogger<CreateAccountCommandHandler> _handlerLogger;

        public CreateAccountCommandHandler(VeterinaryDataContext context, ILogger<CreateAccountCommandHandler> logger)
        {
            this._databaseContext = context;
            this._handlerLogger = logger;
        }

        public async Task<CreateAccountResponse> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password, 16);
            Account account = new Account()
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                Password = hashedPassword,
                FullName = request.FullName,
                DateCreated = request.DateCreated
            };

            await this._databaseContext.Accounts.AddAsync(account);
            await this._databaseContext.SaveChangesAsync(cancellationToken);

            CreateAccountResponse response = new CreateAccountResponse(account.Id.ToString());
            return response;
        }
    }
}