using AutoMapper;
using Ensino.Aplicacao.DTO;
using Ensino.Dominio.Entidade;

namespace Ensino.Aplicacao
{
    public class MappingEntidade : Profile
    {
        public MappingEntidade()
        {
            CreateMap<Professor, ProfessorDto>();
            CreateMap<ProfessorDto, Professor>();

            CreateMap<Aluno, AlunoDto>()
                .ForMember(d => d.ProfessorDto, opt => opt.MapFrom(s => s.Professor));
            CreateMap<AlunoDto, Aluno>()
                .ForMember(d => d.Professor, opt => opt.MapFrom(s => s.ProfessorDto));

            CreateMap<CargaDados, CargaDadosDto>();
            CreateMap<CargaDadosDto, CargaDados>();
        }
    }
}
