using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class LeadHistoryVisibility : Entity<Guid>
    {
        //LeadAutditHistory entity reference
        [Required]
        public Guid LeadAuditHistoryId { get; set; }

        [Required]
        public LeadAutditHistory LeadAuditHistory { get; set; } = default!;


        [Required]
        public Guid UserId { get; set; }


        //Tenant entity reference
        [Required]
        public string TenantId { get; set; } = default!;
        [Required]
        public Tenant Tenant { get; set; } = default!;
    }
}
