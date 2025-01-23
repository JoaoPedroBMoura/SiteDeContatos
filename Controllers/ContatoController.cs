using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Front_End_com_ASP.NET.Context;
using Front_End_com_ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace Front_End_com_ASP.NET.Controllers
{
    public class ContatoController : Controller
    {

        private readonly AgendaContext _context;

        public ContatoController(AgendaContext context) //injeção de dependência
        {
            _context = context;
        }

        public IActionResult Index(){
            var Contatos = _context.Contatos.ToList();
            return View(Contatos);
        }

        public IActionResult Criar(){
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Contato contato){
            if(ModelState.IsValid){
                _context.Contatos.Add(contato);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Editar(int id){
            var contato = _context.Contatos.Find(id);

            if (contato == null)
                return NotFound();

            return View(contato);
        }

        [HttpPost]
        public IActionResult Editar(Contato contatoSite){
            var contatoBanco = _context.Contatos.Find(contatoSite.Id);
            if (contatoBanco == null)
                return NotFound();
            contatoBanco.Nome = contatoSite.Nome;
            contatoBanco.Telefone = contatoSite.Telefone;
            contatoBanco.Ativo = contatoSite.Ativo;

            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int id){
            var contato = _context.Contatos.Find(id);

            if (contato == null)
                return RedirectToAction(nameof(Index));
            return View(contato);
        }

        public IActionResult Deletar(int id){
            var contato = _context.Contatos.Find(id);

            if (contato == null)
                return RedirectToAction(nameof(Index));
            return View(contato);
        }

        [HttpPost]
        public IActionResult Deletar(Contato contato){
            var contatoBanco = _context.Contatos.Find(contato.Id);

            _context.Contatos.Remove(contatoBanco);
            _context.SaveChanges();
            
            return RedirectToAction(nameof(Index));
        }
    }
}