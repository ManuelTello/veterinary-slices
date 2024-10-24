using MediatR;

namespace VeterinarySlices.API.Features.Accounts.CreateAccount
{
    public class CreateAccountCommand : IRequest
    {
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}