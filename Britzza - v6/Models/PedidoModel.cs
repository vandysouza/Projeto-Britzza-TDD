using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Britzza___v6.Models
{
    public class PedidoModel
    {
        [BsonElement("_id")]
        public ObjectId PedidoId { get; set; }
        public string? Numero_Cliente { get; set; }
        public string? Sabor_Pizza { get; set; }
        public string? Tamanho_Pizza { get; set; }
        public int? Quantidade_Pizza { get; set; }
        public string? Bebida { get; set; }
        public int? Quantidade_Bebida { get; set; }
        public string? Forma_Pagamento { get; set; }
        public string? Status { get; set; }
        public bool Enabled { get; set; }
    }
}
