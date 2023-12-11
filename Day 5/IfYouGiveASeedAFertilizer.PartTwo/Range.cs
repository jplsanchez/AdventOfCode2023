namespace IfYouGiveASeedAFertilizer.PartTwo
{
    record class Range(long Start, long Length)
    {
        internal long End => Start + Length;
        internal bool IsInRange(long value)
        {
            return value >= Start && value <= End;
        }

        internal bool TryGetIntersection(Range other, out Range intersection)
        {
            if (other.Start > End || other.End < Start)
            {
                intersection = new(0, 0);
                return false;
            }

            intersection = new(Math.Max(Start, other.Start), Math.Min(End, other.End) - Math.Max(Start, other.Start));
            return true;
        }

        internal List<Range> GetExclusive(Range other)
        {
            if (TryGetIntersection(other, out var intersection))
            {
                var result = new List<Range>();

                if (Start < intersection.Start)
                {
                    result.Add(new(Start, intersection.Start - Start));
                }
                if (End > intersection.End)
                {
                    result.Add(new(intersection.End, End - intersection.End));
                }

                return result;
            }

            return [this];
        }
    }
}
