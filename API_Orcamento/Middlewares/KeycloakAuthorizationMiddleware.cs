using System.Net.Http.Headers;
using System.Net;

namespace API_Orcamento.Middlewares
{
    public class KeycloakAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public KeycloakAuthorizationMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Token não fornecido.");
                return;
            }

            // Montar dinamicamente a permission da rota
            var permission = GetPermissionFromRequest(context);

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, _configuration["Keycloak:TokenEndpoint"]);
            request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "grant_type", "urn:ietf:params:oauth:grant-type:uma-ticket" },
                { "audience", _configuration["Keycloak:resource"] },
                { "permission", permission }, // Nome da rota e método HTTP para ser verificado
                { "permission_resource_format", "uri" }, // Vai procurar a rota nas URIS cadastradas no recurso do Keycloak
                { "response_mode", "decision" } // Indica que a resposta que quero é apenas uma decisão geral da Autorização. Está Autorizado? autorizado(200) ou não autorizado (403) 
             });

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Não Autorizado pela política do Keycloak.");
                return;
            }
            else if (response.StatusCode == HttpStatusCode.OK)
            {
                await _next(context);
            }

            await _next(context);
        }

        private string GetPermissionFromRequest(HttpContext context)
        {
            // Exemplo simples que usa o nome da rota + método HTTP como permission
            var path = context.Request.Path.Value?.Trim('/') ?? "desconhecido";
            var method = context.Request.Method.ToUpper(); // GET, POST, PUT, DELETE

            return $"{path}#{method}";
        }
    }
}
