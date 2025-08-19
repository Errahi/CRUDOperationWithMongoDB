using System.ComponentModel.DataAnnotations;

namespace CRUDOperationWithMongoDB.Models
{
	public class DeleteRecordByIdRequest
	{
		[Required]
		public string? Id { get; set; }
	}
	public class DeleteRecordByIdResponse
	{
		public bool IsSuccess {  get; set; }
		public string ?Message { get; set; }
	}

	public class DeleteAllRecordsResponse
	{
		public bool IsSuccess { get; set; }
		public string? Message { get; set; }
	}
}
