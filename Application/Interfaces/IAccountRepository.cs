using Domain;

namespace Application.Interfaces;

public interface IAccountRepository
{
    Account GetOneAccount(int id);
    List<Account> GetAllAccounts();
    Account DeleteAccount(int id);
    Account EditAccount(Account account,int id);

    Account AddAccount(Account account);
}