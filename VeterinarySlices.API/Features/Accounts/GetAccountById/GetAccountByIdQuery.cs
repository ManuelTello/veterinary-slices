using MediatR;

namespace VeterinarySlices.API.Features.Accounts.GetAccountById
{
    public class GetAccountByIdQuery : IRequest<GetAccountByIdQueryResponse?>
    {
        public Guid AccountId { get; set; }
    }
}