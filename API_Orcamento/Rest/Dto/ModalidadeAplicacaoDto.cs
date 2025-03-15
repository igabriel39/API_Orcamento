namespace API_Orcamento.Rest.Dto
{
    public record ModalidadeAplicacaoDto
    {
        private int id;
        private int codigo;
        private string nome;

        public int Id { get => id; set => id = value; }
        public int Codigo { get => codigo; set => codigo = value; }
        public string Nome { get => nome; set => nome = value; }
    }
}
