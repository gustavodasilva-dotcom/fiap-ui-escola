using Fiap.UI.Escola.Domain.Entities;
using MediatR;

namespace Fiap.UI.Escola.Application.Turmas.Queries.GetAll;

public record GetAllTurmasQuery : IRequest<IEnumerable<Turma>>;
