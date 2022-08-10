using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace UselessApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KanyeController : ControllerBase
    {
        private readonly HttpClient _client;
        public KanyeController(IHttpClientFactory clientFactory)
        {
            if (clientFactory is null)
            {
                throw new ArgumentNullException(nameof(clientFactory));
            }
            _client = clientFactory.CreateClient("kanye");
        }

        /// <summary>
        /// Channel the spirit of Kanye West. Get an inspiring thought to help create your own thoughts.
        /// </summary>
        /// <returns>A quote from Kanye West</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public String GetKanyeQuote()
        {
            var response = _client.GetStringAsync(_client.BaseAddress).Result;
            var quote = JObject.Parse(response).GetValue("quote").ToString();

            if (quote == null)
            {
                return "Can't seem to channel Kanye...";
            } else
            {
                return quote;
            }
        }
    }
}
