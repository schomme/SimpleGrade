using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleGrade.Base.Model.Person;
using SimpleGradeApi.Data;
using SimpleGradeApi.Dto;

namespace SimpleGradeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        public PersonController(ILogger<PersonController> logger, AppDbContext context, IMapper mapper) : base(context, logger, mapper)
        { }

        [HttpPost]
        public ActionResult Set(PersonDto person)
        {
            if (person == null) return BadRequest();
            if (person.Id != 0) return BadRequest();

            var result = Mapper.Map<Person>(person);
            if (result is null) return ValidationProblem();

            var track = Context.Persons.Add(result);
            Context.SaveChanges();

            return Ok(track.Entity);
        }

        [HttpGet]
        [Route("{Id}")]
        public ActionResult Get(int Id)
        {
            var p = Context.Persons.FirstOrDefault(i => i.Id == Id);
            if (p is null) return NotFound();
            var result = Mapper.Map<PersonDto>(p);
            if (result is null) return ValidationProblem();
            return Ok(result);
        }

        [HttpDelete]
        [Route("{Id}")]
        public ActionResult Delete(int Id)
        {
            var p = Context.Persons.FirstOrDefault(i => i.Id == Id);
            if (p is null) return NotFound();
            Context.Persons.Remove(p);
            return Ok(p);
        }
        [HttpPatch]
        [Route("{Id}")]
        public ActionResult Modify(int Id, PersonDto person)
        {
            if (person == null) return BadRequest("null");
            if (Id <= 0) return BadRequest("Id must be greater 0");
            var p = Mapper.Map<Person>(person);
            p.Id = Id;
            var result = Context.Persons.Update(p);
            return Ok(result.Entity);
        }
    }
}
