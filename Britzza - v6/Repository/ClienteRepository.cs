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
                cliente.ClienteId = ObjectId.GenerateNewId();
                cliente.Enabled = true;
                _clientes.InsertOne(cliente);
            }
            catch (Exception ex)
            {
                var mensagem = ex.Message;
                throw;
            }
        }

        public void AlteraCliente(ClienteModel model)
        {
            try
            {
                var filter = Builders<ClienteModel>.Filter.Eq(c => c.NumeroDocumento, model.NumeroDocumento);
                var update = Builders<ClienteModel>.Update.Set(c => c.Endereco, model.Endereco).Set(c => c.Telefone, model.Telefone).Set( c => c.Nome, model.Nome);
                _clientes.UpdateOne(filter, update);
            }
            catch (Exception ex)
            {
                var mensagem = ex.Message;
                throw;
            }
        }

        public void DesabilitaCliente(string documento)
        {
            try
            {
                var filter = Builders<ClienteModel>.Filter.Eq(c => c.NumeroDocumento, documento);
                var update = Builders<ClienteModel>.Update.Set(c => c.Enabled, false);
              var res =  _clientes.UpdateOne(filter, update);
            }
            catch (Exception ex)
            {
                var mensagem = ex.Message;
                throw;
            }
        }
        public void DeletaCliente(string documento)
        {
            try
            {
                var filter = Builders<ClienteModel>.Filter.Eq(c => c.NumeroDocumento, documento);
               var res =  _clientes.DeleteOne(filter);
            }
            catch (Exception ex)
            {
                var mensagem = ex.Message;
                throw;
            }
        }
    }
}
