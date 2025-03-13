using System.ComponentModel.DataAnnotations;

namespace API_Orcamento.Rest.Form
{
    public class AcaoForm
    {
        [Required(ErrorMessage = "O código da Ação é obrigatório!")]
        [Range(1, int.MaxValue, ErrorMessage = "o código deve ser diferente de zero!")]
        public int codigo {  get; set; }
        [Required(ErrorMessage = "O nome da Ação é obrigatório!", AllowEmptyStrings = false)]
        public string nome { get; set; }
    }
}
