using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using UselessApi.Model;

namespace UselessApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemoryController : ControllerBase
    {
        static readonly IMemoryRepository repository = new MemoryRepository();

        /// <summary>
        /// Retrieves the most recent thought.
        /// </summary>
        /// <returns>The most recent thought</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public string GetThought()
        {
            return repository.Get().Thought;
        }

        /// <summary>
        /// Adds a new thought to it's memory, from the given string.
        /// Thoughts stack, and there will always be one thought.
        /// </summary>
        /// <param name="thought">A string representing a thought.</param>
        /// <returns>The string representing the thought.</returns>
        [HttpPost]
        [ProducesResponseType(201)]
        public String Think(String thought)
        {
            repository.Add(new Memory { Thought = thought });
            return thought;
        }

        /// <summary>
        /// Removes the most recent thought.
        /// Cannot remove the bottom-most thought. 
        /// </summary>
        [HttpDelete]
        [ProducesResponseType(204)]
        public void DeleteThought()
        {
            repository.Remove();
        }

        /// <summary>
        /// Updates the most recent thought.
        /// </summary>
        /// <param name="thought">The new thought to replace the most recent thought.</param>
        /// <returns>The new thought.</returns>
        [HttpPut]
        [ProducesResponseType(201)]
        public String UpdateThought(string thought)
        {
            repository.Update(new Memory { Thought = thought });
            return thought;
        }
    }
}
