using System;
using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoliceRecruitmentAPI.Core.ModelDtos;
using PoliceRecruitmentAPI.DataAccess.Context;

namespace PoliceRecruitmentAPI.Core.Repository
{
    public class AuthRepository
    {
        private readonly DatabaseContext _dbContext;

        public AuthRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> VerifyUser(LoginDto model)
        {
			using (var connection = _dbContext.CreateConnection())
			{
				var parameter = SetLogin(model);
				try
				{
					var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
					await sqlConnection.OpenAsync();

					var queryResult = await connection.QueryMultipleAsync("Proc_LoginDetails", parameter, commandType: CommandType.StoredProcedure);

					// Retrieve the outcome parameters
					var outcome = queryResult.ReadSingleOrDefault<Outcome>();
					var outcomeId = outcome?.OutcomeId ?? 0;
					var outcomeDetail = outcome?.OutcomeDetail ?? string.Empty;
					var Model = queryResult.ReadSingleOrDefault<Object>();
					//var Model = queryResult.Read<Login>().ToList();


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
		public DynamicParameters SetLogin(LoginDto user)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@OperationType", user.BaseModel.OperationType, DbType.String);
			parameters.Add("@Email", user.Email, DbType.String);
			parameters.Add("@Password", user.Password, DbType.String);
			parameters.Add("@OutcomeId", dbType: DbType.Int32, direction: ParameterDirection.Output);
			parameters.Add("@OutcomeDetail", dbType: DbType.String, size: 4000, direction: ParameterDirection.Output);
			return parameters;

		}

	}
}
