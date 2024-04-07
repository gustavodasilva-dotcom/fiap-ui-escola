using Fiap.UI.Escola.Domain.Entities;
using MediatR;
using System.Text.Json;

namespace Fiap.UI.Escola.Application.Turmas.Queries.GetAll;

internal sealed class GetTurmasQueryHandler
    : IRequestHandler<GetAllTurmasQuery, IEnumerable<Turma>>
{
    public async Task<IEnumerable<Turma>> Handle(
        GetAllTurmasQuery request,
        CancellationToken cancellationToken)
    {
        var client = new HttpClient();
        var message = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44370/turmas");
        var response = await client.SendAsync(message);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync(cancellationToken);

        return JsonSerializer.Deserialize<Turma[]>(json)!;
    }
}
