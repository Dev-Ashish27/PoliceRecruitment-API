using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoliceRecruitmentAPI.Core.ModelDtos;
using PoliceRecruitmentAPI.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PoliceRecruitmentAPI.Core.Repository
{
	public class CandidateRepository
	{
		private readonly DatabaseContext _dbContext;

		public CandidateRepository(DatabaseContext dbContext)
		{
			_dbContext = dbContext;
		}

	

		public async Task<IActionResult> Candidate(CandidateDto model)
		{
			using (var connection = _dbContext.CreateConnection())
			{
				
				var parameter = SetCandidate(model);
				try
				{
					var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
					await sqlConnection.OpenAsync();
					var queryResult = await connection.QueryMultipleAsync("Proc_Candidate", parameter, commandType: CommandType.StoredProcedure);
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

		public async Task<IActionResult> Get(CandidateDto model)
		{
			using (var connection = _dbContext.CreateConnection())
			{
				
				var parameter = SetCandidate(model);
				try
				{
					var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
					await sqlConnection.OpenAsync();
				

					var queryResult = await connection.QueryMultipleAsync("Proc_Candidate", parameter, commandType: CommandType.StoredProcedure);
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
		public DynamicParameters SetCandidate(CandidateDto user)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@OperationType", user.BaseModel.OperationType, DbType.String);
            parameters.Add("@CandidateID", user.CandidateID, DbType.Int64);
			parameters.Add("@RecruitmentYear", user.RecruitmentYear, DbType.String);
			parameters.Add("@OfficeName", user.OfficeName, DbType.String);
			parameters.Add("@PostName", user.PostName, DbType.String);
			parameters.Add("@ApplicationNo", user.ApplicationNo, DbType.Int64);
			parameters.Add("@ExaminationFee", user.ExaminationFee, DbType.String);
			parameters.Add("@FullNameDevnagari", user.FullNameDevnagari, DbType.String);
			parameters.Add("@FullNameEnglish", user.FullNameEnglish, DbType.String);
			parameters.Add("@DocumentUploaded", user.DocumentUploaded, DbType.Boolean);
			parameters.Add("@MothersName", user.MothersName, DbType.String);
			parameters.Add("@Gender", user.Gender, DbType.String);
			parameters.Add("@MaritalStatus", user.MaritalStatus, DbType.String);
			parameters.Add("@PassCertificationNo", user.PassCertificationNo, DbType.Int64);
			parameters.Add("@DOB", user.DOB, DbType.Date);
			parameters.Add("@Age", user.Age, DbType.String);
			parameters.Add("@Address", user.Address, DbType.String);
			parameters.Add("@PinCode", user.PinCode, DbType.Int64);
			parameters.Add("@MobileNumber", user.MobileNumber, DbType.Int64);
			parameters.Add("@EmailId", user.EmailId, DbType.String);
			parameters.Add("@PermanentAddress", user.PermanentAddress, DbType.String);
			parameters.Add("@PermanentPinCode", user.PermanentPinCode, DbType.Int64);
			parameters.Add("@Nationality", user.Nationality, DbType.String);
			parameters.Add("@Religion", user.Religion, DbType.String);
			parameters.Add("@Cast", user.Cast, DbType.String);
			parameters.Add("@SubCast", user.SubCast, DbType.String);
			parameters.Add("@Cast", user.Cast, DbType.String);
			parameters.Add("@PartTime", user.PartTime, DbType.Boolean);
			parameters.Add("@ProjectSick", user.ProjectSick, DbType.Boolean);
			parameters.Add("@ExServiceman", user.ExServiceman, DbType.Boolean);
			parameters.Add("@EarthquakeAffected", user.EarthquakeAffected, DbType.Boolean);

			parameters.Add("@OutcomeId", dbType: DbType.Int32, direction: ParameterDirection.Output);
			parameters.Add("@OutcomeDetail", dbType: DbType.String, size: 4000, direction: ParameterDirection.Output);
			return parameters;

		}
	}
}
