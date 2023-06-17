using Britzza___v6.Models;

namespace Britzza___v6.Interfaces
{
    public interface IClienteRepository
    {
        List<ClienteModel> BuscaTodosClientes();
        ClienteModel BuscaClientePorDocumento(string documento);
      
    }
}
