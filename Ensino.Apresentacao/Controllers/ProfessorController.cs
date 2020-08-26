using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ensino.Aplicacao.DTO;
using Ensino.Aplicacao.Interface;
using Ensino.Dominio.Entidade;
using Microsoft.AspNetCore.Mvc;

namespace Ensino.Apresentacao.Controllers
{
    public class ProfessorController : ControllerBase<Professor, ProfessorDto>
    {
        readonly protected IAppProfessor _appProf;
        public ProfessorController(IAppProfessor app) : base(app)
        {
            _appProf = app;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            try
            {
                var objeto = _appProf.Get();
                return new OkObjectResult(objeto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro([FromBody] ProfessorDto professorDto)
        {
            try
            {
                return new OkObjectResult(_app.Put(professorDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}