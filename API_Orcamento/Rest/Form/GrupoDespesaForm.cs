using System.ComponentModel.DataAnnotations;

namespace API_Orcamento.Rest.Form
{
    public class GrupoDespesaForm
    {
        [Required(ErrorMessage = "O código do Grupo Despesa é obrigatório!")]
        [Range(1, double.MaxValue, ErrorMessage = "o código deve ser diferente de zero!")]
        public decimal codigo { get; set; }
        [Required(ErrorMessage = "O nome do Grupo Despesa é obrigatório!", AllowEmptyStrings = false)]
        public string nome { get; set; }
    }
}
