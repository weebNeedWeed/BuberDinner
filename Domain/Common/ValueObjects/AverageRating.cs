using Domain.Common.Models;

namespace Domain.Common.ValueObjects;

public sealed class AverageRating : ValueObject
{
    public float Value { get; private set; }
    public int NumRatings { get; private set; }

    private AverageRating()
    {
    }

    private AverageRating(float value, int numRatings)
    {
        Value = value;
        NumRatings = numRatings;
    }

    public static AverageRating Create(float value, int numRatings)
    {
        if (value < 0 || value > 5)
        {
            throw new ArgumentException("Rating must be between 0 and 5.");
        }

        if (numRatings < 0)
        {
            throw new ArgumentException("Number of ratings must be greater than 0.");
        }

        return new(value, numRatings);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return NumRatings;
    }
}