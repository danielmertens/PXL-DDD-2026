namespace HarmonyTunes.Domain.Core;

public abstract class Identity : ValueObject
{
    public Guid Key { get; }

    protected Identity(Guid key)
    {
        if (key == Guid.Empty) throw new ArgumentException("Key can't be empty", nameof(key));
        Key = key;
    }

    protected override IEnumerable<object> GetValues()
    {
        yield return Key;
    }
}
