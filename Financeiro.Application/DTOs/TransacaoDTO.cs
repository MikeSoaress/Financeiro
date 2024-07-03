using Financeiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financeiro.Application.DTOs
{
    public class TransacaoDTO
    {
        public int TransacaoID { get; set; }


        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
        public float Valor { get; set; }

        [Required(ErrorMessage = "Informe a data da transação")]
        public DateTime? DataTransacao { get; set; }

        [Required(ErrorMessage = "Informe o ID da categoria de transação")]
        public int CategoriaID { get; set; }
    }
}
