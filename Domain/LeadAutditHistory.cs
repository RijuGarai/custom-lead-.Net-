using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class LeadAutditHistory : Entity<Guid>
    {
        //Lead entity reference
        [Required]
        public Guid LeadId { get; set; }

        [Required]
        public Lead Lead { get; set; } = default!;



        [Required]
        public string FieldName { get; set; } = default!;


        //TenantField entity reference
        [Required]
        public Guid TenantFieldId { get; set; }

        [Required]
        public TenantField TenantField { get; set; } = default!;



        //LeadDynamic entity reference
        [Required]
        public Guid LeadDynamicId { get; set; }

        [Required]
        public LeadDynamic LeadDynamic { get; set; } = default!;



        public string? Value { get; set; }

        public int Version { get; set; }

        public Guid GroupKey { get; set; }



        //LeadHistoryVisibility entity reference (one to many)
        public IList<LeadHistoryVisibility>? Visibilities { get; set; }



        //Tenant entity reference
        [Required]
        public string TenantId { get; set; } = default!;
        [Required]
        public Tenant Tenant { get; set; } = default!;
    }
}
