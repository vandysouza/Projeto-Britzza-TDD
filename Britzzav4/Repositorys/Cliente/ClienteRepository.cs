using Britzzav4.Models;

namespace Britzzav4.Repositorys.Cliente
{
    public class ClienteRepository : IClienteRepository
    {
        public List<ClienteModel> BuscaTodosClientes()
        {
            List<ClienteModel> result = new List<ClienteModel>();
            try
            {

                return result;
            }
            catch (Exception ex)
            {
                var mensagem = ex.Message;
                throw;
            }
        }
        public ClienteModel BuscaClientePorDocumento(string documento)
        {
            ClienteModel result = new ClienteModel();
            try
            {

                return result;
            }
            catch (Exception ex)
            {
                var mensagem = ex.Message;
                throw;
            }
        }
    }
}
