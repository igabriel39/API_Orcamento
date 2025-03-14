namespace API_Orcamento.Rest.Dto
{
    public record GrupoDespesaDto
    {
        private int id;
        private decimal codigo;
        private string nome;

        public int Id { get => id; set => id = value; }
        public decimal Codigo { get => codigo; set => codigo = value; }
        public string Nome { get => nome; set => nome = value; }
    }
}
