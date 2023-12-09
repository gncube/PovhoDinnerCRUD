﻿namespace Domain.Common.ValueObjects;

public record AverageRating
{
    private AverageRating(double value, int numRatings)
    {
        Value = value;
        NumRatings = numRatings;
    }
    public double Value { get; private set; }
    public int NumRatings { get; private set; }

    public static AverageRating CreateNew(double rating = 0, int numRatings = 0)
    {
        return new AverageRating(rating, numRatings);
    }

    public void AddNewRating(Rating rating)
    {
        Value = ((Value * NumRatings) + rating.Value) / ++NumRatings;
    }

    public void RemoveRating(Rating rating)
    {
        Value = ((Value * NumRatings) - rating.Value) / --NumRatings;
    }
}