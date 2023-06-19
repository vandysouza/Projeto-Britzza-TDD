using Britzza___v6.Interfaces;
using Britzza___v6.Models;
using Britzza___v6.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Britzza___v6.Controllers
{
    public class PedidoController : Controller
    {

        private readonly IPedidoRepository _pedidoRepository;
        public PedidoController(
            IPedidoRepository pedidoRepository
            )
        {
            _pedidoRepository = pedidoRepository;
        }

        /// <summary>
        /// Busca Lista de Pedidos 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult BuscaTodosPedidos()
        {
            try
            {
                ResultPedidoModel result = new ResultPedidoModel();
                result.ListaPedidos = new List<PedidoModel>();
                result.ListaPedidos = _pedidoRepository.BuscaTodosPedidos();
                if (result != null)
                {
                    return View(result);
                }
                else
                {
                    return View("~/Views/Shared/Error.cshtml");
                }
            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }


        [HttpGet]
        public ActionResult BuscaPedidoPorDocumento()
        {
            ResultPedidoModel result = new ResultPedidoModel();
            result.ListaPedidos = new List<PedidoModel>();
            return View(result);
        }

        /// <summary>
        /// Busca Pedidos pelo numero do Documento
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult BuscaPedidoPorDocumento(ResultClienteModel model)
        {
            try
            {
                ResultPedidoModel result = new ResultPedidoModel();
                result.ListaPedidos = new List<PedidoModel>();
                PedidoModel cl = _pedidoRepository.BuscaPedidoPorDocumento(model.BuscaDocumento);
                if (cl.Numero_Cliente.Equals(null))
                {
                    return View("~/Views/Shared/Error.cshtml");

                }
                else
                {
                    result.ListaPedidos.Add(cl);
                    return View(result);

                }
            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        [HttpGet]
        public ActionResult CriaPedido()
        {
            PedidoModel result = new PedidoModel();
            result.Numero_Cliente = null;
            return View(result);
        }

        /// <summary>
        /// Cria Pedido
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult CriaPedido(PedidoModel model)
        {
            try
            {
                _pedidoRepository.CriaPedido(model);
                PedidoModel cl = _pedidoRepository.BuscaPedidoPorDocumento(model.Numero_Cliente);
                return View(cl);
            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }


        [HttpGet]
        public ActionResult AlteraPedido()
        {
            PedidoModel result = new PedidoModel();
            return View(result);
        }

        /// <summary>
        /// Altera Pedido
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult AlteraPedido(PedidoModel model)
        {
            try
            {
                if (model.Numero_Cliente != null && model.Sabor_Pizza == null)
                {
                    PedidoModel cl = _pedidoRepository.BuscaPedidoPorDocumento(model.Numero_Cliente);
                    cl.Status = null;
                    return View(cl);

                }
                _pedidoRepository.AlteraPedido(model);
                PedidoModel cld = _pedidoRepository.BuscaPedidoPorDocumento(model.Numero_Cliente);
                return View(cld);

            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        [HttpGet]
        public ActionResult DeletaPedido()
        {
            PedidoModel result = new PedidoModel();
            return View(result);
        }

        /// <summary>
        /// Apaga Pedido
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult DeletaPedido(PedidoModel model)
        {
            try
            {
                PedidoModel cld = _pedidoRepository.BuscaPedidoPorDocumento(model.Numero_Cliente);
                _pedidoRepository.DeletaPedido(model.Numero_Cliente);
                return View(cld);
            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }
    }
}
