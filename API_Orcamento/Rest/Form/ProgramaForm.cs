using System.ComponentModel.DataAnnotations;

namespace API_Orcamento.Rest.Form
{
    public class ProgramaForm
    {
        [Required(ErrorMessage = "O código do Programa é obrigatório!")]
        [Range(1, double.MaxValue, ErrorMessage = "o código deve ser diferente de zero!")]
        public int codigo { get; set; }
        [Required(ErrorMessage = "O nome do Programa é obrigatório!", AllowEmptyStrings = false)]
        public string nome { get; set; }
    }
}
