namespace API_Orcamento.Rest.Dto
{
    public record LancamentoDto
    {
        private int id;
        private bool lancamentoValido;
        private int numeroLancamento;
        private string descricao;
        private string dataLancamento;
        private int idLancamentoPai;
        private decimal valor;
        private string dsTipoLancamento;
        private string dsUnidade;
        private string dsUnidadeOrcamentaria;
        private string dsPrograma;
        private string dsAcao;
        private string dsFonteRecurso;
        private string dsGrupoDespesa;
        private string dsModalidadeAplicacao;
        private string dsElementoDespesa;
        private string dsSolicitante;
        private string dsObjetivoEstrategico;
        private string dsTipoTransacao;
        private string GED;
        private string contratado;
        private short anoOrcamento;

        public int Id { get => id; set => id = value; }
        public bool LancamentoValido { get => lancamentoValido; set => lancamentoValido = value; }
        public int NumeroLancamento { get => numeroLancamento; set => numeroLancamento = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public string DataLancamento { get => dataLancamento; set => dataLancamento = value; }
        public int IdLancamentoPai { get => idLancamentoPai; set => idLancamentoPai = value; }
        public decimal Valor { get => valor; set => valor = value; }
        public string DsTipoLancamento { get => dsTipoLancamento; set => dsTipoLancamento = value; }
        public string DsUnidade { get => dsUnidade; set => dsUnidade = value; }
        public string DsUnidadeOrcamentaria { get => dsUnidadeOrcamentaria; set => dsUnidadeOrcamentaria = value; }
        public string DsPrograma { get => dsPrograma; set => dsPrograma = value; }
        public string DsAcao { get => dsAcao; set => dsAcao = value; }
        public string DsFonteRecurso { get => dsFonteRecurso; set => dsFonteRecurso = value; }
        public string DsGrupoDespesa { get => dsGrupoDespesa; set => dsGrupoDespesa = value; }
        public string DsModalidadeAplicacao { get => dsModalidadeAplicacao; set => dsModalidadeAplicacao = value; }
        public string DsElementoDespesa { get => dsElementoDespesa; set => dsElementoDespesa = value; }
        public string DsSolicitante { get => dsSolicitante; set => dsSolicitante = value; }
        public string DsObjetivoEstrategico { get => dsObjetivoEstrategico; set => dsObjetivoEstrategico = value; }
        public string DsTipoTransacao { get => dsTipoTransacao; set => dsTipoTransacao = value; }
        public string GED1 { get => GED; set => GED = value; }
        public string Contratado { get => contratado; set => contratado = value; }
        public short AnoOrcamento { get => anoOrcamento; set => anoOrcamento = value; }
    }
}
