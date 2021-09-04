namespace GenerateDto
{
    using System.Linq;
    using System.Text;

    public static class CodeScripter
    {
        public static string Script(NamespaceModel ns)
        {
            var sb = new StringBuilder();

            foreach (string comment in ns.TopLevelComments)
            {
                sb.AppendLine(comment);
            }

            if (ns.TopLevelComments.Any())
            {
                sb.AppendLine();
            }

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

                sb.Append(ScriptClass(classModel));
            }

            sb.AppendLine("}");

            return sb.ToString();
        }

        private static string ScriptClass(ClassModel classModel)
        {
            var sb = new StringBuilder();
            sb.Append($"    public{(classModel.Partial ? " partial" : "")} class {classModel.ClassName}");

            if (!classModel.IsEmpty)
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

                foreach (var method in classModel.Methods)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        sb.AppendLine();
                    }

                    string argumentList = string.Join(", ", method.Arguments.Select(x => $"{x.Type} {x.Name}"));

                    sb.AppendLine($"        public {method.ReturnType} {method.MethodName}({argumentList})");
                    sb.AppendLine("        {");
                    sb.AppendLine($"            {method.Body}");
                    sb.AppendLine("        }");
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
