using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using UselessApi.Model

namespace UselessApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemoryController : ControllerBase
    {
        static readonly IMemoryRepository repository = new MemoryRepository();

        public string GetThought()
        {
            return repository.Peak();
        }

        public void Think(String Thought)
        {
            repository.Stack(Thought);
        }

        public void RemoveThought()
        {
            repository.Dequeue();
        }

    }
}
