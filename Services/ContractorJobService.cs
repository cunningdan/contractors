using System.Collections.Generic;
using contractors.Models;
using contractors.Repositories;

namespace contractors.Services
{
    public class ContractorJobService
    {
        private readonly ContractorJobRepository _repo;
        public ContractorJobService(ContractorJobRepository repo)
        {
            _repo = repo;
        }
        public ContractorJob Create(ContractorJob newCj)
        {
            newCj.Id = _repo.Create(newCj);
            return newCj;
        }
        public IEnumerable<Contractor> GetContractorsByJob(int jobId)
        {
            return _repo.GetContractorsByJob(jobId);
        }
    }
}