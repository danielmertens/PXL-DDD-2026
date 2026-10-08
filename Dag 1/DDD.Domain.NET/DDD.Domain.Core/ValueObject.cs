namespace DDD.Domain.Core;

public abstract class ValueObject
{
    protected abstract IEnumerable<object> GetValues();

    public override bool Equals(object? obj)
    {
        return obj != null &&
               GetType() == obj.GetType() &&
               AreEqual(this, (ValueObject)obj);
    }

    public override int GetHashCode()
    {
        return GetValues()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
    }

    public static bool operator ==(ValueObject left, ValueObject right)
    {
        return AreEqual(left, right);
    }

    public static bool operator !=(ValueObject left, ValueObject right)
    {
        return !AreEqual(left, right);
    }

    private static bool AreEqual(ValueObject left, ValueObject right)
    {
        if (left is null)
            return right is null;
        else
            return right is not null &&
                   left.GetValues().SequenceEqual(right.GetValues());
    }
}
