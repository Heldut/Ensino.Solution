using Ensino.Aplicacao.DTO;
using Ensino.Dominio.Entidade;
using Microsoft.AspNetCore.Mvc;
using Ensino.Aplicacao.Interface;

namespace Ensino.Apresentacao.Controllers
{
    public class ControllerBase<Entidade, EntidadeDTO> : Controller where Entidade : EntidadeBase where EntidadeDTO : BaseDto
    {
        readonly protected IAppBase<Entidade, EntidadeDTO> _app;

        public ControllerBase(IAppBase<Entidade, EntidadeDTO> app)
        {
            _app = app;
        }
    }
}