using CRUDOperationWithMongoDB.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CRUDOperationWithMongoDB.DataAccessLayer
{
	public class CRUDOperationDL : ICRUDOperationDL
	{
		private readonly IConfiguration _configuration;
		private readonly MongoClient _mongoClient;
		private readonly IMongoCollection<InsertRecordRequest> _mongoCollection;
		public CRUDOperationDL(IConfiguration configuration)
		{
			_configuration = configuration;
			_mongoClient = new MongoClient(_configuration[key: "DatabaseSettings:ConnectionString"]);
			var _mongoDatabase = _mongoClient.GetDatabase(_configuration[key: "DatabaseSettings:DatabaseName"]);
			_mongoCollection = _mongoDatabase.GetCollection<InsertRecordRequest>(_configuration[key: "DatabaseSettings:CollectionName"]);
		}

		public async Task<GetAllRecordsResponse> GetAllRecords()
		{
			GetAllRecordsResponse response = new GetAllRecordsResponse();
			response.IsSuccess = true;
			response.Message = "Data Fetched Successfully!";
			try
			{
				response.data = new List<InsertRecordRequest>();
				response.data = await _mongoCollection.Find(x=>true).ToListAsync();
				if(response.data.Count==0)
				{
					response.Message = "No record found";
				}
			}
			catch(Exception ex)
			{
				response.IsSuccess = false;
				response.Message = "Exception occurs: " + ex.Message;
			}
			return response;
		}

		public async Task<GetRecordByIdResponse> GetRecordById(string ID)
		{
			GetRecordByIdResponse response= new GetRecordByIdResponse();
			response.IsSuccess = true;
			response.Message = "Fetch Data Successfullly!";
			try
			{
				response.data=await _mongoCollection.Find(x=>x.Id==ID).FirstOrDefaultAsync();
				if (response.data == null)
				{
					response.Message = "Invalid Id";
				}
			}
			catch (Exception ex)
			{
				response.IsSuccess= false;
				response.Message="Exception occurs: " + ex.Message;
			}
			return response;
		}

		public async Task<GetRecordByNameResponse> GetRecordByName(string Name)
		{
			GetRecordByNameResponse response= new GetRecordByNameResponse();
			response.IsSuccess = true;
			response.Message = "Fetch Data Successfully by Name!";
			try
			{
				response.data = new List<InsertRecordRequest>();
				response.data = await _mongoCollection.Find(x=>x.FirstName==Name || x.LastName==Name).ToListAsync();
				if(response.data == null)
				{
					response.Message = "No record found by this Name";
				}
			}
			catch(Exception ex)
			{
				response.IsSuccess=!false;
				response.Message = "Exception occurs: " + ex.Message;
			}
			return response;
		}

		public async Task<InsertRecordResponse> InsertRecord(InsertRecordRequest request)
		{
			InsertRecordResponse response = new InsertRecordResponse();
			response.IsSuccess = true;
			response.Message = "Data saved Successfully!";
			try
			{
				request.CreateDate = DateTime.Now.ToString();
				request.UpdateDate = string.Empty;

				await _mongoCollection.InsertOneAsync(request);
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.Message = "Exception occurs: " + ex.Message;
			}

			return response;
		}

		public async Task<UpdateAgeByIdResponse> UpdateAgeById(UpdateAgeByIdRequest request)
		{
			UpdateAgeByIdResponse response = new UpdateAgeByIdResponse();
			response.IsSuccess = true;
			response.Message = "Record Updated Successfully!";
			try
			{
				var filter = new BsonDocument().Add("Age",request.Age).Add("UpdateDate",DateTime.Now.ToString());

				var updatedData=new BsonDocument("$set", filter);
				var result = await _mongoCollection.UpdateOneAsync(x => x.Id == request.Id, updatedData);
				if (!result.IsAcknowledged)
				{
					response.IsSuccess = false;
					response.Message = "No record found against this id";
				}
			}
			catch
			{

				response.IsSuccess = false;
				response.Message = "Exception occurs: " + response.Message;
			}
			return response;
		}

		public async Task<UpdateRecordByIdResponse> UpdateRecordById(InsertRecordRequest request)
		{
			UpdateRecordByIdResponse response = new UpdateRecordByIdResponse();
			response.IsSuccess = true;
			response.Message = "Record Updated Successfully!";
			try
			{
				GetRecordByIdResponse response1=await GetRecordById(request.Id);
				request.CreateDate= response1.data.CreateDate;
				request.UpdateDate= DateTime.Now.ToString();

			var result=	await _mongoCollection.ReplaceOneAsync(x => x.Id == request.Id, request);
				if(!result.IsAcknowledged)
				{
					response.IsSuccess = false;
					response.Message = "No record found against this id";
				}
			}
			catch
			{

				response.IsSuccess = false;
				response.Message="Exception occurs: " + response.Message;
			}
			return response;
		}
	}
}
