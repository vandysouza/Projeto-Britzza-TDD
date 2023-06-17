using Britzzav4.Models;
using Britzzav4.Repositorys.Cliente;
using Microsoft.AspNetCore.Mvc;

namespace Britzzav4.Controllers
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
                //Aqui tem que passar o resultado da busca pro Front apresentar na View
                return View();
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
                //Aqui tem que passar o resultado da busca pro Front apresentar na View
                return View();
            }
            else
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }
    }
}
