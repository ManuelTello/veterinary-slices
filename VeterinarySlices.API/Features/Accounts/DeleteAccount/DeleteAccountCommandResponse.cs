using System.Text.Json.Serialization;

namespace VeterinarySlices.API.Features.Accounts.DeleteAccount
{
    public class DeleteAccountCommandResponse
    {
        [JsonPropertyName("removed_id")]
        public Guid RemovedId { get; set; }
    }
}