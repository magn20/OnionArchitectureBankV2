using Domain;

namespace Application.Interfaces;

public interface IPersonRepository
{
    
    List<Person> GetAllPerson();
    Person DeletePerson(int personId);
    Person AddPerson(Person person);
    Person EditPerson(Person person, int id);
    Person GetOnePerson(int id);
    void CreateDb();
}