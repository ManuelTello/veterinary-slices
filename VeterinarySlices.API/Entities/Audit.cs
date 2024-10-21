using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeterinarySlices.API.Entities
{
    [Table(name: "audits")]
    public class Audit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "id", Order = 1)]
        public int Id { get; set; }

        [Column(name: "date_logged", Order = 2)]
        public DateTime DateLogged { get; set; }
    }
}