using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Orcamento.Models
{
    public class LancamentoModel
    {
        // Anotação para chave primária e auto incremento
        [Key]
        private int id;

        [Required]
        private bool lancamentoValido;

        private int numeroLancamento;

        [Required]
        private DateTime dataLancamento;

        [Required]
        private string descricao;

        private string ged;

        private string contratado;

        [Required]
        private decimal valor;

        [Required]
        private DateTime dataCadastro;

        private DateTime dataAlteracao;

        [Required]
        private int anoOrcamento;


        [ForeignKey("TipoLancamentoModel")]
        private int tipoLancamentoId;
        public virtual TipoLancamentoModel TipoLancamento { get; set; }

        [ForeignKey("UnidadeModel")]
        private int unidadeId;
        public virtual UnidadeModel Unidade { get; set; }

        [ForeignKey("UnidadeOrcamentariaModel")]
        private int unidadeOrcamentariaId;
        public virtual UnidadeOrcamentariaModel UnidadeOrcamentaria { get; set; }

        [ForeignKey("ElementoDespesaModel")]
        private int elementoDespesaId;
        public virtual ElementoDespesaModel ElementoDespesa { get; set; }

        [ForeignKey("AcaoModel")]
        private int acaoId;
        public virtual AcaoModel Acao { get; set; }

        [ForeignKey("ProgramaModel")]
        private int programaId;
        public virtual ProgramaModel Programa { get; set; }

        [ForeignKey("SolicitanteModel")]
        private int solicitanteId;
        public virtual SolicitanteModel Solicitante { get; set; }

        [ForeignKey("ObjetivoEstrategicoModel")]
        private int objetivoEstrategicoId;
        public virtual ObjetivoEstrategicoModel ObjetivoEstrategico { get; set; }

        [ForeignKey("GrupoDespesaModel")]
        private int grupoDespesaModel;
        public virtual GrupoDespesaModel GrupoDespesa { get; set; }

        [ForeignKey("ModalidadeAplicacaoModel")]
        private int modalidadeAplicacaoId;
        public virtual ModalidadeAplicacaoModel ModalidadeAplicacao { get; set; }

        [ForeignKey("TipoTransacaoModel")]
        private int tipoTransacaoModel;
        public virtual TipoTransacaoModel TipoTransacao { get; set; }

        [ForeignKey("FonteRecursoModel")]
        private int fonteRecursoId;
        public virtual FonteRecursoModel FonteRecurso { get; set; }


        public int Id { get => id; set => id = value; }
        public bool LancamentoValido { get => lancamentoValido; set => lancamentoValido = value; }
        public int NumeroLancamento { get => numeroLancamento; set => numeroLancamento = value; }
        public DateTime DataLancamento { get => dataLancamento; set => dataLancamento = value; }
        public string GED { get => GED; set => GED = value; }
        public string Contratado { get => contratado; set => contratado = value; }
        public decimal Valor { get => valor; set => valor = value; }
        public DateTime DataCadastro { get => dataCadastro; set => dataCadastro = value; }
        public DateTime DataAlteracao { get => dataAlteracao; set => dataAlteracao = value; }
        public int AnoOrcamento { get => anoOrcamento; set => anoOrcamento = value; }

        public int TipoLancamentoId { get => TipoLancamentoId; set => TipoLancamentoId = value; }
        public int UnidadeId { get => UnidadeId; set => UnidadeId = value; }
        public int UnidadeOrcamentariaId { get => UnidadeOrcamentariaId; set => UnidadeOrcamentariaId = value; }
        public int ElementoDespesaId { get => ElementoDespesaId; set => ElementoDespesaId = value; }
        public int AcaoId { get => AcaoId; set => AcaoId = value; }
        public int ProgramaId { get => ProgramaId; set => ProgramaId = value; }
        public int SolicitanteId { get => SolicitanteId; set => SolicitanteId = value; }
        public int ObjetivoEstrategicoId { get => ObjetivoEstrategicoId; set => ObjetivoEstrategicoId = value; }
        public int GrupoDespesaId { get => GrupoDespesaId; set => GrupoDespesaId = value; }
        public int ModalidadeAplicacaoId { get => ModalidadeAplicacaoId; set => ModalidadeAplicacaoId = value; }
        public int TipoTransacaoId { get => TipoTransacaoId; set => TipoTransacaoId = value; }
        public int FonteRecursoId { get => FonteRecursoId; set => FonteRecursoId = value; }
    }
}
