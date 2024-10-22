using System.Text.Json.Serialization;

namespace VeterinarySlices.API.Features.Accounts.CreateAccount
{
    public class CreateAccountResponse
    {
        public CreateAccountResponse(string id)
        {
            this.AccountId = id;
        }

        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }
    }
}