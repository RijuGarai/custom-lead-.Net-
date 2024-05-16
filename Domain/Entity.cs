namespace Domain
{
    public class Entity<T>
    {
        public T Id { get; set; } = default!;

        public Guid CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public Guid LastModifiedBy { get; set; }

        public DateTime? LastModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public Guid? DeletedBy { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
