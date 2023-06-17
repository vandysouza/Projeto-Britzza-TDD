using Britzza___v6.Models;

namespace Britzza___v6.Interfaces
{
    public interface IClienteRepository
    {
        List<ClienteModel> BuscaTodosClientes();
        ClienteModel BuscaClientePorDocumento(string documento);
        void CriaCliente(ClienteModel cliente);
        void AlteraCliente(ClienteModel model);
        void DesabilitaCliente(ClienteModel model);
        void DeletaCliente(string documento);
    }
}
