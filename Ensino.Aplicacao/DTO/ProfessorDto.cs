using System.Collections.Generic;

namespace Ensino.Aplicacao.DTO
{
    public class ProfessorDto : BaseDto
    {
        public string Nome { get; set; }

        public ICollection<AlunoDto> AlunosDto { get; set; }
    }
}
