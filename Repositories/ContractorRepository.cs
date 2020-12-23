using System.Collections.Generic;
using System.Data;
using contractors.Models;
using Dapper;

namespace contractors.Repositories
{
    public class ContractorRepository
    {
        private readonly IDbConnection _db;
        public ContractorRepository(IDbConnection db)
        {
            _db = db;
        }
        public IEnumerable<Contractor> GetAll()
        {
            string sql = "SELECT * FROM contractors";
            return _db.QueryFirstOrDefault(sql);
        }
        public int Create(Contractor newContractor)
        {
            string sql = @"
            INSERT INTO contractors
            (name, hourly)
            VALUES
            (@Name, @Hourly);
            SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newContractor);
        }
    }
}