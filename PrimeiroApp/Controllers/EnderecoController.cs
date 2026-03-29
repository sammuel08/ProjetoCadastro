using Microsoft.AspNetCore.Mvc;
using PrimeiroApp.Repositories.Contracts;
using PrimeiroApp.Models;   

namespace PrimeiroApp.Controllers
{
    public class EnderecoController : Controller
    {
        private IEnderecoRepositorio _enderecoRepositorio;  

        public EnderecoController(IEnderecoRepositorio enderecoRepositorio)
        {
            _enderecoRepositorio = enderecoRepositorio;
        }
        public IActionResult Index()
        {
            return View(_enderecoRepositorio.ObterEnderecos());
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                _enderecoRepositorio.Cadastrar(endereco);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }

}
