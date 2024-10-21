using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeterinarySlices.API.Entities
{
    [Table(name: "accounts")]
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "id", Order = 1)]
        public Guid Id { get; set; }

        [Column(name: "email", Order = 2)]
        public string Email { get; set; } = string.Empty;

        [Column(name: "password", Order = 3)]
        public string Password { get; set; } = string.Empty;

        [Column(name: "full_name", Order = 4)]
        public string FullName { get; set; } = string.Empty;

        [Column(name: "date_created", Order = 5)]
        public DateTime DateCreated { get; set; }
    }
}