﻿namespace API_Orcamento.Rest.Dto
{
    public record TipoTransacaoDto
    {
        private int id;
        private string nome;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
    }
}
