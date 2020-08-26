using System;

namespace Ensino.Dominio.Entidade
{
    public class Aluno : EntidadeBase
    {
        public string Nome { get; set; }
        public decimal Mensalidade { get; set; }
        public DateTime DataVencimento { get; set; }

        public int? ProfessorId { get; set; }
        public Professor Professor { get; set; }
    }
}
