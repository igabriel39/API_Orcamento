using System.ComponentModel.DataAnnotations;

namespace API_Orcamento.Rest.Form
{
    public class UnidadeOrcamentariaForm
    {
        [Required(ErrorMessage = "O código da Unidade Orçamentária é obrigatório!")]
        [Range(1, double.MaxValue, ErrorMessage = "o código deve ser diferente de zero!")]
        public int codigo { get; set; }
        [Required(ErrorMessage = "O nome da Unidade Orçamentária é obrigatório!", AllowEmptyStrings = false)]
        public string nome { get; set; }
    }
}
