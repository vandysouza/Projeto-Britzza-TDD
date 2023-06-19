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
            ResultClienteModel result = new ResultClienteModel();
            result.ListaClientes = new List<ClienteModel>();
            result.ListaClientes = _clienteRepository.BuscaTodosClientes();
            if (result != null)
            {
                return View(result);
            }
            else
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        [HttpGet]
        public ActionResult BuscaClientePorDocumento()
        {
            ResultClienteModel result = new ResultClienteModel();
            result.ListaClientes = new List<ClienteModel>();
            return View(result);
        }

        /// <summary>
        /// Busca Cliente pelo numero do Documento
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult BuscaClientePorDocumento(ResultClienteModel model)
        {
            ResultClienteModel result = new ResultClienteModel();
            result.ListaClientes = new List<ClienteModel>();
            ClienteModel cl = _clienteRepository.BuscaClientePorDocumento(model.BuscaDocumento);
            if (cl == null) 
            {
                return View("~/Views/Shared/Error.cshtml");

            }
            else
            {
                result.ListaClientes.Add(cl);
                return View(result);

            }
        }

        [HttpGet]
        public ActionResult CriaCliente()
        {
            ClienteModel result = new ClienteModel();
            result.NumeroDocumento = null;
            return View(result);
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
                ClienteModel cl = _clienteRepository.BuscaClientePorDocumento(model.NumeroDocumento);
                return View(cl);
            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        [HttpGet]
        public ActionResult AlteraCliente()
        {
            ClienteModel result = new ClienteModel();
            return View(result);
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
                if (model.NumeroDocumento != null && model.Nome == null)
                {
                    ClienteModel cl = _clienteRepository.BuscaClientePorDocumento(model.NumeroDocumento);
                    cl.Telefone = null;
                    return View(cl);

                }                
                    _clienteRepository.AlteraCliente(model);
                ClienteModel cld = _clienteRepository.BuscaClientePorDocumento(model.NumeroDocumento);
                return View(cld);
                
            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        [HttpGet]
        public ActionResult DesabilitaCliente()
        {
            ClienteModel result = new ClienteModel();
            return View(result);
        }

        /// <summary>
        /// Desabilita Cliente
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult DesabilitaCliente(ClienteModel model)
        {
            try
            {
                ClienteModel cld = _clienteRepository.BuscaClientePorDocumento(model.NumeroDocumento);
                _clienteRepository.DesabilitaCliente(model.NumeroDocumento);
                return View(cld);
            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        [HttpGet]
        public ActionResult DeletaCliente()
        {
            ClienteModel result = new ClienteModel();
            return View(result);
        }

        /// <summary>
        /// Apaga Cliente
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult DeletaCliente(ClienteModel model)
        {
            try
            {
                ClienteModel cld = _clienteRepository.BuscaClientePorDocumento(model.NumeroDocumento);
                _clienteRepository.DeletaCliente(model.NumeroDocumento);
                return View(cld);
            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }
    }
}
