using System;

namespace Ensino.Aplicacao.DTO
{
    public class AlunoDto : BaseDto
    {
        public string Nome { get; set; }
        public decimal Mensalidade { get; set; }
        public DateTime DataVencimento { get; set; }

        public int? ProfessorId { get; set; }
        public ProfessorDto ProfessorDto { get; set; }
    }
}
