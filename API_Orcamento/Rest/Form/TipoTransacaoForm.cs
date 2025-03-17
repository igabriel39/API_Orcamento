using System.ComponentModel.DataAnnotations;

namespace API_Orcamento.Rest.Form
{
    public class TipoTransacaoForm
    {
        [Required(ErrorMessage = "O nome do Tipo Transação é obrigatório!", AllowEmptyStrings = false)]
        public string nome { get; set; }
    }
}
