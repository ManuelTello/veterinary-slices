using MediatR;

namespace VeterinarySlices.API.Features.Accounts.DeleteAccount
{
    public class DeleteAccountCommand : IRequest<DeleteAccountCommandResponse>
    {
        public Guid AccountId { get; set; }
    }
}