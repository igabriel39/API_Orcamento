using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.ComponentModel.DataAnnotations;

namespace API_Orcamento.Rest.Form
{
    public class LancamentoForm
    {
        [Required(ErrorMessage = "O campo de lançamento válido é obrigatório!")]
        public bool? lancamentoValido { get; set; }

        public int numeroLancamento { get; set; }

        [Required(ErrorMessage = "A descrição do Lançamento é obrigatório!", AllowEmptyStrings = false)]
        public string descricao { get; set; }

        [Required(ErrorMessage = "A data do Lançamento é obrigatório!")]
        public DateOnly dataLancamento { get; set; }

        public int idLancamentoPai { get; set; }

        [Required(ErrorMessage = "O valor do Lançamento é obrigatório!")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor do Lançamento deve ser maior que 0.")]
        public decimal? valor { get; set; }

        public int tipoLancamentoId { get; set; }
        public int unidadeId { get; set; }
        public int unidadeOrcamentariaId { get; set; }
        public int programaId { get; set; }
        public int acaoId { get; set; }
        public int fonteRecursoId { get; set; }
        public int grupoDespesaId { get; set; }
        public int modalidadeAplicacaoId { get; set; }
        public int elementoDespesaId { get; set; }
        public int solicitanteId { get; set; }
        public int objetivoEstrategicoId { get; set; }
        public int tipoTransacaoId { get; set; }
        public string ged { get; set; }
        public string contratado { get; set; }

        [Required(ErrorMessage = "O ano do Lançamento é obrigatório!")]
        public short anoOrcamento { get; set; }
    }
}
