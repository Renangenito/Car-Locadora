using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ProjetoCarLocadora.Front.Servico;
using ProjetoCarLocadora.Models.Models;
using System.Net.Http.Headers;

namespace ProjetoCarLocadora.Front.Controllers
{
    public class FormaDePagamentoController : Controller
    {

        private readonly IOptions<DadosBase> _dadosBase;
        private readonly IApiToken _apiToken;

        public FormaDePagamentoController(IOptions<DadosBase> dadosBase, IApiToken apiToken)
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

            HttpResponseMessage response = client.GetAsync($"{_dadosBase.Value.API_URL_BASE}FormaDePagamento").Result;

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<List<FormaDePagamentoModel>>(conteudo));
            }
            else
            {
                throw new Exception("Erro ao tentar mostrar a lista de Formas de Pagamento!!");
            }

        }

        public ActionResult Details(string valor)
        {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());

            HttpResponseMessage response = client.GetAsync($"{_dadosBase.Value.API_URL_BASE}FormaDePagamento/ObterDadosFormaPagamento?id={valor}").Result;

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<FormaDePagamentoModel>(conteudo));
            }
            else
            {
                throw new Exception("Erro ao tentar mostrar os detalhes da Forma de Pagamento!!");
            }


        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        public ActionResult Create([FromForm] FormaDePagamentoModel formaDePagamentoModel)
        {

            try
            {

                if (ModelState.IsValid)
                {
                   
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());

                    HttpResponseMessage response = client.PostAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}FormaDePagamento", formaDePagamentoModel).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index), new { mensagem = "Registro cadastraado!", sucesso = true });

                    }
                    else
                    {
                        throw new Exception("Erro ao tentar inserir uma nova Forma de Pagamento!!");
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

            HttpResponseMessage response = client.GetAsync($"{_dadosBase.Value.API_URL_BASE}FormaDePagamento/ObterDadosFormaPagamento?id={valor}").Result;

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<FormaDePagamentoModel>(conteudo));
            }
            else
            {
                throw new Exception("Erro ao tentar editar uma Forma de Pagamento!!");
            }
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        public ActionResult Edit([FromForm] FormaDePagamentoModel formaDePagamentoModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                

                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());

                    HttpResponseMessage response = client.PutAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}FormaDePagamento", formaDePagamentoModel).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index), new { mensagem = "Registro Editado!", sucesso = true });

                    }
                    else
                    {
                        throw new Exception("Erro ao tentar editar uma Forma de Pagamento!!");
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

            HttpResponseMessage response = client.DeleteAsync($"{_dadosBase.Value.API_URL_BASE}FormaDePagamento?id={valor}").Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index), new { mensagem = "Registro excluído!", sucesso = true });
            }
            else
            {
                throw new Exception("Erro ao tentar deletar uma Forma de Pagamento!!");
            }
        }


    }
}
