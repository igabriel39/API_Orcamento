using System.ComponentModel.DataAnnotations;

namespace API_Orcamento.Rest.Form
{
    public class SolicitanteForm
    {
        [Required(ErrorMessage = "O nome do Solicitante é obrigatório!", AllowEmptyStrings = false)]
        public string nome { get; set; }
    }
}
