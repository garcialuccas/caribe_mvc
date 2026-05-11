using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using caribe_mvc.Contexts;
using caribe_mvc.Models;

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
    }
}