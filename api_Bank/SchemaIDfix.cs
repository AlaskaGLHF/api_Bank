using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace api_Bank
{
    public class CustomSchemaIdFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            // Set unique schema IDs for specific DTOs
            if (context.Type == typeof(api_Bank.Dtos.UserDto.UserDtoUpdate))
            {
                schema.Description = "UserDto.Update Schema";
                schema.Reference = new OpenApiReference { Type = ReferenceType.Schema, Id = "UserDto_Update" }; // Custom SchemaId
            }
            else if (context.Type == typeof(api_Bank.Dtos.CardDto.CardDtoUpdate))
            {
                schema.Description = "CardDto.Update Schema";
                schema.Reference = new OpenApiReference { Type = ReferenceType.Schema, Id = "CardDto_Update" }; // Custom SchemaId
            }
        }
    }
}
