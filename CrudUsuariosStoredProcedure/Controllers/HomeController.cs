using CrudUsuariosStoredProcedure.Data;
using CrudUsuariosStoredProcedure.Models;
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


        #region Views
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

        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            //Responsável por buscar o usuário pelo id e 
            //preencher os campos para edição
            var usuario = _dataAccess.BuscarUsuarioPorId(id);

            return View(usuario);
        }

        public IActionResult Detalhes(int id)
        {
            var usuario = _dataAccess.BuscarUsuarioPorId(id);
            return View(usuario);
        }

        public IActionResult Remover(int id)
        {
            var result = _dataAccess.RemoverUsuario(id);

            if (result)
            {
                TempData["MensagemSucesso"] = "Usuário removido com sucesso";

            }
            else
            {
                TempData["MensagemErro"] = "Ocorreu um erro na remoção do usuário";
            }

            return RedirectToAction("Index");
        }
        #endregion


        #region Métodos
        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var result = _dataAccess.CadastrarUsuario(usuario);

                if (result)
                {
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["MensagemErro"] = "Ocorreu um erro na criação do usuário";
                return View(usuario);
            }

            try
            {
                _dataAccess.CadastrarUsuario(usuario);
                TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = "Ocorreu um erro na criação do usuário";
                return View();
            }
        }

        [HttpPost]
        public IActionResult Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var result = _dataAccess.EditarUsuario(usuario);

                if (result)
                {
                    TempData["MensagemSucesso"] = "Usuário editado com sucesso";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["MensagemErro"] = "Ocorreu um erro na edição do usuário";
                return View(usuario);
            }
            return View();
        }
        
        #endregion


    }
}
