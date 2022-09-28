using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderAPI.Entities
{
    [Serializable,BsonIgnoreExtraElements]
    public class Order
    {
        [BsonId,BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("customer_id"), BsonRepresentation(BsonType.Int32)]
        public int IdCustomer { get; set; }

        [BsonElement("ordered_on"), BsonRepresentation(BsonType.DateTime)]
        public DateTime OrderedOn { get; set; } = DateTime.Now;

        [BsonElement("order_details")]
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
