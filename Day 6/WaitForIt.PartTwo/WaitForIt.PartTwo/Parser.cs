namespace WaitForIt.PartTwo
{
    internal static class Parser
    {
        internal static Race Parse(string input)
        {
            List<Race> output = new();

            string timeInput = input.Split('\n', ':')[1];
            string distanceInput = input.Split('\n', ':')[3];

            string time = timeInput.Trim().Replace(" ", string.Empty);
            string distance = distanceInput.Trim().Replace(" ", string.Empty);

            return new(double.Parse(time), double.Parse(distance));
        }
    }
}
