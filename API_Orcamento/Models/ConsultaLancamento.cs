﻿namespace API_Orcamento.Models
{
    // Classe criada para receber os dados da consulta de lançamentos pela consulta Bruta SQl que está no repository de lancamentos
    public class ConsultaLancamento
    {
        private int id;
        private bool lancamentoValido;
        private int numeroLancamento;
        private string descricao;
        private DateOnly dataLancamento;
        private int? idLancamentoPai;
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
        private string ged;
        private string contratado;
        private int anoOrcamento;

        public int Id { get => id; set => id = value; }
        public bool LancamentoValido { get => lancamentoValido; set => lancamentoValido = value; }
        public int NumeroLancamento { get => numeroLancamento; set => numeroLancamento = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public DateOnly DataLancamento { get => dataLancamento; set => dataLancamento = value; }
        public int? IdLancamentoPai { get => idLancamentoPai; set => idLancamentoPai = value; }
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
        public string Ged { get => ged; set => ged = value; }
        public string Contratado { get => contratado; set => contratado = value; }
        public int AnoOrcamento { get => anoOrcamento; set => anoOrcamento = value; }
    }
}
