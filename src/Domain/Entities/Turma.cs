namespace Fiap.UI.Escola.Domain.Entities;

public class Turma
{
    public int id { get; set; }

    public int curso_id { get; set; }

    public string turma { get; set; } = string.Empty;

    public int ano { get; set; }
}
