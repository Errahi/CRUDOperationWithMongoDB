using System.ComponentModel.DataAnnotations;

namespace CRUDOperationWithMongoDB.Models
{
	public class UpdateRecordByIdResponse
	{
		public bool IsSuccess {  get; set; }
		public string Message {  get; set; }
	}
}
