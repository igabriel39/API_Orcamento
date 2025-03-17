namespace API_Orcamento.Rest.Dto
{
    public record UnidadeDto
    {
        private int id;
        private string nome;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
    }
}
