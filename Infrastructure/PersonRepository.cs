using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public class PersonRepository : IPersonRepository
{
    
    private readonly RepositoryDbContext _context;

    public PersonRepository(RepositoryDbContext context)
    {

        _context = context;
    }

    
    public void CreateDb()
    {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

        
    }
    
    public List<Person> GetAllPerson()
    {
        return _context.PersonTable.ToList();
        
    }

    public Person DeletePerson(int personId)
    {
        var movie = _context.PersonTable.Find(personId);
            _context.PersonTable.Remove(movie ?? throw new InvalidOperationException());
            _context.SaveChanges();
            return movie;
        
    }

    public Person AddPerson(Person person)
    {
        _context.PersonTable.Add(person ?? throw new InvalidOperationException());
            _context.SaveChanges();
            return person;
    }

    public Person EditPerson(Person person, int id)
    {
        var oldperson = GetOnePerson(id);
            if (oldperson.Id.Equals(person.Id))
            {
                oldperson.Accounts = person.Accounts;
                oldperson.Adr = person.Adr;
                oldperson.FName = person.FName;
                oldperson.LName = person.LName;
            }
            _context.PersonTable.Update(oldperson ?? throw new InvalidOperationException());     
            _context.SaveChanges();                                                        
            return person;                                                                
         
    }

    public Person GetOnePerson(int id)
    {
        
            var person = _context.PersonTable.FirstOrDefault(p => p.Id == id);
            return person;
    }
}