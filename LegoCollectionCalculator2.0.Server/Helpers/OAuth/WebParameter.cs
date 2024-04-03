using System;

namespace LegoCollectionCalculator2._0.Server.Helpers.OAuth;

internal class WebParameter : IComparable<WebParameter>, IComparable
{
    public string Name { get;  }

    public string Value { get; }

    public WebParameter(string name, string value)
    {
        Name = name;
        Value = value;
    }

    public override string ToString()
    {
        return $"{Name}={Value}";
    }

    public int CompareTo(WebParameter? other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }

        if (other is null)
        {
            return 1;
        }

        var nameComparison = string.Compare(Name, other.Name, StringComparison.Ordinal);

        if (nameComparison != 0)
        {
            return nameComparison;
        }

        return string.Compare(Value, other.Value, StringComparison.Ordinal);
    }

    public int CompareTo(object? obj)
    {
        if (obj is WebParameter webParameter)
        {
            return CompareTo(webParameter);
        }

        throw new ArgumentException($"{nameof(obj)} must be of type {typeof(WebParameter)}," +
                                    $"received {obj?.GetType().ToString() ?? "Null"}.");
    }
}