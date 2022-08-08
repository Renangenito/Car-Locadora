using System.ComponentModel.DataAnnotations;

namespace ProjetoCarLocadora.Models.Models
{
    public class CategoriaModel
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória!")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Este campo deve ter no mínimo 1 e no máximo 100 caracteres!")]
        public string Descricao { get; set; } = "";

        [Required(ErrorMessage = "O Valor da diaria é obrigatório!")]
        public decimal ValorDiaria { get; set; }

        [Required(ErrorMessage = "A data de inclusão é obrigatória!")]
        [Display(Name = "Data Inclusão")]
        public DateTime DataInclusao { get; set; }

        [Display(Name = "Data Alteração")]
        public DateTime? DataAlteracao { get; set; }

        [Required(ErrorMessage = "O campo ativo é obrigatório!")]
        public bool Ativo { get; set; }
    }
}
