using API_Orcamento.Models;
using API_Orcamento.Rest.Dto;
using API_Orcamento.Rest.Form;
using AutoMapper;
using System.Runtime.InteropServices;

namespace API_Orcamento.Config
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            // Necessário colocar aqui todos os "mapeamentos" que serão usados ao AutoMapper ao longo do desenvolvimento.
            // Por exemplo vou utilizar o AutoMapper para preencher as informações do Model de Acao no Dto de Acao para retornar na requisiçãoo
            CreateMap<AcaoModel, AcaoDto>();
            CreateMap<AcaoForm, AcaoModel>();
        }
    }
}
