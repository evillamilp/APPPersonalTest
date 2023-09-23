using Microsoft.AspNetCore.Mvc;

using System.Net;
using System;

using TESTApplication.PersonalTest;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/personal-test")]
    public class PersonalTestController : ControllerBase
    {
        private readonly IPersonalTestService personalTestService;

        public PersonalTestController(IPersonalTestService personalTestService)
        {
            this.personalTestService = personalTestService;
        }

        [HttpGet]
        [Route("GetPersonalList")]
        public async Task<ActionResult<List<PersonalDTO>>> GetPersonalList()
        {
            try 
            {
                var result = await personalTestService.GetPersonal();

                return Ok(result);
            }
            catch(Exception ex) 
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("InsertPerson")]
        public async Task<ActionResult<PersonalDTO>> InsertPerson([FromBody] PersonalDTO input) 
        {
            try
            {
                var result = await personalTestService.AddPersonal(input);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPut]
        [Route("UpdatePerson/{id}")]
        public async Task<ActionResult<PersonalDTO>> UpdatePerson([FromBody] PersonalDTO input, int id) 
        {
            try
            {
                input.Id = id;
                var result = await personalTestService.UpdatePersonal(input);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpDelete]
        [Route("DeletePerson/{id}")]
        public async Task<ActionResult<bool>> DeletePersonal(int id) 
        {
            try
            {
                var result = await personalTestService.DeletePersonal(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
