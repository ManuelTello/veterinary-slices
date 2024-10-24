using MediatR;
using VeterinarySlices.API.Data;
using VeterinarySlices.API.Entities;

namespace VeterinarySlices.API.Features.Accounts.CreateAccount { 
        internal sealed class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand>
        {
            private readonly VeterinaryDataContext _databaseContext;

            public CreateAccountCommandHandler(VeterinaryDataContext context)
            {
                this._databaseContext = context;
            }

            public async Task Handle(CreateAccountCommand request, CancellationToken cancellationToken)
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
            }
        }
}