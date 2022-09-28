namespace Domain;

public class Account
{
    
    public int Id { get; set; }
    public Person Person { get; set; }
    public int OwnerId { get; set; }
    public string Balance { set; get; } 
}