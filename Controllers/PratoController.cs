using caribe_mvc.Models;
using caribe_mvc.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;


namespace caribe_mvc.Controllers
{
    public class PratoController : Controller
    {
        private readonly PratoRepository _repository;

        public PratoController(PratoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            @ViewData["Title"] = "Cardápio";
            List<Prato> pratos = _repository.ObterPratos();
            ViewBag.TotalPratos = pratos.Count;
            return View(pratos);
        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            @ViewData["Title"] = "Cadastro";    
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Prato p)
        {
            string precoString = Request.Form["preco"].ToString().Replace(".", ",");
            p.Disponivel = Request.Form["disponivel"].ToString() == "on" ? true : false;

            if (decimal.TryParse(precoString, out var precoConvertido))
            {
                p.Preco = precoConvertido;
            }

            _repository.Adicionar(p);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Excluir(int excluir_id)
        {
            _repository.Excluir(excluir_id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edicao(int edicao_id)
        {
            @ViewData["Title"] = "Edição";
            ViewBag.P = _repository.AcharPrato(edicao_id);
            return View();
        }

        [HttpPost]
        public IActionResult Edicao(Prato p, int edicao_id)
        {
            string precoString = Request.Form["preco"].ToString().Replace(".", ",");
            p.Disponivel = Request.Form["disponivel"].ToString() == "on" ? true : false;

            if (decimal.TryParse(precoString, out var precoConvertido))
            {
                p.Preco = precoConvertido;
            }

            _repository.Editar(p, edicao_id);
            return RedirectToAction("Index");
        }
    }
}