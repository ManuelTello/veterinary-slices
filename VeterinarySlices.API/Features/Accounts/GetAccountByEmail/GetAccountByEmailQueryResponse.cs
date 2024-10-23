using System.ComponentModel.DataAnnotations;

namespace VeterinarySlices.API.Features.Accounts.GetAccountByEmail
{
    public class GetAccountByEmailQueryResponse
    {
        public Guid Id { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public DateTime DateCreated { get; set; }
    }
}