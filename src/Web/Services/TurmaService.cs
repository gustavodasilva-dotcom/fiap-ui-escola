using Fiap.UI.Escola.Web.Abstractions;
using Fiap.UI.Escola.Web.Entities;

namespace Fiap.UI.Escola.Web.Services;

internal sealed class TurmaService : HttpService<Turma>, ITurmaService
{
    public TurmaService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        : base(httpClientFactory, configuration)
    {
    }
}
