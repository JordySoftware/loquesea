namespace Common.Model
{
    public interface IDomainEntity
    {
        Guid Id { get; }
        string Code { get; }
        string Description { get; }
    }
}
