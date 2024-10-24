using System.Text.Json.Serialization;

namespace VeterinarySlices.API.Features.Accounts.GetAccountByEmail
{
    public class GetAccountByEmailQueryResponse
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;

        [JsonPropertyName("full_name")]
        public string FullName { get; set; } = string.Empty;

        [JsonPropertyName("date_created")]
        public DateTime DateCreated { get; set; }
    }
}