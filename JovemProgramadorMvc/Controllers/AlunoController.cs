using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using JovemProgramadorMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace JovemProgramadorMvc.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IConfiguration _configuration;
        public AlunoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
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
            catch (Exception)
            {

                throw;
            }

            return View("BuscarEndereco", enderecoModel);
        }
    }
}
