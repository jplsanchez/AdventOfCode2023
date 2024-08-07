using Position = (int i, int j);

namespace GearRatios.PartOne
{
    internal static class GearRatios
    {
        private static readonly string[] _numbers = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"];
        private static readonly string[] _notValidSymbols = [".", "\n"];

        internal static bool IsNumber(this string str)
        {
            return _numbers.Contains(str);
        }

        internal static bool IsSymbol(this string str)
        {
            return !_notValidSymbols.Contains(str) && !_numbers.Contains(str);
        }
    }

    internal class Sequence
    {
        internal int Value => int.Parse(string.Join("", _sequence));
        internal int Size => _sequence.Count;

        List<string> _sequence = [];
        readonly string[][] _parentArray;
        readonly (int i, int j) rootPosition;

        public Sequence(int i, int j, ref string[][] array)
        {
            _parentArray = array;
            rootPosition = (i, j);
            foreach (string digit in array[i][j..])
            {
                if (!digit.IsNumber()) return;

                _sequence.Add(digit);
            }

        }

        internal bool HasAdjacentSymbol()
        {
            int firstCol, row;
            int rangeToAnalyze = this.Size + 2;
            firstCol = rootPosition.j - 1;

            // Upper Row
            row = rootPosition.i - 1;
            for (int i = firstCol; i < firstCol + rangeToAnalyze; i++)
            {
                if (!PosIsValid(row, i)) continue;
                if (_parentArray[row][i].IsSymbol()) return true;
            }

            // Same Row
            row = rootPosition.i;
            for (int i = firstCol; i < firstCol + rangeToAnalyze; i++)
            {
                if (!PosIsValid(row, i)) continue;
                if (_parentArray[row][i].IsSymbol()) return true;
            }

            // Lower Row
            row = rootPosition.i + 1;
            for (int i = firstCol; i < firstCol + rangeToAnalyze; i++)
            {
                if (!PosIsValid(row, i)) continue;
                if (_parentArray[row][i].IsSymbol()) return true;
            }

            return false;
        }

        private bool CheckRow(int row, int col)
        {
            for (int i = col; i < col + Size; i++)
            {
                if (!PosIsValid(row, i)) return false;
                if (_parentArray[row][i].IsSymbol()) return true;
            }

            return false;
        }

        private bool PosIsValid(Position tuple)
        {
            return tuple.i >= 0 && tuple.i < _parentArray.Length && tuple.j >= 0 && tuple.j < _parentArray[tuple.i].Length;
        }

        private bool PosIsValid(int i, int j)
        {
            return i >= 0 && i < _parentArray.Length && j >= 0 && j < _parentArray[i].Length;
        }

        private bool PosIsValid(int i)
        {
            return i >= 0 && i < _parentArray.Length;
        }
    }
}
