using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Britzza___v6.Models
{
    public class ClienteModel
    {
        //[BsonElement("_id")]
        //public ObjectId ClienteId { get; set; }
        public string? Nome { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Endereco { get; set; }
        public string? Telefone { get; set; }
        public bool Enabled { get; set; }
    }
}
