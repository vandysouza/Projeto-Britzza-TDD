using Britzza___v6.Interfaces;
using Britzza___v6.Models;
using Microsoft.AspNetCore.Mvc;

namespace Britzza___v6.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteController(
            IClienteRepository clienteRepository

            )
        {
            _clienteRepository = clienteRepository;

        }
        /// <summary>
        /// Busca Lista de Clientes 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult BuscaTodosClientes()
        {
            List<ClienteModel> result = new List<ClienteModel>();
            result = _clienteRepository.BuscaTodosClientes();
            if (result != null)
            {
                return View(result);
            }
            else
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        /// <summary>
        /// Busca Cliente pelo numero do Documento
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult BuscaClientePorDocumento(string documento)
        {
            ClienteModel result = new ClienteModel();
            result = _clienteRepository.BuscaClientePorDocumento(documento);
            if (result != null)
            {
                return View(result);
            }
            else
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        /// <summary>
        /// Cria Cliente
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult CriaCliente(ClienteModel model)
        {
            try
            {
                _clienteRepository.CriaCliente(model);
                return View();
            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        /// <summary>
        /// Altera Cliente
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult AlteraCliente(ClienteModel model)
        {
            try
            {
                _clienteRepository.AlteraCliente(model);
                return View();
            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }

    }
}
