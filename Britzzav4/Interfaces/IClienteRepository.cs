using Britzzav4.Models;

namespace Britzzav4.Interfaces
{
    public interface IClienteRepository
    {
        List<ClienteModel> BuscaTodosClientes();
        ClienteModel BuscaClientePorDocumento(string documento);
    }
}
