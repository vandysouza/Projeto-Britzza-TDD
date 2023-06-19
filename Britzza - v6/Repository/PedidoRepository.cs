using Britzza___v6.Interfaces;
using Britzza___v6.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Britzza___v6.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly IMongoCollection<PedidoModel> _pedidos;
        public PedidoRepository(string connectionString, string databaseName)
        {
            var pedido = new MongoClient(connectionString);
            var database = pedido.GetDatabase(databaseName);
            _pedidos = database.GetCollection<PedidoModel>("pedidos");
        }

        public List<PedidoModel> BuscaTodosPedidos()
        {
            List<PedidoModel> result = new List<PedidoModel>();
            try
            {
                var filter = Builders<PedidoModel>.Filter.Eq(c => c.Enabled, true);
                result = _pedidos.Find(filter).ToList();
                return result;
            }
            catch (Exception ex)
            {
                var mensagem = ex.Message;
                throw;
            }
        }

        public PedidoModel BuscaPedidoPorDocumento(string documento)
        {
            PedidoModel result = new PedidoModel();
            try
            {
                var filter = Builders<PedidoModel>.Filter.Eq(c => c.Numero_Cliente, documento);
                var filterEnabled = Builders<PedidoModel>.Filter.Eq(c => c.Enabled, true);
                var combineFilters = Builders<PedidoModel>.Filter.And(filter, filterEnabled);
                result = _pedidos.Find(combineFilters).FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                var mensagem = ex.Message;
                throw;
            }
        }

        public void CriaPedido(PedidoModel pedido)
        {
            try
            {
                pedido.PedidoId = ObjectId.GenerateNewId();
                pedido.Enabled = true;
                pedido.Status = "Criado";
                _pedidos.InsertOne(pedido);
            }
            catch (Exception ex)
            {
                var mensagem = ex.Message;
                throw;
            }
        }

        public void AlteraPedido(PedidoModel model)
        {
            try
            {
                var filter = Builders<PedidoModel>.Filter.Eq(c => c.Numero_Cliente, model.Numero_Cliente);
                var update = Builders<PedidoModel>.Update.Set(c => c.Sabor_Pizza, model.Sabor_Pizza).Set(c => c.Tamanho_Pizza, model.Tamanho_Pizza).Set(c => c.Quantidade_Pizza, model.Quantidade_Pizza).Set(c => c.Tamanho_Pizza, model.Tamanho_Pizza).Set(c => c.Bebida, model.Bebida).Set(c => c.Quantidade_Bebida, model.Quantidade_Bebida).Set(c => c.Forma_Pagamento, model.Forma_Pagamento).Set(c => c.Status, model.Status);
                _pedidos.UpdateOne(filter, update);
            }
            catch (Exception ex)
            {
                var mensagem = ex.Message;
                throw;
            }
        }

        public void DeletaPedido(string documento)
        {
            try
            {
                var filter = Builders<PedidoModel>.Filter.Eq(c => c.Numero_Cliente, documento);
                var res = _pedidos.DeleteOne(filter);
            }
            catch (Exception ex)
            {
                var mensagem = ex.Message;
                throw;
            }
        }
    }
}
