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
        /// <summary>
        /// M�todo respons�vel por view e listar os usu�rios
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            try
            {
                var usuarios = _dataAccess.ListarUsuarios();
                return View(usuarios);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = "Ocorreu um erro na cria��o do usu�rio";
                return View();
            }
        }

        /// <summary>
        /// M�todo respons�vel por chamar a view de cadastro
        /// </summary>
        /// <returns></returns>
        public IActionResult Cadastrar()
        {
            return View();
        }

        /// <summary>
        /// M�todo respons�vel por chamar a view de edi��o
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Editar(int id)
        {
            //Respons�vel por buscar o usu�rio pelo id e 
            //preencher os campos para edi��o
            var usuario = _dataAccess.BuscarUsuarioPorId(id);

            return View(usuario);
        }

        /// <summary>
        /// M�todo respons�vel por chamar a view de detalhes
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Detalhes(int id)
        {
            var usuario = _dataAccess.BuscarUsuarioPorId(id);
            return View(usuario);
        }

        /// <summary>
        /// M�todo respons�vel por chamar a view de remo��o
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Remover(int id)
        {
            var result = _dataAccess.RemoverUsuario(id);

            if (result)
            {
                TempData["MensagemSucesso"] = "Usu�rio removido com sucesso";

            }
            else
            {
                TempData["MensagemErro"] = "Ocorreu um erro na remo��o do usu�rio";
            }

            return RedirectToAction("Index");
        }
        #endregion


        #region M�todos
        /// <summary>
        /// M�todo respons�vel por cadastrar um usu�rio
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var result = _dataAccess.CadastrarUsuario(usuario);

                if (result)
                {
                    TempData["MensagemSucesso"] = "Usu�rio cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["MensagemErro"] = "Ocorreu um erro na cria��o do usu�rio";
                return View(usuario);
            }

            try
            {
                _dataAccess.CadastrarUsuario(usuario);
                TempData["MensagemSucesso"] = "Usu�rio cadastrado com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = "Ocorreu um erro na cria��o do usu�rio";
                return View();
            }
        }

        /// <summary>
        /// M�todo respons�vel por editar um usu�rio
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var result = _dataAccess.EditarUsuario(usuario);

                if (result)
                {
                    TempData["MensagemSucesso"] = "Usu�rio editado com sucesso";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["MensagemErro"] = "Ocorreu um erro na edi��o do usu�rio";
                return View(usuario);
            }
            return View();
        }
        
        #endregion


    }
}
