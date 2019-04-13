using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Apresentacao.Api.Managers
{
    public class AddRequiredHeaderParameter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            operation.Parameters.Add(new NonBodyParameter
            {
                //Name = "X-MYHEADER",
                Name = "Authorization ",
                In = "header",
                Type = "string",
                Required = false
            });
        }
    }
}
