using API_Orcamento.Models;
using API_Orcamento.Rest.Dto;
using API_Orcamento.Rest.Form;
using AutoMapper;
using System.Runtime.InteropServices;

namespace API_Orcamento.Config
{
    public class AutoMapperConfig : Profile
    {
        // Necessário colocar aqui todos os "mapeamentos" que serão usados ao AutoMapper ao longo do desenvolvimento.
        // Por exemplo vou utilizar o AutoMapper para preencher as informações do Model de Acao no Dto de Acao para retornar na requisiçãoo
        public AutoMapperConfig()
        {
            CreateMap<AcaoModel, AcaoDto>();
            CreateMap<AcaoForm, AcaoModel>();

            CreateMap<ElementoDespesaModel, ElementoDespesaDto>();
            CreateMap<ElementoDespesaForm, ElementoDespesaModel>();

            CreateMap<FonteRecursoModel, FonteRecursoDto>();
            CreateMap<FonteRecursoForm, FonteRecursoModel>();

            CreateMap<GrupoDespesaModel, GrupoDespesaDto>();
            CreateMap<GrupoDespesaForm, GrupoDespesaModel>();

            CreateMap<ModalidadeAplicacaoModel, ModalidadeAplicacaoDto>();
            CreateMap<ModalidadeAplicacaoForm, ModalidadeAplicacaoModel>();

            CreateMap<ObjetivoEstrategicoModel, ObjetivoEstrategicoDto>();
            CreateMap<ObjetivoEstrategicoForm, ObjetivoEstrategicoModel>();

            CreateMap<ProgramaModel, ProgramaDto>();
            CreateMap<ProgramaForm, ProgramaModel>();

            CreateMap<SolicitanteModel, SolicitanteDto>();
            CreateMap<SolicitanteForm, SolicitanteModel>();

            CreateMap<TipoLancamentoModel, TipoLancamentoDto>();
            CreateMap<TipoLancamentoForm, TipoLancamentoModel>();

            CreateMap<TipoTransacaoModel, TipoTransacaoDto>();
            CreateMap<TipoTransacaoForm, TipoTransacaoModel>();

            CreateMap<UnidadeModel, UnidadeDto>();
            CreateMap<UnidadeForm, UnidadeModel>();

            CreateMap<UnidadeOrcamentariaModel, UnidadeOrcamentariaDto>();
            CreateMap<UnidadeOrcamentariaForm, UnidadeOrcamentariaModel>();

            CreateMap<ConsultaLancamento, LancamentoDto>();
        }
    }
}
