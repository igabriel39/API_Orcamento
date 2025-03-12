using System.ComponentModel.DataAnnotations;

namespace API_Orcamento.Rest.Form
{
    public class AcaoForm
    {
        [Required(ErrorMessage = "O código da Ação é obrigatório!")]
        [Range(1, int.MaxValue, ErrorMessage = "o código deve ser diferente de zero!")]
        private int codigo;
        [Required(ErrorMessage = "O nome da Ação é obrigatório!", AllowEmptyStrings = false)]
        private string nome;

        public int Codigo { get => codigo; set => codigo = value; }
        public string Nome { get => nome; set => nome = value; }
    }
}
