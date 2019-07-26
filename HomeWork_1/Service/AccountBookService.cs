using System.Collections.Generic;
using HomeWork_1.Models;
using HomeWork_1.Repository;
using System.Linq;
using System;

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

        public void Create(Accounting accounting)
        {
            AccountBook accountBook = new AccountBook()
            {
                Id = Guid.NewGuid(),
                Amounttt = accounting.Amount,
                Categoryyy = accounting.Type,
                Dateee = accounting.Date,
                Remarkkk = accounting.Remark
            };
            _accountBookRepository.Create(accountBook);
        }
    }
}