using Application.Interfaces;
using Domain;
using Domain.Interfaces;

namespace Application;

public class AccountService : IAccountService
{

    private IAccountRepository _accountRepository;

    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public Account GetOneAccount(int id)
    {
        return _accountRepository.GetOneAccount(id);
    }

    public List<Account> GetAllAccounts()
    {
        return _accountRepository.GetAllAccounts();
    }

    public Account DeleteAccount(int id)
    {
        return _accountRepository.DeleteAccount(id);
    }

    public Account EditAccount(Account account, int id)
    {
        return _accountRepository.EditAccount(account, id);
    }

    public Account AddAccount(Account account)
    {
        return _accountRepository.AddAccount(account);
    }
}