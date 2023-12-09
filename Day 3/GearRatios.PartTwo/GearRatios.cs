using Position = (int i, int j);

namespace GearRatios.PartTwo
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

    internal class Symbol : GearMap
    {
        public bool IsMultiplication => Value.Equals("*");
        public string Value { get; set; }
        public List<Sequence> AdjacentSequences { get; set; } = [];

        private readonly (int i, int j) pos;

        public Symbol(int i, int j, ref string[][] array)
        {
            _mapArray = array;
            pos = (i, j);
            Value = array[i][j];
        }

        public void FindAdjacentSequences()
        {
            for (int i = pos.i - 1; i <= pos.i + 1; i++)
            {
                for (int j = pos.j - 1; j <= pos.j + 1; j++)
                {
                    if (!PosIsValid(i, j)) continue;

                    if (_mapArray[i][j].IsNumber())
                    {
                        Sequence sequence = Sequence.FindSequence(i, j, ref _mapArray);
                        AdjacentSequences.Add(sequence);
                        if (j + sequence.Size >= _mapArray[i].Length) break;
                        j = NextNonNumberInRow(i, j);
                    }
                }
            }
        }
    }

    internal class Sequence : GearMap
    {
        internal int Value => int.Parse(string.Join("", _sequence));
        internal int Size => _sequence.Count;

        List<string> _sequence = [];
        readonly (int i, int j) rootPosition;

        public Sequence(int i, int j, ref string[][] array)
        {
            _mapArray = array;
            rootPosition = (i, j);
            foreach (string digit in array[i][j..])
            {
                if (!digit.IsNumber()) return;

                _sequence.Add(digit);
            }

        }

        public static Sequence FindSequence(int i, int j, ref string[][] array)
        {
            while (j - 1 >= 0 && array[i][j - 1].IsNumber())
            {
                j--;
            }

            return new Sequence(i, j, ref array);
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
                if (_mapArray[row][i].IsSymbol()) return true;
            }

            // Same Row
            row = rootPosition.i;
            for (int i = firstCol; i < firstCol + rangeToAnalyze; i++)
            {
                if (!PosIsValid(row, i)) continue;
                if (_mapArray[row][i].IsSymbol()) return true;
            }

            // Lower Row
            row = rootPosition.i + 1;
            for (int i = firstCol; i < firstCol + rangeToAnalyze; i++)
            {
                if (!PosIsValid(row, i)) continue;
                if (_mapArray[row][i].IsSymbol()) return true;
            }

            return false;
        }

        private bool CheckRow(int row, int col)
        {
            for (int i = col; i < col + Size; i++)
            {
                if (!PosIsValid(row, i)) return false;
                if (_mapArray[row][i].IsSymbol()) return true;
            }

            return false;
        }
    }

    internal abstract class GearMap
    {
        protected string[][] _mapArray = [];

        protected int NextNonNumberInRow(int i, int j)
        {
            for (; j < _mapArray[i].Length; j++)
            {
                if (!_mapArray[i][j].IsNumber()) return j;
            }
            return j;
        }

        protected bool PosIsValid(Position tuple)
        {
            return tuple.i >= 0 && tuple.i < _mapArray.Length && tuple.j >= 0 && tuple.j < _mapArray[tuple.i].Length;
        }

        protected bool PosIsValid(int i, int j)
        {
            return i >= 0 && i < _mapArray.Length && j >= 0 && j < _mapArray[i].Length;
        }

        protected bool PosIsValid(int i)
        {
            return i >= 0 && i < _mapArray.Length;
        }
    }
}
