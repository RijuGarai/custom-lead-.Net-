using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Lead : Entity<Guid>
    {
        [Required]
        public string Name { get; set; } = default!;

        [Required]
        public string ContactNo { get; set; } = default!;

        public string? AltContactNo { get; set; }

        public string? Email { get; set; }

        //LeadDynamic entity reference (one to many)
        public List<LeadDynamic>? Details { get; set; }

        [Column(TypeName ="Jsonb")]
        public List<LeadDynamic>? RawDetails { get; set; }

        //LeadHistory enity Reference (one to many)
        public List<LeadAutditHistory> Histories { get; set; } = default!;

        //Tenant entity reference
        [Required]
        public string TenantId { get; set; } = default!;
        [Required]
        public Tenant Tenant { get; set; } = default!;
    }
}
    