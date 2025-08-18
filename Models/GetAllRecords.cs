namespace CRUDOperationWithMongoDB.Models
{
	public class GetAllRecordsResponse	
	{
		public bool IsSuccess { get; set; }
		public string? Message { get; set; }
		public List<InsertRecordRequest> ?data { get; set; }
	}
}
