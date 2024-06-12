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
    public class ScanningdocRepository
    {
        private readonly DatabaseContext _dbContext;

        public ScanningdocRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Scanningdoc(ScanningdocDto model)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameter = SetCandidate(model);
                try
                {
                    var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
                    await sqlConnection.OpenAsync();
                    var queryResult = await connection.QueryMultipleAsync("Proc_ScanDoc", parameter, commandType: CommandType.StoredProcedure);
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
        public DynamicParameters SetCandidate(ScanningdocDto user)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@OperationType", user.BaseModel.OperationType, DbType.String);
            parameters.Add("@UserId", user.UserId, DbType.String);
            parameters.Add("@CandidateID", user.CandidateID, DbType.Int64);
            parameters.Add("@thumbstring", user.Thumbstring, DbType.String);
            parameters.Add("@ChestNo", user.ChestNo, DbType.String);
            parameters.Add("@Date", user.Date, DbType.DateTime);
            parameters.Add("@imagestring", user.Imagestring, DbType.String);
            parameters.Add("@OutcomeId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@OutcomeDetail", dbType: DbType.String, size: 4000, direction: ParameterDirection.Output);
            return parameters;

        }

    }
}
