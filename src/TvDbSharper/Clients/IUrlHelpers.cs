namespace TvDbSharper.Clients
{
    using System;

    public interface IUrlHelpers
    {
        string Parametrify(Enum value);

        string PascalCase(string name);

        string Querify<T>(T obj);

        string QuerifyEnum(Enum obj);
    }
}