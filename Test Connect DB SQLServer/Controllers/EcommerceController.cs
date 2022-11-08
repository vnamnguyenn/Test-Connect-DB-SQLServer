using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace Test_Connect_DB_SQLServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EcommerceController : ControllerBase
    {
        private readonly IConfiguration _config;
        public EcommerceController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            using var connection = new NpgsqlConnection(_config.GetConnectionString("DefaultConnection"));
            var products = await connection.QueryAsync<Product>("select * from product");
            return Ok(products);
        }
    }
}