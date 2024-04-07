namespace Fiap.UI.Escola.Web.Entities;

public class Turma
{
    public int id { get; set; }

    public int cursoId { get; set; }

    public string turma { get; set; } = string.Empty;

    public int ano { get; set; }
}
