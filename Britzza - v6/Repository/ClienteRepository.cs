using Britzza___v6.Interfaces;
using Britzza___v6.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using static MongoDB.Driver.WriteConcern;

namespace Britzza___v6.Repository
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
                var filterEnabled = Builders<ClienteModel>.Filter.Eq(c => c.Enabled, true);
                var combineFilters = Builders<ClienteModel>.Filter.And(filter, filterEnabled);
                result = _clientes.Find(combineFilters).FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                var mensagem = ex.Message;
                throw;
            }
        }

        public void CriaCliente(ClienteModel cliente)
        {
            try
            {
                _clientes.InsertOne(cliente);
            }
            catch (Exception ex)
            {
                var mensagem = ex.Message;
                throw;
            }
        }
    }
}
