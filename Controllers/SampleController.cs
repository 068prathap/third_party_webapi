using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace ThirdPartyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public SampleController()
        {
            _httpClient = new HttpClient();
        }

        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            try
            {
                // Replace "API_URL" with the actual URL of the third-party API you want to access
                var apiUrl = "api/StudentLists";
                _httpClient.BaseAddress = new Uri("https://localhost:7243/");
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    // Process the data or return it as-is
                    return Ok(data);
                }
                else
                {
                    // Handle the error condition
                    return StatusCode((int)response.StatusCode);
                }
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetData(int id)
        {
            try
            {
                // Replace "API_URL" with the actual URL of the third-party API you want to access
                var apiUrl = $"api/StudentLists/{id}";
                _httpClient.BaseAddress = new Uri("https://localhost:7243/");
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    // Process the data or return it as-is
                    return Ok(data);
                }
                else
                {
                    // Handle the error condition
                    return StatusCode((int)response.StatusCode);
                }
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}