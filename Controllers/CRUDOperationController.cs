using CRUDOperationWithMongoDB.DataAccessLayer;
using CRUDOperationWithMongoDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDOperationWithMongoDB.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class CRUDOperationController : ControllerBase
	{
		private readonly ICRUDOperationDL _crudOperationDL;

		public CRUDOperationController(ICRUDOperationDL cRUDOperationDL)
		{
			_crudOperationDL = cRUDOperationDL;
		}

		[HttpPost]
		public async Task<IActionResult> InsertRecord(InsertRecordRequest insertRecordRequest)
		{
			InsertRecordResponse insertRecordResponse = new InsertRecordResponse();
			try
			{
				insertRecordResponse = await _crudOperationDL.InsertRecord(insertRecordRequest);
			}
			catch (Exception ex)
			{
				insertRecordResponse.IsSuccess = false;
				insertRecordResponse.Message = "Exception occurs" + ex.Message;
			}

			return Ok(insertRecordResponse);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllRecords()
		{
			GetAllRecordsResponse getRecordResponse = new GetAllRecordsResponse();
			try
			{
				getRecordResponse = await _crudOperationDL.GetAllRecords();
			}
			catch (Exception ex)
			{
				getRecordResponse.IsSuccess = false;
				getRecordResponse.Message = "Exception occurs" + ex.Message;
			}

			return Ok(getRecordResponse);
		}


		[HttpGet]
		public async Task<IActionResult> GetRecordById([FromQuery] string id)
		{
			GetRecordByIdResponse getByIdRecordResponse = new GetRecordByIdResponse();
			try
			{
				getByIdRecordResponse = await _crudOperationDL.GetRecordById(id);
			}
			catch (Exception ex)
			{
				getByIdRecordResponse.IsSuccess = false;
				getByIdRecordResponse.Message = "Exception occurs" + ex.Message;
			}

			return Ok(getByIdRecordResponse);
		}

		[HttpGet]
		public async Task<IActionResult> GetRecordByName([FromQuery] string Name)
		{
			GetRecordByNameResponse getByNameRecordResponse = new GetRecordByNameResponse();
			try
			{
				getByNameRecordResponse = await _crudOperationDL.GetRecordByName(Name);
			}
			catch (Exception ex)
			{
				getByNameRecordResponse.IsSuccess = false;
				getByNameRecordResponse.Message = "Exception occurs" + ex.Message;
			}

			return Ok(getByNameRecordResponse);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateRecordById(InsertRecordRequest request)
		{
			UpdateRecordByIdResponse updateByIdRecordResponse = new UpdateRecordByIdResponse();
			try
			{
				updateByIdRecordResponse = await _crudOperationDL.UpdateRecordById(request);
			}
			catch (Exception ex)
			{
				updateByIdRecordResponse.IsSuccess = false;
				updateByIdRecordResponse.Message = "Exception occurs" + ex.Message;
			}

			return Ok(updateByIdRecordResponse);
		}

		[HttpPatch]
		public async Task<IActionResult> UpdateAgeById(UpdateAgeByIdRequest request)
		{
			UpdateAgeByIdResponse updateAgeByIdRecordResponse = new UpdateAgeByIdResponse();
			try
			{
				updateAgeByIdRecordResponse = await _crudOperationDL.UpdateAgeById(request);
			}
			catch (Exception ex)
			{
				updateAgeByIdRecordResponse.IsSuccess = false;
				updateAgeByIdRecordResponse.Message = "Exception occurs" + ex.Message;
			}

			return Ok(updateAgeByIdRecordResponse);
		}
	}
}
