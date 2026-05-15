using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using caribe_mvc.Contexts;
using caribe_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace caribe_mvc.Repository
{
    public class PratoRepository
    {
        private readonly CaribeDBContext _context;

        public PratoRepository(CaribeDBContext context)
        {
            _context = context;
        }

        public List<Prato> ObterPratos()
        {
            return _context.Prato.ToList();
        }

        public void Adicionar(Prato p)
        {
            _context.Prato.Add(p);
            _context.SaveChanges();
        }

        public void Excluir(int id)
        {
            var p = _context.Prato.FirstOrDefault(x => x.Id == id);
            if (p == null) return;
            _context.Prato.Remove(p);
            _context.SaveChanges();
        }
        public void Editar(Prato novo, int id)
        {
            var p = _context.Prato.FirstOrDefault(x => x.Id == id);
            if (p == null) return;
            p.Nome = novo.Nome;
            p.Descricao = novo.Descricao;
            p.Preco = novo.Preco;
            p.Disponivel = novo.Disponivel;

            _context.Prato.Update(p);
            _context.SaveChanges();
        }

        public Prato AcharPrato(int id)
        {
            return _context.Prato.FirstOrDefault(x => x.Id == id)!;
        }
    }
}