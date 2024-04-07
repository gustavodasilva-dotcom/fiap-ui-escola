using Fiap.UI.Escola.Web.Abstractions;
using Fiap.UI.Escola.Web.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.UI.Escola.Web.Controllers;

public class AlunosController : Controller
{
    private readonly IAlunoService _alunoService;

    public AlunosController(IAlunoService alunoService)
    {
        _alunoService = alunoService;
    }

    public async Task<IActionResult> Index()
    {
        var alunos = await _alunoService.GetAllAsync();

        return View(alunos);
    }

    public async Task<ActionResult> Details(int? id)
    {
        ViewBag.Id = id;

        Aluno? aluno = null;

        if (id is not null)
        {
            aluno = await _alunoService.GetByIdAsync(id.Value);
        }

        return View(aluno);
    }

    [HttpPost]
    public async Task<ActionResult> Details(IFormCollection collection)
    {
        try
        {
            var aluno = new Aluno()
            {
                nome = collection["nome"]!,
                usuario = collection["usuario"]!,
                senha = collection["senha"]!
            };

            if (int.TryParse(collection["id"], out int id))
            {
                await _alunoService.UpdateAsync(id, aluno);
            }
            else
            {
                await _alunoService.InsertAsync(aluno);
            }

            return RedirectToAction(nameof(Index));
        }
        catch (Exception e)
        {
            ViewBag.Mensagem = e.Message;

            return View();
        }
    }

    public async Task<ActionResult> Deletar(int id)
    {
        try
        {
            await _alunoService.DeleteAsync(id);
        }
        catch (Exception e)
        {
            ViewBag.Mensagem = e.Message;
        }

        return RedirectToAction(nameof(Index));
    }
}
