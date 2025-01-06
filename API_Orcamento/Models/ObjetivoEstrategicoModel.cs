namespace API_Orcamento.Models
{
    public class ObjetivoEstrategicoModel
    {
        private int id;
        private string nome;
        private DateTime dtCadastro;
        private DateTime? dtUltimaAlteracao;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public DateTime DtCadastro { get => dtCadastro; set => dtCadastro = value; }
        public DateTime? DtUltimaAlteracao { get => dtUltimaAlteracao; set => dtUltimaAlteracao = value; }
    }
}
