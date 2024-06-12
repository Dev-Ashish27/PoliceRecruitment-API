using Dapper;
using Microsoft.AspNetCore.Mvc;
using PoliceRecruitmentAPI.Core.ModelDtos;
using PoliceRecruitmentAPI.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliceRecruitmentAPI.Core.Repository
{
	public class ShotPutRepository
	{
		private readonly DatabaseContext _dbContext;

		public ShotPutRepository(DatabaseContext dbContext)
		{
			_dbContext = dbContext;
		}

	

		public async Task<IActionResult> ShotPut(ShotPutDto model)
		{
			using (var connection = _dbContext.CreateConnection())
			{

				var parameter = Setmeasurement(model);
				try
				{
					var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
					await sqlConnection.OpenAsync();
					var queryResult = await connection.QueryMultipleAsync("proc_ShotPut", parameter, commandType: CommandType.StoredProcedure);
					var Model = queryResult.Read<Object>().ToList();
					var outcome = queryResult.ReadSingleOrDefault<Outcome>();
					var outcomeId = outcome?.OutcomeId ?? 0;
					var outcomeDetail = outcome?.OutcomeDetail ?? string.Empty;
					var result = new Result
					{
						Outcome = outcome,
						Data = Model

					};

					if (outcomeId == 1)
					{
						return new ObjectResult(result)
						{
							StatusCode = 200
						};
					}
					else if (outcomeId == 2)
					{
						return new ObjectResult(result)
						{
							StatusCode = 409
						};
					}
					else
					{
						return new ObjectResult(result)
						{
							StatusCode = 400
						};
					}
				}
				catch (Exception)
				{
					throw;
				}
			}
		}
		public async Task<IActionResult> Get(ShotPutDto model)
		{
			using (var connection = _dbContext.CreateConnection())
			{

				var parameter = Setmeasurement(model);
				try
				{
					var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
					await sqlConnection.OpenAsync();


					var queryResult = await connection.QueryMultipleAsync("proc_ShotPut", parameter, commandType: CommandType.StoredProcedure);
					var Model = queryResult.ReadSingleOrDefault<Object>();
					var outcome = queryResult.ReadSingleOrDefault<Outcome>();
					var outcomeId = outcome?.OutcomeId ?? 0;
					var outcomeDetail = outcome?.OutcomeDetail ?? string.Empty;
					var result = new Result
					{
						Outcome = outcome,
						Data = Model

					};

					if (outcomeId == 1)
					{
						return new ObjectResult(result)
						{
							StatusCode = 200
						};
					}
					else
					{
						return new ObjectResult(result)
						{
							StatusCode = 400
						};
					}
				}
				catch (Exception)
				{
					throw;
				}
			}
		}

		public DynamicParameters Setmeasurement(ShotPutDto user)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@OperationType", user.BaseModel.OperationType, DbType.String);

			parameters.Add("@UserId", user.UserId, DbType.String);
			parameters.Add("@Id", user.Id, DbType.Guid);
			parameters.Add("@chestNo", user.chestNo, DbType.String);
			parameters.Add("@startTime", user.startTime, DbType.String);
			parameters.Add("@endTime", user.endTime, DbType.String);
			parameters.Add("@groupNo", user.groupNo, DbType.String);
			parameters.Add("@duration", user.duration, DbType.String);
			parameters.Add("@signature", user.signature, DbType.String);
			parameters.Add("@createdBy", user.createdBy, DbType.String);
			parameters.Add("@createdDate", user.createdDate, DbType.DateTime);
			
			parameters.Add("@isActive", user.isActive, DbType.String);
			parameters.Add("@OutcomeId", dbType: DbType.Int32, direction: ParameterDirection.Output);
			parameters.Add("@OutcomeDetail", dbType: DbType.String, size: 4000, direction: ParameterDirection.Output);
			return parameters;

		}
	}
}
