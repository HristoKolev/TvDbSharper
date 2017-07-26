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
            return Enumerable.Range(1, 10).Select(num => new object[] { num }).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}