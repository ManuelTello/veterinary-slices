using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeterinarySlices.API.Entities
{
    [Table(name: "accounts_audits")]
    public class AccountAudit
    {
        [Key]
        [Column(name: "id", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(name: "account_id", Order = 2)]
        [ForeignKey("accounts")]
        public Guid AccountId { get; set; }

        [Column(name: "audit_id", Order = 3)]
        [ForeignKey("audits")]
        public int AuditId { get; set; }

        public Account Account { get; set; } = null!;

        public Audit Audit { get; set; } = null!;
    }
}