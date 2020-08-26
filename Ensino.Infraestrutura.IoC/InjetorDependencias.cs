using Microsoft.Extensions.DependencyInjection;
using Ensino.Aplicacao.Interface;
using Ensino.Aplicacao.Servico;
using Ensino.Dominio.Interface.Repositorio;
using Ensino.Dominio.Interface.Servico;
using Ensino.Infraestrutura.Data.Repositorio;
using Ensino.Dominio.Servico;

namespace Ensino.Infraestrutura.IoC
{
    public class InjetorDependencias
    {
        public static void Registrar(IServiceCollection svcCollection)
        {
            #region[ Professor ]
            //Aplicação
            svcCollection.AddScoped(typeof(IAppBase<,>), typeof(BaseAppServico<,>));
            svcCollection.AddScoped<IAppProfessor, ProfessorAppServico>();

            //Domínio
            svcCollection.AddScoped(typeof(IBaseServico<>), typeof(BaseServico<>));
            svcCollection.AddScoped<IProfessorServico, ProfessorServico>();

            //Repositorio
            svcCollection.AddScoped(typeof(IBaseRepositorio<>), typeof(BaseRepositorio<>));
            svcCollection.AddScoped<IProfessorRepositorio, ProfessorRepositorio>();
            #endregion

            #region[ Aluno ]
            //Aplicação
            svcCollection.AddScoped(typeof(IAppBase<,>), typeof(BaseAppServico<,>));
            svcCollection.AddScoped<IAppAluno, AlunoAppServico>();

            //Domínio
            svcCollection.AddScoped(typeof(IBaseServico<>), typeof(BaseServico<>));
            svcCollection.AddScoped<IAlunoServico, AlunoServico>();

            //Repositorio
            svcCollection.AddScoped(typeof(IBaseRepositorio<>), typeof(BaseRepositorio<>));
            svcCollection.AddScoped<IAlunoRepositorio, AlunoRepositorio>();
            #endregion

            #region[ Carga Dados ]
            //Aplicação
            svcCollection.AddScoped(typeof(IAppBase<,>), typeof(BaseAppServico<,>));
            svcCollection.AddScoped<IAppCargaDados, CargaDadosAppServico>();

            //Domínio
            svcCollection.AddScoped(typeof(IBaseServico<>), typeof(BaseServico<>));
            svcCollection.AddScoped<ICargaDadosServico, CargaDadosServico>();

            //Repositorio
            svcCollection.AddScoped(typeof(IBaseRepositorio<>), typeof(BaseRepositorio<>));
            svcCollection.AddScoped<ICargaDadosRepositorio, CargaDadosRepositorio>();
            #endregion
        }
    }
}
