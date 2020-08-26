using System.Collections.Generic;

namespace Ensino.Dominio.Entidade
{
    public class Professor : EntidadeBase
    {
        public string Nome { get; set; }

        public ICollection<Aluno> Alunos { get; set; }
    }
}
