using Microsoft.AspNetCore.Http;

namespace Ensino.Apresentacao.Classes
{
    public class Sessao
    {
        IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
    }
}
