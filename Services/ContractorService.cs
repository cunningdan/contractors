using System.Collections.Generic;
using contractors.Models;
using contractors.Repositories;

namespace contractors.Services
{
    public class ContractorService
    {
        private readonly ContractorRepository _repo;

        public ContractorService(ContractorRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Contractor> GetAll()
        {
            return _repo.GetAll();
        }
        public Contractor Create(Contractor newContractor)
        {
            newContractor.Id = _repo.Create(newContractor);
            return newContractor;
        }
    }
}