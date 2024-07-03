using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financeiro.Domain.Entities
{
    public class Categoria
    {
        public int CategoriaID { get; set; }
        public string? Nome { get; set; }
        public string? Tipo { get; set; }
    }
}
