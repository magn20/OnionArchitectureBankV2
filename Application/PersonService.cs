using System.ComponentModel.DataAnnotations;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain;
using Domain.Interfaces;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

namespace Application;

public class PersonService : IPersonService
{
    private IPersonRepository _personRepository;
    private IMapper _mapper;
    private IValidator<PostPersonDTO> _postValidator;


    public PersonService(IPersonRepository personRepository, IMapper mapper, IValidator<PostPersonDTO> postValidator)
    {
        _personRepository = personRepository;
        _mapper = mapper;
        _postValidator = postValidator;
    }

    public List<Person> GetAllPerson()
    {
        return _personRepository.GetAllPerson();
    }

    public Person DeletePerson(int personId)
    {
        return _personRepository.DeletePerson(personId);
    }

    public Person AddPerson(PostPersonDTO dto)
    {
        var validation = _postValidator.Validate(dto);
        if (!validation.IsValid)
        {
            //use validation-exception from fluentvalidation 
            throw new ValidationException(validation.ToString());
        }
        
        return _personRepository.AddPerson(_mapper.Map<Person>(dto));
    }

    public Person EditPerson(Person person, int id)
    {

        if (id != person.Id)
        {
            throw new ValidationException("ID in body not the same as route");
        }
        return _personRepository.EditPerson(person, id);
        
    }

    public Person GetOnePerson(int id)
    {
        return _personRepository.GetOnePerson(id);
    }

    public void CreateDb()
    {
        _personRepository.CreateDb();
    }
}