namespace WaitForIt.PartTwo
{
    internal record Race(double Time, double Distance)
    {
        internal int NumberOfWiningRaces()
        {
            double a, b, c;

            // from: (Time - chargeTime) * chargeTime / Distance > 1

            a = -1 / Distance;
            b = Time / Distance;
            c = -1;

            double x1, x2;

            x1 = (-b + (double)Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / (2 * a);
            x2 = (-b - (double)Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / (2 * a);

            var upperBound = Math.Floor(Math.Max(x1, x2));
            var lowerBound = Math.Ceiling(Math.Min(x1, x2));

            while (WinRace(upperBound))
            {
                upperBound++;
            }

            while (WinRace(lowerBound))
            {
                lowerBound--;
            }

            return (int)(Math.Max(x1, x2) - Math.Min(x1, x2));
        }

        internal bool WinRace(double charge)
        {
            var timeLeft = Time - charge;
            return timeLeft * charge / Distance > 1;
        }
    }
}
