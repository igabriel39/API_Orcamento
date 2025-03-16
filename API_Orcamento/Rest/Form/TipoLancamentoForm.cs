using System.ComponentModel.DataAnnotations;

namespace API_Orcamento.Rest.Form
{
    public class TipoLancamentoForm
    {
        [Required(ErrorMessage = "O nome do Tipo Lançamento é obrigatório!", AllowEmptyStrings = false)]
        public string nome { get; set; }
    }
}
