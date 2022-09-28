using Application.DTOs;

namespace Domain.Interfaces;

public interface IPersonService
{
        List<Person> GetAllPerson();
        Person DeletePerson(int personId);
        Person AddPerson(PostPersonDTO dto);
        Person EditPerson(Person person, int id);
        Person GetOnePerson(int id);

        void CreateDb();
}