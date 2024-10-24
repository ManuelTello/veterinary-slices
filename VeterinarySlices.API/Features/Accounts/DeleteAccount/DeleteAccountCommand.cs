using MediatR;

namespace VeterinarySlices.API.Features.Accounts.DeleteAccount
{
    public class DeleteAccountCommand : IRequest
    {
        public Guid AccountId { get; set; }
    }
}