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
	public class heiCheMeasurementRepositry
	{
		private readonly DatabaseContext _dbContext;

		public heiCheMeasurementRepositry(DatabaseContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IActionResult> savemeasurement(heiCheMeasurement model)
		{
			using (var connection = _dbContext.CreateConnection())
			{
				var parameter = Setmeasurement(model);
				try
				{
					var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
					await sqlConnection.OpenAsync();

					var queryResult = await connection.QueryMultipleAsync("proc_heiCheMeasurement", parameter, commandType: CommandType.StoredProcedure);

					

					var Model = queryResult.ReadSingleOrDefault<Object>();
					var outcome = queryResult.ReadSingleOrDefault<Outcome>();
					var outcomeId = outcome?.OutcomeId ?? 0;
					var outcomeDetail = outcome?.OutcomeDetail ?? string.Empty;
					if (outcomeId == 1)
					{
						var result = new Result
						{

							Outcome = outcome,
							Data = Model
						};
						// Login successful
						return new ObjectResult(result)
						{
							StatusCode = 200
						};
					}
					else
					{
						var result = new Result
						{

							Outcome = outcome,

						};
						// Login failed
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

			//return true; 
		}


	

		public DynamicParameters Setmeasurement(heiCheMeasurement user)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@OperationType", user.BaseModel.OperationType, DbType.String);
			parameters.Add("@candidate_id", user.candidate_id, DbType.Int64);
			parameters.Add("@hid", user.hid, DbType.Int64);
			parameters.Add("@height", user.Height, DbType.Decimal);
			parameters.Add("@UserId", user.UserId, DbType.String);
			parameters.Add("@Id", user.Id, DbType.Guid);
			parameters.Add("@chest_normal", user.Chest_normal, DbType.Decimal);
			parameters.Add("@chest_inhale", user.Chest_Inhale, DbType.Decimal);
			parameters.Add("@time", user.time, DbType.String);
			parameters.Add("@verify_by", user.Verify_by, DbType.String);
			parameters.Add("@interval", user.Interval, DbType.String);
			parameters.Add("@createdby", user.createdby, DbType.String);
			parameters.Add("@created_date", user.created_date, DbType.DateTime);
			parameters.Add("@isactive", user.isactive, DbType.String);
			parameters.Add("@OutcomeId", dbType: DbType.Int32, direction: ParameterDirection.Output);
			parameters.Add("@OutcomeDetail", dbType: DbType.String, size: 4000, direction: ParameterDirection.Output);
			return parameters;

		}

	}
}

