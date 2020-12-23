using System.Collections.Generic;
using System.Data;
using contractors.Models;
using Dapper;

namespace contractors.Repositories
{
    public class ContractorJobRepository
    {
        private readonly IDbConnection _db;
        public ContractorJobRepository(IDbConnection db)
        {
            _db = db;
        }
        public int Create(ContractorJob newCj)
        {
            string sql = @"
            INSERT INTO contractorJobs
            (contractorId, jobId, creatorId)
            VALUES
            (@ContractorId, @JobId, @CreatorId);
            SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newCj);
        }
        public IEnumerable<Contractor> GetContractorsByJob(int jobId)
        {
            string sql = @"
            SELECT C.*,
            cj.id as ContractorJobId,
            p.*
            FROM contractorjobs cj
            JOIN contractors c ON c.id = cj.contractorId
            JOIN profiles p ON p.id = cj.creatorId
            WHERE jobId = @jobId;";
            return _db.Query<ContractorJobViewModel, Profile, ContractorJobViewModel>(sql, (contractor, profile) => { contractor.Creator = profile; return contractor; }, new { jobId }, splitOn: "id");
        }
    }
}