using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Municipio
{
    public class MunicipioDtoCreate
    {
        [Required(ErrorMessage = "Nome de Município é campo Obrigatório!")]
        [StringLength(60, ErrorMessage = "Nome de Município deve ter o máximo {1} caracteres!")]
        public string Nome { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Código do IBGE inválido!")]
        public int CodIBGE { get; set; }

        [Required(ErrorMessage = "Código de UF é campo Obrigatório!")]
        public Guid UfId { get; set; }
    }
}
