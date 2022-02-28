﻿namespace ZenAchitecture.WebUI.Processors
{
    using ZenAchitecture.Domain.Common;
    using NSwag;
    using NSwag.Generation.Processors;
    using NSwag.Generation.Processors.Contexts;

    public class SysLanguageHeaderOperationProcessor : IOperationProcessor
    {
        public bool Process(OperationProcessorContext context)
        {
            var openApiParameter = new OpenApiParameter
            {
                Name = "x-sys-language",
                Description = "System language indicator",
                Kind = OpenApiParameterKind.Header,
                Style = OpenApiParameterStyle.Simple,
                Type = NJsonSchema.JsonObjectType.String,
                IsRequired = false,
                Default = Constants.SystemCultureNames.English,
            };

            context.OperationDescription.Operation.Parameters.Add(openApiParameter);

            return openApiParameter != null;
        }

    }
}
