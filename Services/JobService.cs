using System.Collections.Generic;
using contractors.Repositories;
using contractors.Models;
using System;

namespace contractors.Services
{
    public class JobService
    {
        private readonly JobRepository _repo;
        public JobService(JobRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Job> GetAll()
        {
            return _repo.GetAll();
        }

        public Job Create(Job newJob)
        {
            newJob.Id = _repo.Create(newJob);
            return newJob;
        }

        public string Delete(int id)
        {
            if (_repo.Delete(id))
            {
                return "Has been deleted";
            }
            return "no delete";
        }
    }
}