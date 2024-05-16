namespace Domain
{
    public class Tenant : Entity<string>
    {
        public string Name { get; set; } = default!;
    }
}
