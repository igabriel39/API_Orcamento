using System.ComponentModel.DataAnnotations;

namespace API_Orcamento.Rest.Form
{
    public class FonteRecursoForm
    {
        [Required(ErrorMessage = "O código da Fonte Recurso é obrigatório!")]
        [Range(1, double.MaxValue, ErrorMessage = "o código deve ser diferente de zero!")]
        public int codigo { get; set; }
        [Required(ErrorMessage = "O nome da Fonte Recurso é obrigatório!", AllowEmptyStrings = false)]
        public string nome { get; set; }
    }
}
