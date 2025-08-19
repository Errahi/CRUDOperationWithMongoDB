using System.ComponentModel.DataAnnotations;

namespace CRUDOperationWithMongoDB.Models
{
	public class UpdateAgeByIdRequest
	{
		[Required]
		public string? Id { get; set; }
		[Required]
		public int Age { get; set; }
	}

	public class UpdateAgeByIdResponse
	{
		public bool IsSuccess { get; set; }
		public string? Message { get; set; }
	}

}
