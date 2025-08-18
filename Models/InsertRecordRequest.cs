using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CRUDOperationWithMongoDB.Models
{
	public class InsertRecordRequest
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string? Id { get; set; }

		public string? CreateDate { get; set; }

		public string? UpdateDate { get; set; }
		[Required]
		[BsonElement(elementName:"Name")]
		public string? FirstName {  get; set; }
		[Required]
		public string? LastName { get; set; }
		[Required]
		public int Age {  get; set; }

		[Required]
		public string? Contact { get; set; }
	}

	public class InsertRecordResponse
	{
		public bool IsSuccess {  get; set; }
		public string ?Message {  get; set; }
	}
}
