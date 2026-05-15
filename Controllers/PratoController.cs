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
            bool d = Request.Form["disponivel"].ToString() == "on" ? true : false;

            if (decimal.TryParse(precoString, out var precoConvertido))
            {
                p.Preco = precoConvertido;
            }

            p.Disponivel = d;

            _repository.Adicionar(p);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Excluir(int id)
        {
            _repository.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}