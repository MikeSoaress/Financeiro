using Financeiro.Application.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financeiro.Application.DTOs
{
    public class CategoriaDTO
    {
        public int CategoriaID { get; set; }

        [Required(ErrorMessage = "Informe o nome da categoria")]
        [StringLength(maximumLength:10, MinimumLength = 3, ErrorMessage = "A categoria deve ter entre 3 e 10 caracteres")]
        public string? Nome { get; set; }

        [Required]
        [EnumDataType(typeof(CategoriaTipo),ErrorMessage = "O tipo deve ser 'entrada' ou 'saida'.")]
        public string? Tipo { get; set; }
    }
}
