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
	public class RunningRepository
	{
		private readonly DatabaseContext _dbContext;

		public RunningRepository(DatabaseContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<IActionResult> Running(RunningDto model)
		{
			using (var connection = _dbContext.CreateConnection())
			{
				var parameter = SetCandidate(model);
				try
				{
					var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
					await sqlConnection.OpenAsync();
					var queryResult = await connection.QueryMultipleAsync("Proc_100mRunning", parameter, commandType: CommandType.StoredProcedure);
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
						return new ObjectResult(result) { StatusCode = 200 };
					}
					else
					{
						return new ObjectResult(result) { StatusCode = 400 };
					}
				}
				catch (Exception)
				{
					throw;
				}
			}
		}
		public async Task<IActionResult> Get(RunningDto model)
		{
			using (var connection = _dbContext.CreateConnection())
			{
				var parameter = SetCandidate(model);
				try
				{
					var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
					await sqlConnection.OpenAsync();
					var queryResult = await connection.QueryMultipleAsync("Proc_100mRunning", parameter, commandType: CommandType.StoredProcedure);
					var Model = queryResult.Read<Object>();
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
						return new ObjectResult(result) { StatusCode = 200 };
					}
					else
					{
						return new ObjectResult(result) { StatusCode = 400 };
					}
				}
				catch (Exception)
				{
					throw;
				}
			}
		}
		public async Task<IActionResult> Running800(RunningDto model)
		{
			using (var connection = _dbContext.CreateConnection())
			{
				var parameter = SetCandidate(model);
				try
				{
					var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
					await sqlConnection.OpenAsync();
					var queryResult = await connection.QueryMultipleAsync("Proc_800mRunning", parameter, commandType: CommandType.StoredProcedure);
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
						return new ObjectResult(result) { StatusCode = 200 };
					}
					else
					{
						return new ObjectResult(result) { StatusCode = 400 };
					}
				}
				catch (Exception)
				{
					throw;
				}
			}
		}
		public async Task<IActionResult> Get800(RunningDto model)
		{
			using (var connection = _dbContext.CreateConnection())
			{
				var parameter = SetCandidate(model);
				try
				{
					var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
					await sqlConnection.OpenAsync();
					var queryResult = await connection.QueryMultipleAsync("Proc_800mRunning", parameter, commandType: CommandType.StoredProcedure);
					var Model = queryResult.Read<Object>();
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
						return new ObjectResult(result) { StatusCode = 200 };
					}
					else
					{
						return new ObjectResult(result) { StatusCode = 400 };
					}
				}
				catch (Exception)
				{
					throw;
				}
			}
		}
		public async Task<IActionResult> Running1600(RunningDto model)
		{
			using (var connection = _dbContext.CreateConnection())
			{
				var parameter = SetCandidate(model);
				try
				{
					var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
					await sqlConnection.OpenAsync();
					var queryResult = await connection.QueryMultipleAsync("Proc_1600mRunning", parameter, commandType: CommandType.StoredProcedure);
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
						return new ObjectResult(result) { StatusCode = 200 };
					}
					else
					{
						return new ObjectResult(result) { StatusCode = 400 };
					}
				}
				catch (Exception)
				{
					throw;
				}
			}
		}
		public async Task<IActionResult> Get1600(RunningDto model)
		{
			using (var connection = _dbContext.CreateConnection())
			{
				var parameter = SetCandidate(model);
				try
				{
					var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
					await sqlConnection.OpenAsync();
					var queryResult = await connection.QueryMultipleAsync("Proc_1600mRunning", parameter, commandType: CommandType.StoredProcedure);
					var Model = queryResult.Read<Object>();
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
						return new ObjectResult(result) { StatusCode = 200 };
					}
					else
					{
						return new ObjectResult(result) { StatusCode = 400 };
					}
				}
				catch (Exception)
				{
					throw;
				}
			}
		}
		public DynamicParameters SetCandidate(RunningDto user)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@OperationType", user.BaseModel.OperationType, DbType.String);
			parameters.Add("@Id", user.Id, DbType.String);
			parameters.Add("@UserId", user.UserId, DbType.String);
			parameters.Add("@CandidateID", user.CandidateID, DbType.Int64);
			parameters.Add("@ChestNo", user.ChestNo, DbType.String);
			parameters.Add("@Date", user.Date, DbType.DateTime);
			parameters.Add("@StartTime", user.StartTime, DbType.Time);
			parameters.Add("@EndTime", user.EndTime, DbType.Time);
			parameters.Add("@Group", user.Group, DbType.String);
			parameters.Add("@Duration", user.Duration, DbType.String);
			parameters.Add("@NoOfAttemt", user.NoOfAttemt, DbType.String);
			parameters.Add("@Signature", user.Signature, DbType.String);
			if (user.DataTable != null && user.DataTable.Rows.Count > 0)
			{
				parameters.Add("@Runningvalue", user.DataTable.AsTableValuedParameter("[dbo].[tbl_Running]"));
			}
			parameters.Add("@Score", user.Score, DbType.String);
			parameters.Add("@OutcomeId", dbType: DbType.Int32, direction: ParameterDirection.Output);
			parameters.Add("@OutcomeDetail", dbType: DbType.String, size: 4000, direction: ParameterDirection.Output);
			return parameters;

		}
	}
}
