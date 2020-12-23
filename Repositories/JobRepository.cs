using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using contractors.Models;

namespace contractors.Repositories
{
    public class JobRepository
    {
        private readonly IDbConnection _db;
        private readonly string populateCreator = "SELECT Job.*, profile.* FROM jobs Job INNER JOIN profiles profile ON Job.creatorId = profile.id ";
        public JobRepository(IDbConnection db)
        {
            _db = db;
        }
        public IEnumerable<Job> GetAll()
        {
            string sql = "SELECT * FROM jobs;";
            return _db.Query<Job>(sql);
        }
        public int Create(Job newjob)
        {
            string sql = @"
            INSERT INTO jobs
            (title, location, budget)
            VALUES
            (@Title, @Location, @Budget);
            SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newjob);
        }
        public bool Delete(int id)
        {
            string sql = "DELETE FROM jobs WHERE id = @Id LIMIT 1";
            int affectedRows = _db.Execute(sql, new { id });
            return affectedRows > 0;
        }
    }
}