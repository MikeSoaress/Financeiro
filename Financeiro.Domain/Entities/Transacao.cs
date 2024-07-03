using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financeiro.Domain.Entities
{
    public class Transacao
    {
        public int TransacaoID { get; set; }
        public float Valor { get; set; }
        public DateTime DataTransacao { get; set; }
        public int CategoriaID { get; set; }
        public Categoria? Categoria { get; set; }
    }
}
