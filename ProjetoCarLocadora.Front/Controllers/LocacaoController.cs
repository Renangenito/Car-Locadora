using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ProjetoCarLocadora.Front.Servico;
using ProjetoCarLocadora.Models.Models;
using System.Net.Http.Headers;

namespace ProjetoCarLocadora.Front.Controllers
{
    public class LocacaoController : Controller
    {
        private readonly IOptions<DadosBase> _dadosBase;
        private readonly IApiToken _apiToken;

        public LocacaoController(IOptions<DadosBase> dadosBase, IApiToken apiToken)
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

            HttpResponseMessage response = client.GetAsync($"{_dadosBase.Value.API_URL_BASE}Locacao/ObterTodasLocacoes").Result;

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<List<LocacaoModel>>(conteudo));
            }
            else
            {
                throw new Exception("Erro ao tentar mostrar a lista de Locacaos!!");
            }

        }


        public ActionResult Details(string valor)
        {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());

            HttpResponseMessage response = client.GetAsync($"{_dadosBase.Value.API_URL_BASE}Locacao/ObterDadosLocacao?id={valor}").Result;

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<LocacaoModel>(conteudo));
            }
            else
            {
                throw new Exception("Erro ao tentar mostrar os detalhes da Locacao!!");
            }


        }

        // GET: ClienteController/Create

        public ActionResult Create()
        {
            ViewBag.Veiculos = CarregarVeiculos().Result;
            ViewBag.Clientes = CarregarClientes().Result;
            ViewBag.FormaDePagamento = CarregarFormaDePagamento().Result;
            return View();
        }
       
        // POST: ClienteController/Create
        [HttpPost]
        public ActionResult Create([FromForm] LocacaoModel locacaoModel)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());

                    HttpResponseMessage response = client.PostAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}Locacao", locacaoModel).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index), new { mensagem = "Registro cadastraado!", sucesso = true });

                    }
                    else
                    {
                        throw new Exception("Erro ao tentar inserir uma nova Locacao!!");
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

        // GET: ClienteController/Edit/5
        public ActionResult Edit(string valor)
        {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());

            HttpResponseMessage response = client.GetAsync($"{_dadosBase.Value.API_URL_BASE}Locacao/ObterDadosLocacao?id={valor}").Result;

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Veiculos = CarregarVeiculos().Result;
                ViewBag.Clientes = CarregarClientes().Result;
                ViewBag.FormaDePagamento = CarregarFormaDePagamento().Result;
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<LocacaoModel>(conteudo));
            }
            else
            {
                throw new Exception("Erro ao tentar editar uma Locacao!!");
            }
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        public ActionResult Edit([FromForm] LocacaoModel locacaoModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());

                    HttpResponseMessage response = client.PutAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}Locacao", locacaoModel).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index), new { mensagem = "Registro Editado!", sucesso = true });

                    }
                    else
                    {
                        throw new Exception("Erro ao tentar editar uma Locacao!!");
                    }


                }
                else
                {
                    ViewBag.Veiculos = CarregarVeiculos().Result;
                    ViewBag.Clientes = CarregarClientes().Result;
                    ViewBag.FormaDePagamento = CarregarFormaDePagamento().Result;
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



        //////////////////////////////AQUI//////////////////////////////



        private async Task<List<SelectListItem>> CarregarVeiculos()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",  _apiToken.Obter());

            HttpResponseMessage response = await client.GetAsync($"{_dadosBase.Value.API_URL_BASE}Veiculo");

            if (response.IsSuccessStatusCode)
            {
                List<VeiculoModel> veiculos = JsonConvert.DeserializeObject<List<VeiculoModel>>( response.Content.ReadAsStringAsync().Result);

                foreach (var linha in veiculos)
                {
                    lista.Add(new SelectListItem()
                    {
                        Value = linha.Placa,
                        Text = linha.Modelo + " - " + linha.Marca,
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

        private async Task<List<SelectListItem>> CarregarClientes()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());

            HttpResponseMessage response = await client.GetAsync($"{_dadosBase.Value.API_URL_BASE}Cliente/ObterTodosClientes");
            if (response.IsSuccessStatusCode)
            {
                List<ClienteModel> Clientes = JsonConvert.DeserializeObject<List<ClienteModel>>(response.Content.ReadAsStringAsync().Result);

                foreach (var linha in Clientes)
                {
                    lista.Add(new SelectListItem()
                    {
                        Value = linha.Cpf,
                        Text = linha.Nome + " - " + linha.Cpf,
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

        private async Task<List<SelectListItem>> CarregarFormaDePagamento()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",  _apiToken.Obter());

            HttpResponseMessage response = await client.GetAsync($"{_dadosBase.Value.API_URL_BASE}FormaDePagamento");
            
            if (response.IsSuccessStatusCode)
            {
                List<FormaDePagamentoModel> formasPagamento = JsonConvert.DeserializeObject<List<FormaDePagamentoModel>>( response.Content.ReadAsStringAsync().Result);

                foreach (var linha in formasPagamento)
                {
                    lista.Add(new SelectListItem()
                    {
                        Value = linha.Id.ToString(),
                        Text = linha.Descricao,
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
    }
}



