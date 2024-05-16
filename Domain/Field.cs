using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Domain
{
    public class Field : Entity<Guid>
    {
        [Required]
        public string NormalizedName { get; set; } = default!;

        [Required]
        public string Name { get; set; } = default!;

        [Required]
        public FieldType Type { get; set; }

        [Required]
        public int MinLength { get; set; }

        [Required]
        public int MaxLength { get; set; }

        [Required]
        public bool IsNullable { get; set; }

        [Required]
        public string DefaultValue { get; set; } = default!;

        public string? Description { get; set; }

        public Field()
        {
        }
        public Field(string name, FieldType type, int minLength = 0, int maxLength = 2000, bool isNullable = true, string? description = null)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            NormalizedName = Normalize(Name);
            Type = type;
            MinLength = minLength;
            MaxLength = maxLength;
            IsNullable = isNullable;
            Description = description;
            DefaultValue = GetDefaultStringValue(type);
        }

        public Field(string name, FieldType type, int? minLength = null, int? maxLength = null, bool? isNullable = true, string? description = null)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            NormalizedName = Normalize(Name);
            Type = type;
            MinLength = minLength ?? 0;
            MaxLength = maxLength ?? 2000;
            IsNullable = isNullable ?? true;
            Description = description;
            DefaultValue = GetDefaultStringValue(type);
        }

        public static string GetDefaultStringValue(FieldType fieldType)
        {
            switch (fieldType)
            {
                case FieldType.Byte:
                    return default(byte).ToString();
                case FieldType.SByte:
                    return default(sbyte).ToString();
                case FieldType.Short:
                    return default(short).ToString();
                case FieldType.UShort:
                    return default(ushort).ToString();
                case FieldType.Int:
                    return default(int).ToString();
                case FieldType.UInt:
                    return default(uint).ToString();
                case FieldType.Long:
                    return default(long).ToString();
                case FieldType.ULong:
                    return default(ulong).ToString();
                case FieldType.Float:
                    return default(float).ToString();
                case FieldType.Double:
                    return default(double).ToString();
                case FieldType.Decimal:
                    return default(decimal).ToString();
                case FieldType.Char:
                    return default(char).ToString();
                case FieldType.String:
                    return default(string)?.ToString() ?? "null";
                case FieldType.Boolean:
                    return default(bool).ToString();
                case FieldType.DateTime:
                    return default(DateTime).ToString();
                case FieldType.TimeSpan:
                    return default(TimeSpan).ToString();
                case FieldType.Guid:
                    return default(Guid).ToString();
                case FieldType.Enum:
                    return default(Enum)?.ToString() ?? "null";
                case FieldType.Object:
                    return default(object)?.ToString() ?? "null";
                case FieldType.NullableInt:
                    return default(int?)?.ToString() ?? "null";
                case FieldType.NullableBool:
                    return default(bool?)?.ToString() ?? "null";
                case FieldType.NullableDouble:
                    return default(double?)?.ToString() ?? "null";
                // Add more cases as needed
                default:
                    return "Unknown Type";
            }
        }

        public static string Normalize(string str)
        {
            return string.IsNullOrWhiteSpace(str)
                ? string.Empty
                : Regex.Replace(str, @"[-_ .]", string.Empty)
                .ToLowerInvariant()
                .Replace(",,", ",")
                .Normalize();
        }
    }
}
