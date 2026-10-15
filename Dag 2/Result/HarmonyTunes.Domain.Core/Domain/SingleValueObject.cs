namespace HarmonyTunes.Domain.Core.Domain;

public class SingleValueObject<T> : ValueObject
    where T : notnull
{
    public T Value { get; }

    public SingleValueObject(T value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetValues()
    {
        yield return Value;
    }
}
