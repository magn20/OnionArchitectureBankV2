using Application.DTOs;
using Domain;
using Domain.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    [ApiController]
    [Route("[Controller]")]
    public class BankController : ControllerBase
    {

        private IPersonService _personService;
        private IAccountService _accountService;
        //for parameter //, IAccountService accountService
        public BankController(IPersonService personService, IAccountService accountService)
        {
            _personService = personService;
            _accountService = accountService;
        }
    
        [HttpGet()]
        [Route("CreateDb")]
        public ActionResult GetDb()
        {
            _personService.CreateDb();
            return Ok("DB has been created");
        }
    
        [HttpGet()]
        [Route("getperson")]
        public ActionResult GetPerson()
        {
            return Ok(_personService.GetAllPerson());
        }
    
    
        [HttpPost]
        [Route("Addperson")]
        public ActionResult<Person> AddPerson(PostPersonDTO dto)
        {
            try
            {
                var result = _personService.AddPerson(dto);
                return Created("bank/Addperson/" + result.Id, result);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }
    
        [HttpDelete]
        [Route("removeperson/{id}")]
        public ActionResult RemovePerson([FromRoute] int id)
        {
            try
            {
                return Ok(_personService.DeletePerson(id));
            }
            catch (KeyNotFoundException e)
            {
                return NotFound("No person was found" + id);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.ToString());
            }
            
        }
    
        [HttpPut]
        [Route("editperson/{id}")]
        public ActionResult EditPerson([FromBody]Person person,[FromRoute] int id)
        {

            try
            {
                return Ok(_personService.EditPerson(person, id));

            }
            catch (KeyNotFoundException e)
            {
                return NotFound("No person was found" + id);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.ToString());
            }
            
            
            
        }
    
        //Accounts
        [HttpPost]
        [Route("AddAccount")]
        public ActionResult AddAccount(Account account)
        {
            return Ok(_accountService.AddAccount(account));

        }
        

    }
