using System.Collections;

namespace AdventOfCode.Common.Collections
{
    public class CircularList<T> : List<T>, IEnumerable<T>
    {
        public new IEnumerator<T> GetEnumerator() => new CircularEnumerator<T>(this);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class CircularEnumerator<T>(List<T> list) : IEnumerator<T>
    {
        int i = -1;

        public T Current => list[i];

        object IEnumerator.Current => this;

        public void Dispose() { }

        public bool MoveNext()
        {
            i = (i + 1) % list.Count;
            return true;
        }

        public void Reset() => i = 0;
    }
}
