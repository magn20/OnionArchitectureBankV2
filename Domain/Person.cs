namespace Domain;

public class Person
{
    public int Id { set; get; }
    
    public string FName { set; get; }
    
    public string LName { set; get; }
    
    public string Adr { set; get; }
    
    public ICollection<Account>? Accounts { set; get; }
}