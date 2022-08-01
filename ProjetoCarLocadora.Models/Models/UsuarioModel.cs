

using System.ComponentModel.DataAnnotations;

namespace ProjetoCarLocadora.Models.Models
{
    internal class UsuarioModel:EnderecoModel
    {
        [Key]
        [Required(ErrorMessage = "O CPF completo é obrigatório!")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "Este campo deve ter 14 caracteres!")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O Rg é obrigatório!")]
        [StringLength(50, MinimumLength = 12, ErrorMessage = "Este campo deve ter entre 5 e 50 caracteres!")]
        public string Rg { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "O nome completo é obrigatório!")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Este campo deve ter no mínimo 5 e no máximo 150 caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A Data de nascimento é obrigatória!")]
        public DateTime DataNascimento { get; set; }

        [StringLength(15, MinimumLength = 0)]
        public string? Telefone { get; set; }

        [Required(ErrorMessage = "O celular é obrigatório!")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Este campo deve ter no mínimo 10 e no máximo 15 caracteres!")]
        public string Celular { get; set; }

        [StringLength(300, MinimumLength = 10, ErrorMessage = "Este campo deve ter no mínimo 4 e no máximo 300 caracteres!")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "A data de inclusão é obrigatória!")]
        [Display(Name = "Data Inclusão")]
        public DateTime DataInclusao { get; set; }

        [Display(Name = "Data Alteração")]
        public DateTime? DataAlteracao { get; set; }
        public bool Ativo { get; set; }
    }
}
