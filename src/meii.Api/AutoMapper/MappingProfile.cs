using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using meii.Api.ViewModel;
using meii.Business.Entities;

namespace meii.Api.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>()
                .ForMember(x => x.Pessoa, opt => opt.MapFrom(x => x.Pessoa)).ReverseMap();

            CreateMap<Cliente, ClientePessoaFisicaViewModel>()
               .ForMember(x => x.Pessoa, opt => opt.MapFrom(x => x.Pessoa)).ReverseMap();

            CreateMap<Cliente, ClientePessoaJuridicaViewModel>()
              .ForMember(x => x.Pessoa, opt => opt.MapFrom(x => x.Pessoa)).ReverseMap();

           
            //Mapeando Herança
            CreateMap<Pessoa, PessoaViewModel>()
                .Include<PessoaFisica, PessoaFisicaViewModel>()
                .Include<PessoaJuridica, PessoaJuridicaViewModel>()
                .ForMember(p=> p.Endereco, opt => opt.MapFrom(e => e.Endereco))
                .ReverseMap();

            CreateMap<PessoaFisica, ClientePessoaFisicaViewModel>().ReverseMap();
            CreateMap<PessoaFisica, ClientePessoaJuridicaViewModel>().ReverseMap();
            
            CreateMap<PessoaFisica, PessoaFisicaViewModel>().ReverseMap();
            CreateMap<PessoaJuridica, PessoaJuridicaViewModel>().ReverseMap();

            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();

            CreateMap<Produto, ProdutoVM>()
                .ForMember(des => des.Categoria, opt => opt.MapFrom(c => c.Categoria)).ReverseMap();

            CreateMap<Categoria, CategoriaVM>().ReverseMap();
        }
       
    }
}
