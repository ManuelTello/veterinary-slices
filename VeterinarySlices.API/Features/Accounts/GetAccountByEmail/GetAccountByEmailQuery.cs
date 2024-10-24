using MediatR;

namespace VeterinarySlices.API.Features.Accounts.GetAccountByEmail
{
    public class GetAccountByEmailQuery : IRequest<GetAccountByEmailQueryResponse>
    {
        public string AccountEmail { get; set; } = string.Empty;
    }
}