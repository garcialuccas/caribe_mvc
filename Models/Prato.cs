using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace caribe_mvc.Models
{
    public class Prato
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Descricao { get; set;}

        public decimal Preco { get; set; }

        public bool Disponivel { get; set; }
    }
}