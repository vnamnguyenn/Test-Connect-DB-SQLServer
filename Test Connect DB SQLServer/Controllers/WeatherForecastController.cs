using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace Test_Connect_DB_SQLServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IConfiguration _config;
        public WeatherForecastController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            using var connection = new NpgsqlConnection(_config.GetConnectionString("DefaultConnection"));
            var heroes = await connection.QueryAsync<Product>("select * from product");
            return Ok(heroes);
        }
    }
}