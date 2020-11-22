namespace GenerateDto
{
    using System.IO;

    public class Program
    {
        private static void Main()
        {
            var model = SwaggerDataProvider.GetDtoModels().GetAwaiter().GetResult();
            var ns = CodeBuilder.GetNamespace(model);
            string fileContent = CodeScripter.Script(ns);

            File.WriteAllText("../../../../../src/TvDbSharper/Dto.cs", fileContent);
        }
    }
}
