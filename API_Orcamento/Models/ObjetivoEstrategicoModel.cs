using System.ComponentModel.DataAnnotations;

namespace API_Orcamento.Models
{
    public class ObjetivoEstrategicoModel
    {
        // Anotação para chave primária e auto incremento
        [Key]
        private int id;

        // Anotação para campo ser not null
        [Required]
        private string nome;

        // Anotação para campo ser not null
        [Required]
        private DateTime dtCadastro;

        private DateTime? dtUltimaAlteracao;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public DateTime DtCadastro { get => dtCadastro; set => dtCadastro = value; }
        public DateTime? DtUltimaAlteracao { get => dtUltimaAlteracao; set => dtUltimaAlteracao = value; }
    }
}
