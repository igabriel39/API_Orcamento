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
        [Range(typeof(decimal), "0.01", "9999999", ErrorMessage = "O valor do Lançamento deve ser maior que 0.")]
        public decimal? valor { get; set; }

        public int idTipoLancamento { get; set; }
        public int idUnidade { get; set; }
        public int idUnidadeOrcamentaria { get; set; }
        public int idPrograma { get; set; }
        public int idAcao { get; set; }
        public int idFonteRecurso { get; set; }
        public int idGrupoDespesa { get; set; }
        public int idModalidadeAplicacao { get; set; }
        public int idElementoDespesa { get; set; }
        public int idSolicitante { get; set; }
        public int idObjetivoEstrategico { get; set; }
        public int idTipoTransacao { get; set; }
        public string ged { get; set; }
        public string contratado { get; set; }

        [Required(ErrorMessage = "O ano do Lançamento é obrigatório!")]
        public short anoOrcamento { get; set; }
    }
}
