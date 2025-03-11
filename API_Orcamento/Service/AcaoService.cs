using API_Orcamento.Models;
using API_Orcamento.Repository.Interfaces;
using API_Orcamento.Rest.Dto;
using API_Orcamento.Rest.Form;
using AutoMapper;

namespace API_Orcamento.Service
{
    public class AcaoService
    {
        // Injeção de dependência com a camada de repositório para persistir ou consultar as informações no banco
        // Injeção de dependência com o AutoMapper para fazer o mapeamento de Model para Dto
        private readonly IAcaoRepository _acaoRepository;
        private readonly IMapper _mapper;
        public AcaoService(IAcaoRepository acaoRepository, IMapper mapper)
        {
            _acaoRepository = acaoRepository;
            _mapper = mapper;
        }

        public async Task<List<AcaoDto>> ObterTodos()
        {
            try
            {
                List<AcaoModel> acaoModels = await _acaoRepository.BuscarTodasAcoes();

                return (List<AcaoDto>)_mapper.Map<IEnumerable<AcaoDto>>(acaoModels);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar as Ações!");
            }
        }

        public async Task<AcaoDto> ObterPorId(int id)
        {
            try
            {
                AcaoModel acaoModel = await _acaoRepository.BuscarPorId(id);

                return _mapper.Map<AcaoDto>(acaoModel);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ação não encontrada para o ID: {id}!");
            }
        }

        public async Task<AcaoDto> Cadastrar(AcaoForm acaoForm)
        {
            try
            {
                AcaoModel acaoCadastrada = _mapper.Map<AcaoModel>(acaoForm);

                acaoCadastrada = await _acaoRepository.AdicionarAcao(acaoCadastrada);
                return _mapper.Map<AcaoDto>(acaoCadastrada);
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao cadastrar a Ação desejada!");
            }
        }
    }
}
