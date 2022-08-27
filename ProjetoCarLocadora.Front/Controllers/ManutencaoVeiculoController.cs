using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ProjetoCarLocadora.Front.Servico;
using ProjetoCarLocadora.Models.Models;
using System.Net.Http.Headers;

namespace ProjetoCarLocadora.Front.Controllers
{
    public class ManutencaoVeiculoController : Controller
    {
        private readonly IOptions<DadosBase> _dadosBase;
        private readonly IApiToken _apiToken;
        public ManutencaoVeiculoController(IOptions<DadosBase> dadosBase, IApiToken apiToken)
        {
            _dadosBase = dadosBase;
            _apiToken = apiToken;
        }

        public ActionResult Index(string mensagem = null, bool sucesso = true)
        {
            if (sucesso)
                TempData["Sucesso"] = mensagem;
            else
                TempData["Erro"] = mensagem;


            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());

            HttpResponseMessage response = client.GetAsync($"{_dadosBase.Value.API_URL_BASE}ManutencaoVeiculo/ObterTodasManutencoesVeiculos").Result;

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<List<ManutencaoVeiculoModel>>(conteudo));
            }
            else
            {
                throw new Exception("Erro ao tentar mostrar a lista de Manutenção de Veículos!!");
            }

        }

        public ActionResult Details(string valor)
        {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());

            HttpResponseMessage response = client.GetAsync($"{_dadosBase.Value.API_URL_BASE}ManutencaoVeiculo/ObterDadosManutencaoVeiculo?id={valor}").Result;

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<ManutencaoVeiculoModel>(conteudo));
            }
            else
            {
                throw new Exception("Erro ao tentar mostrar os detalhes da Manutencao de Veículos!!");
            }


        }


        public async Task<IActionResult> Create()
        {
            ViewBag.Veiculos = await CarregarVeiculos();
            return View();
        }
        private async Task<List<SelectListItem>> CarregarVeiculos()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",  _apiToken.Obter());

            HttpResponseMessage response = client.GetAsync($"{_dadosBase.Value.API_URL_BASE}Veiculo").Result;

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                List<VeiculoModel> Veiculos = JsonConvert.DeserializeObject<List<VeiculoModel>>(conteudo);

                foreach (var linha in Veiculos)
                {
                    lista.Add(new SelectListItem()
                    {
                        Value = linha.Placa.ToString(),
                        Text = linha.Placa + " - " + linha.Modelo,
                        Selected = false,
                    });
                }

                return lista;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
        public ActionResult Edit(string valor)
        {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());

            HttpResponseMessage response = client.GetAsync($"{_dadosBase.Value.API_URL_BASE}ManutencaoVeiculo/ObterDadosManutencaoVeiculo?id={valor}").Result;

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<ManutencaoVeiculoModel>(conteudo));
            }
            else
            {
                throw new Exception("Erro ao tentar editar uma Manutencao de Veiculo!!");
            }
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        public ActionResult Edit([FromForm] ManutencaoVeiculoModel manutencaoVeiculoModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());

                    HttpResponseMessage response = client.PutAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}ManutencaoVeiculo", manutencaoVeiculoModel).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index), new { mensagem = "Registro Editado!", sucesso = true });

                    }
                    else
                    {
                        throw new Exception("Erro ao tentar editar uma Manutenção de Veículo!!");
                    }


                }
                else
                {
                    TempData["erro"] = "Algum campo deve estar faltando preenchimento";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["erro"] = "Algum erro aconteceu - " + ex.Message;
                return View();
            }
        }
        public ActionResult Delete(string valor)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());

            HttpResponseMessage response = client.DeleteAsync($"{_dadosBase.Value.API_URL_BASE}ManutencaoVeiculo?id={valor}").Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index), new { mensagem = "Registro excluído!", sucesso = true });
            }
            else
            {
                throw new Exception("Erro ao tentar deletar uma Manutencao de Veiculo!!");
            }
        }
    }
}
