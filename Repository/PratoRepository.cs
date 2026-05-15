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
            _context.Prato.Remove(_context.Prato.FirstOrDefault(x => x.Id == id));
            _context.SaveChanges();
        }
    }
}