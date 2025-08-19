using CRUDOperationWithMongoDB.Models;

namespace CRUDOperationWithMongoDB.DataAccessLayer
{
	public interface ICRUDOperationDL
	{
		public Task<InsertRecordResponse> InsertRecord(InsertRecordRequest request);
		public Task<GetAllRecordsResponse> GetAllRecords();
		public Task<GetRecordByIdResponse> GetRecordById(string ID);
		public Task<GetRecordByNameResponse> GetRecordByName(string Name);
		public Task<UpdateRecordByIdResponse> UpdateRecordById(InsertRecordRequest request);
		public Task<UpdateAgeByIdResponse> UpdateAgeById(UpdateAgeByIdRequest request);
	}
}
