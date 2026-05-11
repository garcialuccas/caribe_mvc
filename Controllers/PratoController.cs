using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using caribe_mvc.Models;
using caribe_mvc.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace caribe_mvc.Controllers
{
    [Route("[controller]")]
    public class PratoController : Controller
    {
        private readonly PratoRepository _repository;

        public PratoController(PratoRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            List<Prato> pratos = _repository.ObterPratos();
            return View(pratos);
        }
    }
}