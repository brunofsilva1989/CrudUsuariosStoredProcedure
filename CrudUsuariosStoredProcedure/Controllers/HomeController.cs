using CrudUsuariosStoredProcedure.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CrudUsuariosStoredProcedure.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly DataAccess _dataAccess;
        
        public HomeController(DataAccess dataAccess) 
        {
            _dataAccess = dataAccess;
        }


        public IActionResult Index()
        {

            try
            {
                var usuarios = _dataAccess.ListarUsuarios();
                return View(usuarios);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = "Ocorreu um erro na criação do usuário";
                return View();
            }
                                 
        }
               
    }
}
