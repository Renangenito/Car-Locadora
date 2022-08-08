using System.ComponentModel.DataAnnotations;

namespace ProjetoCarLocadora.Models.Models
{
    public class VeiculoModel
    {
        [Key]
        [Required(ErrorMessage = "A placa do carro é obrigatória!")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Este campo deve ter 8 caracteres!")]
        public string Placa { get; set; }

        [StringLength(100, MinimumLength = 0)]
        public string? Chassi { get; set; }

        [Required(ErrorMessage = "A Marca do carro é obrigatória!")]
        [StringLength(100, MinimumLength =1, ErrorMessage = "Este campo deve ter entre 1 e 100 caracteres!")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O Modelo do carro é obrigatório!")]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "Este campo deve ter entre 1 e 150 caracteres!")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "O Combustivel do carro é obrigatório!")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Este campo deve ter entre 1 e 100 caracteres!")]
        public string Combustivel { get; set; }

        [Required(ErrorMessage = "A Cor do carro é obrigatória!")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Este campo deve ter entre 1 e 100 caracteres!")]
        public string Cor { get; set; }

        [StringLength(2000, MinimumLength = 0)]
        public string? Opcionais { get; set; }

        [Required(ErrorMessage = "O campo ativo é obrigatório!")]
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "A data de inclusão é obrigatória!")]
        [Display(Name = "Data Inclusão")]
        public DateTime DataInclusao { get; set; }

        [Display(Name = "Data Alteração")]
        public DateTime? DataAlteracao { get; set; }

    }
}
