using Fiap.UI.Escola.Web.Abstractions;
using Fiap.UI.Escola.Web.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.UI.Escola.Web.Controllers
{
    public class TurmasController : Controller
    {
        private readonly ITurmaService _turmaService;

        public TurmasController(ITurmaService turmaService)
        {
            _turmaService = turmaService;
        }

        public async Task<ActionResult> Index()
        {
            var turmas = await _turmaService.GetAllAsync();

            return View(turmas);
        }

        public async Task<ActionResult> Details(int? id)
        {
            ViewBag.Id = id;

            Turma? turma = null;
            
            if (id is not null)
            {
                turma = await _turmaService.GetByIdAsync(id.Value);
            }

            return View(turma);
        }

        [HttpPost]
        public async Task<ActionResult> Salvar(IFormCollection collection)
        {
            try
            {
                var turma = new Turma()
                {
                    cursoId = int.Parse(collection["curso_id"]!),
                    turma = collection["turma"]!,
                    ano = int.Parse(collection["ano"]!)
                };

                if (int.TryParse(collection["id"], out int id))
                {
                    await _turmaService.UpdateAsync(id, turma);
                }
                else
                {
                    await _turmaService.InsertAsync(turma);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.Mensagem = e.Message;

                return View($"{nameof(Details)}/{collection["id"]}");
            }
        }

        public async Task<ActionResult> Deletar(int id)
        {
            try
            {
                await _turmaService.DeleteAsync(id);
            }
            catch (Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
