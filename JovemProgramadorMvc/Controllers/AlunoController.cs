using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using JovemProgramadorMvc.Data.Repositorio.Interfaces;
using JovemProgramadorMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace JovemProgramadorMvc.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IAlunoRepositorio _alunoRepository;
        public AlunoController(IConfiguration configuration, IAlunoRepositorio alunoRepository)
        {
            _configuration = configuration;
            _alunoRepository = alunoRepository;
        }

        public IActionResult Index()
        {
            var alunos = _alunoRepository.BuscarAlunos();

            return View(alunos);
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        public async Task<IActionResult> BuscarEndereco(string cep)
        {
            var enderecoModel = new EnderecoModel();

            try
            {
                cep = cep.Replace("-", "");

                using var client = new HttpClient();
                var route = $"{_configuration.GetSection("ApiCep")["BaseUrl"]}{cep}/json";
                var result = await client.GetAsync(route);

                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    enderecoModel = JsonSerializer.Deserialize<EnderecoModel>(content, new JsonSerializerOptions());

                    if (string.IsNullOrEmpty(enderecoModel.complemento))
                    {
                        enderecoModel.complemento = "Nenhum";
                    }                    
                }
                else
                {
                    ViewData["Mensagem"] = "Erro na busca do endereço!";
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewData["Mensagem"] = $"Erro na busca do endereço! Mensagem: {ex.Message}";
                throw;
            }

            return View("BuscarEndereco", enderecoModel);
        }

        [HttpPost]
        public IActionResult InserirAsync(AlunoModel aluno)
        {
            var sucesso = _alunoRepository.Inserir(aluno);

            if (!sucesso)
            {
                ViewData["MensagemErro"] = "Houve um erro ao cadastrar o aluno, verifique!";
                return View();
            }
            
            ViewData["MensagemSucesso"] = "Aluno cadastrado com sucesso!";
            
            return RedirectToAction("Index", ViewData["MensagemSucesso"]);
        }
    }
}
