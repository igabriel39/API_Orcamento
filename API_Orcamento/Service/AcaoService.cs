﻿using API_Orcamento.Models;
using API_Orcamento.Repository.Interfaces;
using API_Orcamento.Rest.Dto;
using API_Orcamento.Rest.Form;
using API_Orcamento.Service.Exceptions;
using AutoMapper;
using System.Runtime.Intrinsics.X86;

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
                if (acaoModel == null)
                {
                    throw new ObjectNotFound($"Ação não encontrada para o ID: {id}");
                }
                else
                {
                    return _mapper.Map<AcaoDto>(acaoModel);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível consultar a Ação para o ID: {id}!");
            }
        }

        public async Task<AcaoDto> Cadastrar(AcaoForm acaoForm)
        {
            try
            {
                AcaoModel acaoCadastrada = _mapper.Map<AcaoModel>(acaoForm);
                acaoCadastrada.DtCadastro = DateTime.Now;

                acaoCadastrada = await _acaoRepository.AdicionarAcao(acaoCadastrada);
                return _mapper.Map<AcaoDto>(acaoCadastrada);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível cadastrar a Ação desejada!");
            }
        }

        public async Task<AcaoDto> Atualizar(AcaoForm acaoForm, int id)
        {
            try
            {
                AcaoModel acaoExistente = await _acaoRepository.BuscarPorId(id);
                if (acaoExistente == null)
                {
                    throw new ObjectNotFound($"Ação não encontrada para o ID: {id}");
                }
                else 
                {
                    AcaoModel acaoAtualizada = acaoExistente;
                    acaoAtualizada.Codigo = acaoForm.codigo;
                    acaoAtualizada.Nome = acaoForm.nome;
                    acaoAtualizada.DtUltimaAlteracao = DateTime.Now;
                    acaoAtualizada = await _acaoRepository.AtualizarAcao(acaoAtualizada);
                    return _mapper.Map<AcaoDto>(acaoAtualizada);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar a Ação desejada!");
            }
        }

        public async Task Apagar(int id)
        {
            try
            {
                AcaoModel acaoExistente = await _acaoRepository.BuscarPorId(id);
                if (acaoExistente == null)
                {
                    throw new ObjectNotFound($"Ação não encontrada para o ID: {id}");
                }
                else
                {
                    await _acaoRepository.ApagarAcao(acaoExistente); 
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível apagar a Ação desejada!");
            }
        }
    }
}
