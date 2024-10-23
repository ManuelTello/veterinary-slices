using System.Text.Json.Serialization;

namespace VeterinarySlices.API.Features.Accounts.GetAccountById
{
    public class GetAccountByIdQueryResponse
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;

        [JsonPropertyName("full_name")]
        public string FullName { get; set; } = string.Empty;

        [JsonPropertyName("date_created")]
        public DateTime DateCreated { get; set; }
    }
}