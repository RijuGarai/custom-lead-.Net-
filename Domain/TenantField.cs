using System.ComponentModel;

namespace Domain
{
    public class TenantField : Entity<Guid>
    {
        //Field entity reference
        public Guid FieldId { get; set; }
        public Field Field { get; set; } = default!;


        //Tenant specific info
        public Guid? ParentId { get; set; }
        public string? CustomName { get; set; }
        public int MinLength { get; set; }
        public int MaxLength { get; set; }

        [DefaultValue(true)]
        public bool IsEnabled { get; set; }

        [DefaultValue(false)]
        public bool IsRequired { get; set; } = false;

        [DefaultValue(true)]
        public bool IsCreatable { get; set; } = true;

        [DefaultValue(true)]
        public bool IsEditable { get; set; } = true;

        [DefaultValue(true)]
        public bool IsFilterable { get; set; } = true;

        [DefaultValue(true)]
        public bool IsListed { get; set; } = true;


        //Tenant entity reference
        public string TenantId { get; set; } = default!;
        public Tenant Tenant { get; set; } = default!;
    }
}
