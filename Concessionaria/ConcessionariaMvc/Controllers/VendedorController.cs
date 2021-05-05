using System.Linq;
using System.Threading.Tasks;
using ConcessionariaContextLib;
using ConcessionariaEntitiesLib;
using ConcessionariaMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ConcessionariaMvc.Controllers
{
    public class VendedorController : Controller
    {
        public readonly ILogger<VendedorController> _logger;

        private Concessionaria db;

        public VendedorController(ILogger<VendedorController> logger, Concessionaria injectedContext){

            _logger = logger;
            db = injectedContext;

        }

        public async Task<IActionResult> Vendedores(){

            var model = new VendedorViewModel{
                Vendedores = await db.Vendedores.ToListAsync()

            };

            return View(model);
            
        }

        public IActionResult AddVendedor(){
            return View();

        }

        [HttpPost]
        public IActionResult AddVendedor(Vendedor vendedor){

            if(ModelState.IsValid){
                db.Vendedores.Add(vendedor);
                db.SaveChanges();

            }

            return View();

        }

        public IActionResult ConsultaVendedor(){
            return View();

        }

        [HttpPost]
        public IActionResult ConsultaVendedor(int? id){

            if(!id.HasValue){
                return NotFound("Digite um id válido.");

            }

            Vendedor vendedor = db.Vendedores.SingleOrDefault(vendedor => vendedor.VendedorID == id);
            if(vendedor == null){
                return NotFound("Vendedor não encontrado. Digite um id presente na base de dados.");

            }

            return View(vendedor);

        }

        public IActionResult DeletaVendedor(){
            return View();

        }

        [HttpPost]
        public IActionResult DeletaVendedor(int? id){

            if(!id.HasValue){
                return NotFound("Digite um id válido.");

            }

            Vendedor vendedor = db.Vendedores.SingleOrDefault(vendedor => vendedor.VendedorID == id);
            if(vendedor == null){
                return NotFound("Vendedor não encontrado. Digite um id presente na base de dados.");

            }else{
                db.Vendedores.Remove(vendedor);
                db.SaveChanges();
                
            }

            return View(vendedor);

        }

    }
}