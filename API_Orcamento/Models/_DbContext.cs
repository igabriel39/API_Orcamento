using Microsoft.EntityFrameworkCore;

namespace API_Orcamento.Models
{
    public class _DbContext: DbContext
    {
        public _DbContext(DbContextOptions<_DbContext> options) : base(options) 
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UnidadeModel> tbUnidade { get; set; }
        public DbSet<TipoLancamentoModel> tbTipoLancamento { get; set; }
        public DbSet<SolicitanteModel> tbSolicitante { get; set; }
        public DbSet<ObjetivoEstrategicoModel> tbObjetivoEstrategico { get; set; }
        public DbSet<UnidadeOrcamentariaModel> tbUnidadeOrcamentaria { get; set; }
        public DbSet<ProgramaModel> tbPrograma { get; set; }
        public DbSet<FonteRecursoModel> tbFonteRecurso { get; set; }
        public DbSet<AcaoModel> tbAcao { get; set; }
        public DbSet<GrupoDespesaModel> tbGrupoDespesa { get; set; }
        public DbSet<ModalidadeAplicacaoModel> tbModalidadeAplicacao { get; set; }
        public DbSet<ElementoDespesaModel> tbElementoDespesa { get; set; }
        public DbSet<TipoTransacaoModel> tbTipoTransacao { get; set; }
        public DbSet<LancamentoModel> tbLancamentos { get; set; }
    }
}
