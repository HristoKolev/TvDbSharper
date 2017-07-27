namespace TvDbSharper.Tests.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Xunit.Sdk;

    public class CompositeDataAttribute : DataAttribute
    {
        public CompositeDataAttribute(params Type[] types)
        {
            this.DataClasses = types;
        }

        private Type[] DataClasses { get; }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            var sources = this.DataClasses
                .Select(Activator.CreateInstance)
                .Cast<IEnumerable<object[]>>();

            var enumerators = sources.Select(x => x.GetEnumerator()).ToList();

            while (enumerators.All(e => e.MoveNext()))
            {
                yield return enumerators.SelectMany(e => e.Current).ToArray();
            }
        }
    }
}