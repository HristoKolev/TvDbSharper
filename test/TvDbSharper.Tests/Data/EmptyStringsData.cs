namespace TvDbSharper.Tests.Data
{
    using System.Collections;
    using System.Collections.Generic;

    public class EmptyStringsData : IEnumerable<object[]>
    {
        private IEnumerable<object[]> Data { get; } = new List<object[]>
        {
            new[] { string.Empty },
            new[] { " " },
            new[] { "  " },
            new[] { "\t" },
            new[] { "\r" },
            new[] { "\n" },
            new[] { "  " },
            new[] { "   " },
            new[] { "\t\t\t\t" },
            new[] { "\r\r\r\r" },
            new[] { "\n\n\n\n" },
            new[] { " \n\t  \t\n  \r\n\t\t\n" }
        };

        public IEnumerator<object[]> GetEnumerator()
        {
            foreach (var objects in this.Data)
            {
                yield return objects;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}