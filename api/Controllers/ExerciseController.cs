using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using api.Models;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        // GET: api/Exercise
        [HttpGet]
        public List<Exercise> Get()
        {
            ExerciseUtility utility = new ExerciseUtility();
            return utility.GetAllExercises();
        }

        // POST: api/Exercise
        [HttpPost]
        public void Post([FromBody] Exercise value)
        {
            ExerciseUtility utility = new ExerciseUtility();
            utility.AddExercise(value);
        }

        // PUT: api/Exercise
        [HttpPut]
        //  [FromBody] Exercise value
        public void Put([FromBody] Exercise value)
        {
            ExerciseUtility utility = new ExerciseUtility();
            utility.PinExercise(value);
        }

        // DELETE: api/Exercise/5
        [HttpDelete]
        public void Delete([FromBody] Exercise value)
        {
            ExerciseUtility utility = new ExerciseUtility();
            utility.DeleteExercise(value);
        }
    }
}
