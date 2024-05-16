using Domain;

namespace CustomLead.DTOs
{
    public class FieldDto : IDto
    {
        public string Name { get; set; } = default!;
        public FieldType Type { get; set; } = FieldType.String;
        public int? MinLength { get; set; }
        public int? MaxLength { get; set; }
        public bool? IsNullable { get; set; }
        public string? Description { get; set; }
    }
    public class FieldUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public FieldType Type { get; set; } = FieldType.String;
        public int? MinLength { get; set; }
        public int? MaxLength { get; set; }
        public bool? IsNullable { get; set; }
        public string? Description { get; set; }
    }
}
