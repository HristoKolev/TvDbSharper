namespace GenerateDto
{
    using System.Linq;
    using System.Text;

    public static class CodeScripter
    {
        public static string Script(NamespaceModel ns)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"namespace {ns.NamespaceName}");

            sb.AppendLine("{");

            foreach (string import in ns.Usings)
            {
                sb.AppendLine($"    using {import};");
            }

            sb.AppendLine();

            bool first = true;

            foreach (var classModel in ns.Classes)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    sb.AppendLine();
                }

                sb.Append(ScriptDto(classModel));
            }

            sb.AppendLine("}");

            return sb.ToString();
        }

        private static string ScriptDto(ClassModel classModel)
        {
            var sb = new StringBuilder();
            sb.Append($"    public class {classModel.ClassName}");

            if (classModel.Properties.Any())
            {
                sb.AppendLine();
                sb.AppendLine("    {");

                bool first = true;

                foreach (var property in classModel.Properties)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        sb.AppendLine();
                    }

                    foreach (string propertyAttribute in property.PropertyAttributes)
                    {
                        sb.AppendLine($"        {propertyAttribute}");
                    }

                    sb.AppendLine($"        public {property.PropertyType} {property.PropertyName} {{ get; set; }}");
                }

                sb.AppendLine("    }");
            }
            else
            {
                sb.Append(" { }");
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
