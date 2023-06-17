using Britzzav4.Interfaces;
using Britzzav4.Models;
using MongoDB.Driver;

namespace Britzzav4.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IMongoCollection<ClienteModel> _clientes;
        public ClienteRepository(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _clientes = database.GetCollection<ClienteModel>("clientes");
        }
        public List<ClienteModel> BuscaTodosClientes()
        {
            List<ClienteModel> result = new List<ClienteModel>();
            try
            {
                var filter = Builders<ClienteModel>.Filter.Eq(c => c.Enabled, true);
                result = _clientes.Find(filter).ToList();
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
                var filter = Builders<ClienteModel>.Filter.Eq(c => c.NumeroDocumento, documento);
                result = _clientes.Find(filter).FirstOrDefault();
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
