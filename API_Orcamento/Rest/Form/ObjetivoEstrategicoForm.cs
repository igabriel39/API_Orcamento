using System.ComponentModel.DataAnnotations;

namespace API_Orcamento.Rest.Form
{
    public class ObjetivoEstrategicoForm
    {
        [Required(ErrorMessage = "O nome do Objetivo Estratégico é obrigatório!", AllowEmptyStrings = false)]
        public string nome { get; set; }
    }
}
