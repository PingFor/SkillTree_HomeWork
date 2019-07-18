using System.Collections.Generic;
using HomeWork_1.Models;
using HomeWork_1.Repository;
using System.Linq;

namespace HomeWork_1.Service
{
    public class AccountBookService
    {
        private readonly IRepository<AccountBook> _accountBookRepository;
        public AccountBookService(IUnitOfWork UnitOfWork)
        {
            _accountBookRepository = new Repository<AccountBook>(UnitOfWork);
        }

        public IEnumerable<Accounting> Lookup()
        {
            IQueryable<AccountBook> source = _accountBookRepository.LookupAll();
            IEnumerable<Accounting> result = source.OrderBy(d => d.Dateee).Select(d => new Accounting()
            {
                Type = d.Categoryyy,
                Date = d.Dateee,
                Amount = d.Amounttt
            }).ToList();
            return result;
        }       
    }
}