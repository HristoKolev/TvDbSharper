namespace TvDbSharper.Tests.Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class NumbersData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            foreach (int num in Enumerable.Range(1, 10))
            {
                yield return new object[] { num };
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}