using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace UselessApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase, IQuoteController
    {
        private readonly HttpClient _client;
        public QuoteController(IHttpClientFactory clientFactory)
        {
            if (clientFactory is null)
            {
                throw new ArgumentNullException(nameof(clientFactory));
            }
            _client = clientFactory.CreateClient("quote");
        }

        /// <summary>
        /// Get a quote to inspire some thoughts of your own.
        /// </summary>
        /// <returns>A random quote</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public String GetQuote()
        {
            var response = _client.GetStringAsync(_client.BaseAddress).Result;
            var quote = JObject.Parse(response).GetValue("content").ToString();

            if (quote == null)
            {
                return "Can't seem to get a quote...";
            }
            else
            {
                return quote;
            }
        }
    }
}
