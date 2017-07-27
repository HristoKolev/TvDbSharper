namespace TvDbSharper.Tests.Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class IntegerData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            return Enumerable.Range(1, 10).Select(num => new object[]
            {
                num
            }).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class DecimalData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            return Enumerable.Range(1, 10).Select(num => new object[]
            {
                (decimal)num
            }).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class EnumData<T> : IEnumerable<object[]>
        where T : struct, IConvertible
    {
        public EnumData()
        {
            if (!typeof(T).GetTypeInfo().IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            return Enum.GetValues(typeof(T)).Cast<T>().Select(e => new object[] { e }).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}