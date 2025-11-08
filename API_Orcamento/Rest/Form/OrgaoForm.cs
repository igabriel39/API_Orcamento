using System.ComponentModel.DataAnnotations;

namespace API_Orcamento.Rest.Form
{
    public class OrgaoForm
    {
        [Required(ErrorMessage = "O nome do Orgão é obrigatório!", AllowEmptyStrings = false)]
        public string nome { get; set; }
    }
}
