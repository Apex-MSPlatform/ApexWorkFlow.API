

namespace Domain.primitives
{
    public abstract class ApexEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
