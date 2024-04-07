using Fiap.UI.Escola.Web.Abstractions;
using Fiap.UI.Escola.Web.Entities;

namespace Fiap.UI.Escola.Web.Services;

internal sealed class AlunoService : HttpService<Aluno>, IAlunoService
{
    public AlunoService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        : base(httpClientFactory, configuration)
    {
    }
}
