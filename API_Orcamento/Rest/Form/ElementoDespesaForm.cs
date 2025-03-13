using System.ComponentModel.DataAnnotations;

namespace API_Orcamento.Rest.Form
{
    public class ElementoDespesaForm
    {
        [Required(ErrorMessage = "O código do Elemento Despesa é obrigatório!")]
        [Range(1, int.MaxValue, ErrorMessage = "o código deve ser diferente de zero!")]
        public int codigo { get; set; }
        [Required(ErrorMessage = "O nome do Elemento Despesa é obrigatório!", AllowEmptyStrings = false)]
        public string nome { get; set; }
    }
}
