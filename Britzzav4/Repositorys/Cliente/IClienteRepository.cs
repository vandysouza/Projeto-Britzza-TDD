using Britzzav4.Models;

namespace Britzzav4.Repositorys.Cliente
{
    public interface IClienteRepository
    {
        List<ClienteModel> BuscaTodosClientes();
        ClienteModel BuscaClientePorDocumento(string documento);
    }
}
