namespace API_Orcamento.Rest.Form
{
    public record AcaoForm
    {
        private int codigo;
        private string nome;

        public int Codigo { get => codigo; set => codigo = value; }
        public string Nome { get => nome; set => nome = value; }
    }
}
