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
	public class DocumentRepository
	{
		private readonly DatabaseContext _dbContext;

		public DocumentRepository(DatabaseContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IActionResult> SaveDocument(DocumentDto model)
		{
			using (var connection = _dbContext.CreateConnection())
			{
				var parameter = SetLogin(model);
				try
				{
					var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
					await sqlConnection.OpenAsync();

					var queryResult = await connection.QueryMultipleAsync("proc_DocVerify", parameter, commandType: CommandType.StoredProcedure);

					// Retrieve the outcome parameters
					var outcome = queryResult.ReadSingleOrDefault<Outcome>();
					var outcomeId = outcome?.OutcomeId ?? 0;
					var outcomeDetail = outcome?.OutcomeDetail ?? string.Empty;
					var Model = queryResult.ReadSingleOrDefault<Object>();
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

			//return true; 
		}

		public async Task<IActionResult> Document(DocumentDto model)
		{
			using (var connection = _dbContext.CreateConnection())
			{
				var parameter = SetLogin(model);
				try
				{
					var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
					await sqlConnection.OpenAsync();
					var queryResult = await connection.QueryMultipleAsync("proc_DocVerify", parameter, commandType: CommandType.StoredProcedure);
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
		public DynamicParameters SetLogin(DocumentDto user)	
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@OperationType", user.BaseModel.OperationType, DbType.String);
			parameters.Add("@UserId", user.UserId, DbType.String);
			parameters.Add("@CandidateId", user.CandidateId, DbType.String);
			if (user.DataTable != null && user.DataTable.Rows.Count > 0)
			{
				parameters.Add("@DocumentStatus", user.DataTable.AsTableValuedParameter("[dbo].[tbl_DocVerify]"));
			}
			parameters.Add("@Status", user.Status, DbType.String);
			parameters.Add("@Stage", user.Stage, DbType.String);
			parameters.Add("@OutcomeId", dbType: DbType.Int32, direction: ParameterDirection.Output);
			parameters.Add("@OutcomeDetail", dbType: DbType.String, size: 4000, direction: ParameterDirection.Output);
			return parameters;

		}
	}
}
