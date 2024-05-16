using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class LeadDynamic : Entity<Guid>
    {
        //Lead entity reference
        [Required]
        public Guid LeadId { get; set; }
        [Required]
        public Lead Lead { get; set; } = default!;


        //TenantField entity reference
        [Required]
        public Guid TenantFieldId { get; set; }
        [Required]
        public TenantField Field { get; set; } = default!;


        //LeadAudit history reference (one to many)
        public List<LeadAutditHistory> Histories { get; set; } = default!;


        public string? Value { get; set; }
        public string? GroupKey { get; set; }


        //Tenant entity reference
        [Required]
        public string TenantId { get; set; } = default!;
        [Required]
        public Tenant Tenant { get; set; } = default!;
    }
}
