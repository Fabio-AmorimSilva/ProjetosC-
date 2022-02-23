using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using ImobiliariaContext;
using System.Net.Http.Json;
using ImobiliariaEntities;

namespace ImobiliariaMvc.Controllers
{
    public class AgenciaController : Controller
    {

        private Imobiliaria ImobiliariaDb;
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory clientFactory;

        

        public AgenciaController(
            ILogger<HomeController> logger, 
            Imobiliaria injectedContext,
            IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            ImobiliariaDb = injectedContext;
            clientFactory = httpClientFactory;
        }        

        /*

        [HttpGet]
        public IActionResult Agencias(){

            var model = new AgenciaViewModel{
                Agencias = db.Agencias.ToList()

            };
           

            return View(model);

        }

        public IActionResult AddAgencia(){

            return View();
        }

        [HttpPost]
        public IActionResult AddAgencia(Agencia agencia){

            var agenciaAux = db.Agencias.SingleOrDefault(a => a.id == agencia.id);
            if(agenciaAux == null){
                db.Agencias.Add(agencia);
                db.SaveChanges();

            }

            return View();

        }

        public IActionResult AlteraAgencia(){

            return View();

        }

        [HttpPost]
        public IActionResult AlteraAgencia(Agencia agencia){

            var agenciaAux = db.Agencias.SingleOrDefault(a => a.id == agencia.id);
            if(agenciaAux != null){
                agenciaAux.nome = agencia.nome;
                agenciaAux.cidade = agencia.cidade;
                agenciaAux.idCorretores = agencia.idCorretores;
                agenciaAux.idImoveis = agencia.idImoveis;
                db.SaveChanges();

            }

            return View();

        }

        public IActionResult DeletaAgencia(){

            return View();

        }

        [HttpPost]
        public IActionResult DeletaAgencia(Agencia agencia){

            var agenciaAux = db.Agencias.SingleOrDefault(a => a.id == agencia.id);
            if(agenciaAux != null){
                db.Agencias.Remove(agenciaAux);
                db.SaveChanges();

            }

            return View();

        }

        */

         public async Task<IActionResult> RetornaAgencias(){

            string uri = "api/Agencias";

            var httpClient = clientFactory.CreateClient(
              name: "ImobiliariaService"  
            );

            var request = new HttpRequestMessage(
                method: HttpMethod.Get, requestUri: uri
            );

            HttpResponseMessage response = await httpClient.SendAsync(request);

            var model = await response.Content.ReadFromJsonAsync<IEnumerable<Agencia>>();

            return View(model);

        }

        public IActionResult AddAgencia(){

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAgencia(Agencia agencia){

            string uri = $"api/Agencias/{agencia.id}";

            var httpClient = clientFactory.CreateClient(
                name: "ImobiliariaService"
            );

            httpClient.BaseAddress = new Uri("https://localhost:5001/" + uri);

            await httpClient.PostAsJsonAsync<Agencia>("Agencias", agencia);
            

            return View();

        }

        [HttpGet]
        public IActionResult AlteraAgencia(int id, Agencia agencia){

            var agenciaAux = ImobiliariaDb.Agencias.Find(agencia.id);

            return View(agenciaAux);

        }

        [HttpPost]
        public async Task<IActionResult> AlteraAgencia(Agencia agencia){

            string uri = $"api/Agencias/{agencia.id}";

            var httpClient = clientFactory.CreateClient(
                name: "ImobiliariaService"
            );

            httpClient.BaseAddress = new Uri("https://localhost:5001/" + uri);

            await httpClient.PutAsJsonAsync<Agencia>($"{agencia.id}", agencia);

            return View();

        }

        public IActionResult DeletaAgencia(){

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> DeletaAgencia(Agencia agencia){

            var httpClient = clientFactory.CreateClient(
                name: "ImobiliariaService"
            );

            httpClient.BaseAddress = new Uri("https://localhost:5001/api/");

            await httpClient.DeleteAsync($"Agencias/{agencia.id}" );

            return View();

        }
    }
}