using System.ComponentModel.DataAnnotations;

namespace API_Orcamento.Rest.Form
{
    public class UnidadeForm
    {
        [Required(ErrorMessage = "O nome da Unidade é obrigatório!", AllowEmptyStrings = false)]
        public string nome { get; set; }
    }
}
