namespace WaitForIt.PartOne
{
    internal record Race(float Time, float Distance)
    {
        internal int NumberOfWiningRaces()
        {
            int counter = 0;

            for (float charge = 0; charge < Time; charge++)
            {
                var timeLeft = Time - charge;

                bool won = timeLeft * charge / Distance > 1;
                if (won)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
