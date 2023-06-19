using Britzza___v6.Models;
using Microsoft.AspNetCore.Mvc;

namespace Britzza___v6.Controllers
{
    public class PedidoController : Controller
    {
        /// <summary>
        /// Busca Lista de Pedidos 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult BuscaTodosPedidos()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        /// <summary>
        /// Busca Pedidos pelo numero do Documento
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult BuscaPedidoPorDocumento()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        /// <summary>
        /// Cria Pedido
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult CriaPedido()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        /// <summary>
        /// Altera Pedido
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult AlteraPedido()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        /// <summary>
        /// Apaga Pedido
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult DeletaPedido()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }
    }
}
