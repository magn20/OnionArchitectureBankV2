using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public class AccountRepository : IAccountRepository
{
    private readonly RepositoryDbContext _context;

    public AccountRepository(RepositoryDbContext context)
    {

        _context = context;
    }

    public Account GetOneAccount(int id)
    {
            var account = _context.AccountTable.FirstOrDefault(p => p.Id == id);
            return account;
    }

    public List<Account> GetAllAccounts()
    {
            return _context.AccountTable.ToList();
    }

    public Account DeleteAccount(int id)
    {
        var review = _context.AccountTable.Find(id);
            _context.AccountTable.Remove(review ?? throw new InvalidOperationException());
            _context.SaveChanges();
            return review;
    }

    public Account EditAccount(Account account, int id)
    {
        
        
            var oltaccount = GetOneAccount(id);
            if (oltaccount.Id.Equals(account.Id))
            {
                oltaccount.Person = account.Person;
                oltaccount.Balance = account.Balance;
                oltaccount.OwnerId = account.OwnerId;
            }
            _context.AccountTable.Update(oltaccount ?? throw new InvalidOperationException());     
            _context.SaveChanges();                                                        
            return account;                                                                
          
    }

    public Account AddAccount(Account account)
    {
        _context.AccountTable.Add(account ?? throw new InvalidOperationException());
            _context.SaveChanges();
            return account;
        
    }
}