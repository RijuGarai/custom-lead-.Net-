namespace Domain
{
    public enum FieldType
    {
        Byte,
        SByte,
        Short,
        UShort,
        Int,
        UInt,
        Long,
        ULong,
        Float,
        Double,
        Decimal,
        Char,
        String,
        Boolean,
        DateTime,
        TimeSpan,
        Guid,
        Enum,
        Object,
        Null,
        // Arrays and Collections
        ByteArray,
        StringArray,
        IntArray,
        // Nullable Types
        NullableInt,
        NullableBool,
        NullableDouble,
        // Reference Types
        CustomClass,
        Interface,
        Delegate,
        // Special Types
        IntPtr,
        UIntPtr,
        // User-Defined Types
        // Add your own custom data types here
    }
}
