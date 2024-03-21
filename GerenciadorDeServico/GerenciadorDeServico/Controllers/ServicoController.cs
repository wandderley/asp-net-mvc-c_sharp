using GerenciadorDeServico.Models;
using GerenciadorDeServico.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeServico.Controllers
{
    public class ServicoController : Controller
    {
        private readonly IServicoRepositorio _servicoRepositorio;
        public ServicoController(IServicoRepositorio servicoRepositorio)
        {
            _servicoRepositorio = servicoRepositorio;
        }

        public IActionResult Index()
        {
            List<ServicoModel> servicos = _servicoRepositorio.BuscarTodos();
            return View(servicos);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ServicoModel servico = _servicoRepositorio.ListarPorId(id);
            return View(servico);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ServicoModel servico = _servicoRepositorio.ListarPorId(id);
            return View(servico);
        }

        [HttpGet]
        public IActionResult Apagar(int id)
        {
            _servicoRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(ServicoModel servico)
        {
            if (ModelState.IsValid)
            {
                _servicoRepositorio.Adicionar(servico);
                return RedirectToAction("Index");
            }
            return View(servico);
        }

        [HttpPost]
        public IActionResult Alterar(ServicoModel servico)
        {
            if (ModelState.IsValid)
            {
                _servicoRepositorio.Atualizar(servico);
                return RedirectToAction("Index");
            }
            return View(servico);            
        }
    }
}