namespace Domain.Interfaces;

public interface IAccountService
{
    Account GetOneAccount(int id);
    List<Account> GetAllAccounts();
    Account DeleteAccount(int id);
    Account EditAccount(Account account,int id);
    Account AddAccount(Account account);
}