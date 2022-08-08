

using System.ComponentModel.DataAnnotations;

namespace ProjetoCarLocadora.Models.Models
{
    public class FormaDePagamentoModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória!")]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "Este campo deve ter no mínimo 1 e no máximo 150 caracteres!")]
        public string Descricao { get; set; } = "";

        [Required(ErrorMessage = "A data de inclusão é obrigatória!")]
        [Display(Name = "Data Inclusão")]
        public DateTime DataInclusao { get; set; }

        [Display(Name = "Data Alteração")]
        public DateTime? DataAlteracao { get; set; }

        [Required(ErrorMessage = "O campo ativo é obrigatório!")]
        public bool Ativo { get; set; }
    }
}
