using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCarLocadora.Models.Models
{
    public class LocacaoModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(14, MinimumLength = 14, ErrorMessage = "Este campo deve ter 14 caracteres")]
        [Required(ErrorMessage = "CPF do cliente é obrigatório.")]
        public string ClienteCPF { get; set; }
        public ClienteModel? Cliente { get; set; }



        [Required(ErrorMessage = "Forma de pagamento é obrigatório.")]
        public int FormaPagamentoId { get; set; }
        public FormaDePagamentoModel? FormaPagamento { get; set; }



        [Required(ErrorMessage = "categoria é obrigatório.")]
        public int CategoriaId { get; set; }
        public CategoriaModel? Categoria { get; set; }




        [Display(Name = "Placa do veiculo")]
        public string? VeiculoPlaca { get; set; }
        public VeiculoModel? Veiculo { get; set; }


        [Required(ErrorMessage = "Data da reserva é obrigatório.")]
        [Display(Name = " Data da reserva")]
        public DateTime DataHoraReserva { get; set; }

        [Required(ErrorMessage = "Data da retirada é obrigatório.")]
        [Display(Name = " Data da retirada")]
        public DateTime DataHoraRetiradaPrevista { get; set; }

        [Required(ErrorMessage = "Data da devolução é obrigatório.")]
        [Display(Name = " Data da devolução")]
        public DateTime DataHoraDevolucaoPrevista { get; set; }

        [Display(Name = "Data Inclusão")]
        public DateTime DataInclusao { get; set; }

        [Display(Name = "Data Alteração")]
        public DateTime? DataAlteracao { get; set; }
    }
}
