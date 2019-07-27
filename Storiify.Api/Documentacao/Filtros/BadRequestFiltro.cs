using Storiify.Api.Controllers;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Storiify.Api.Documentacao.Filtros
{
    public class BadRequestFiltro : IOperationFilter
    {
        // Adiciona o erro BadRequest(400) à documentação Swagger em todos os endpoints
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (context.MethodInfo.DeclaringType.BaseType == typeof(ControladorBase))
            {
                operation.Responses.Add("400", new Response { Description = "Se alguma propriedade enviada não for válida." });
            }
        }
    }
}
