using AutoMapper;
using GerenciadorDeBiblioteca.Api.Data.ValueObjects;
using GerenciadorDeBiblioteca.Api.Model;

namespace GerenciadorDeBiblioteca.Api.Config
{  
  
        public class MappingConfig
        {
            public static MapperConfiguration RegisterMaps()
            {
                var mappingConfig = new MapperConfiguration(config =>
                {
                    config.CreateMap<UsuarioVO, Usuario>();
                    config.CreateMap<Usuario, UsuarioVO>();
                    config.CreateMap<LivroVO, Livro>();
                    config.CreateMap<Livro, LivroVO>();
                    config.CreateMap<EmprestimoVO, Emprestimo>();
                    config.CreateMap<Emprestimo, EmprestimoVO>();
                });
                return mappingConfig;
            }
        }
    }

