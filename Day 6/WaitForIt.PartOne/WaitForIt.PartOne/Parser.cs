namespace WaitForIt.PartOne
{
    internal static class Parser
    {
        internal static List<Race> Parse(string input)
        {
            List<Race> output = new();

            string timeInput = input.Split('\n', ':')[1];
            string distanceInput = input.Split('\n', ':')[3];

            string[] time = timeInput.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            string[] distance = distanceInput.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            for (int i = 0; i < time.Length; i++)
            {
                output.Add(new(float.Parse(time[i]), float.Parse(distance[i])));
            }

            return output;
        }
    }
}
