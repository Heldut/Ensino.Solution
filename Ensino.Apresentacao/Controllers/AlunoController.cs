using System;
using System.Text;
using Newtonsoft.Json;
using Ensino.Aplicacao.DTO;
using Ensino.Dominio.Entidade;
using Ensino.Aplicacao.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Ensino.Apresentacao.Models;
using Microsoft.Extensions.Options;

namespace Ensino.Apresentacao.Controllers
{
    public class AlunoController : ControllerBase<Aluno, AlunoDto>
    {
        readonly protected IAppAluno _appAlun;
        readonly protected IAppProfessor _appProf;
        readonly protected IAppCargaDados _appCarDad;
        readonly protected Information _informationAppSettings;

        public AlunoController(IAppAluno app, IAppProfessor appProf, IAppCargaDados appCarDad, IOptions<Information> informationAppSettings) : base(app)
        {
            _appAlun = app;
            _appProf = appProf;
            _appCarDad = appCarDad;
            _informationAppSettings = informationAppSettings.Value;
        }

        public IActionResult Index(string id)
        {
            ViewBag.IdProfesor = id;
            return View();
        }

        public IActionResult List(string id)
        {
            try
            {
                int idProfessor = -1;
                if(!int.TryParse(id, out idProfessor))
                {
                    idProfessor = -1;
                }

                if (idProfessor > 0)
                {
                    return new OkObjectResult(_appAlun.GetAllByIdProfessor(idProfessor));
                }
                else
                {
                    return new OkObjectResult(_appAlun.GetAll());
                }


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public JsonResult FileUpload(string aluno)
         {
            try
            {
                bool dataUploadValida = false;
                StringBuilder mesgCargaDados = new StringBuilder();
                List<string> erros = new List<string>();
                IEnumerable<AlunoDto> alunosDto = JsonConvert.DeserializeObject<IEnumerable<AlunoDto>>(aluno);

                foreach (AlunoDto item in alunosDto)
                {
                    if (item.ProfessorDto != null)
                    {
                        ProfessorDto professorDto = _appProf.GetAllByNome(item.ProfessorDto.Nome.Replace("\r", ""));
                        if(professorDto != null)
                        {
                            // Trata o tempo
                            if(dataUploadValida == false)
                            {
                                string msgUploadValida = BuscaUltimoArquivoUpload();
                                if (msgUploadValida != "OK")
                                {
                                    return Json(string.Join(Environment.NewLine, msgUploadValida));
                                }
                                dataUploadValida = true;
                            }

                            item.ProfessorId = professorDto.Id;
                            _appAlun.Put(item);                           

                            erros.Add("Aluno: " + item.Nome + " cadastrado com sucesso.");
                        }
                        else
                        {
                            mesgCargaDados.Append(" - Erro:" + item.ProfessorDto.Nome);
                            erros.Add("Professor: " + item.ProfessorDto.Nome + " não cadastrado. Aluno não cadastrado.");
                        }
                    }
                    else
                    {
                        _appAlun.Put(item);
                        erros.Add("Aluno: " + item.Nome + " cadastrado com sucesso.");
                    }
                }

                CargaDadosDto cargaDadosDto = new CargaDadosDto();
                cargaDadosDto.Descricao = "Upload Aluno-Professor" + mesgCargaDados.ToString();
                cargaDadosDto.DataUpload = DateTime.Now;
                _appCarDad.Put(cargaDadosDto);

                return Json(string.Join(Environment.NewLine, erros));
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, ex.Message));
            }
        }

        [HttpPost]
        public JsonResult Delete(string id)
        {
            try
            {
                int idAluno = -1;
                if (!int.TryParse(id, out idAluno))
                {
                    Response.StatusCode = 400;
                    return Json(string.Join(Environment.NewLine, "Não foi possível ler o indentificador !"));
                }

                _appAlun.DeleteById(idAluno);
                return Json(string.Join(Environment.NewLine, "Ok !"));
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, ex.Message));
            }
        }

        private string BuscaUltimoArquivoUpload()
        {
            try
            {
                int minutos = -1;
                if(!int.TryParse(_informationAppSettings.LoadTime, out minutos)){
                    minutos = 0;
                }

                CargaDadosDto cargaDadosDto = new CargaDadosDto();
                cargaDadosDto = _appCarDad.GetLastUpload();
                if (cargaDadosDto == null)
                {
                    return "OK";
                }

                DateTime dataProximoUpload = new DateTime();                
                dataProximoUpload = cargaDadosDto.DataUpload.AddMinutes(minutos);


                if (DateTime.Now < dataProximoUpload)
                {
                    return "Próxima carga de dados para ALUNO/PROFESSOR só após: " + dataProximoUpload.ToString();
                }

                return "OK";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}