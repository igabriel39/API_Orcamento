namespace API_Orcamento.Models
{
    public class GrupoDespesaModel
    {
        private int id;
        private int codigo;
        private string nome;
        private DateTime dtCadastro;
        private DateTime? dtUltimaAlteracao;

        public int Id { get => id; set => id = value; }
        public int Codigo { get => codigo; set => codigo = value; }
        public string Nome { get => nome; set => nome = value; }
        public DateTime DtCadastro { get => dtCadastro; set => dtCadastro = value; }
        public DateTime? DtUltimaAlteracao { get => dtUltimaAlteracao; set => dtUltimaAlteracao = value; }
    }
}
