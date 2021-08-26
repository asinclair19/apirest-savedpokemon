using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;

namespace api_rest_pokemon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        //connection string
        private string _connection = @"Server=bicadwf2tm0arkjefpgd-mysql.services.clever-cloud.com;Database=bicadwf2tm0arkjefpgd; Uid=u65f1nd5r5jgkomb; Pwd=jWXkdGeD8zkFP1D3CbWq";

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Models.Pokemon> lst = null;
            using (var database = new MySqlConnection(_connection))
            {
                var sql_query = "SELECT * FROM pokemon;";

                lst = database.Query<Models.Pokemon>(sql_query);
            }

            return Ok(lst);
        }

        [HttpPost]
        public IActionResult Insert(Models.Pokemon model)
        {
            int result = 0;

            using (var database = new MySqlConnection(_connection))
            {
                var sql_query = "INSERT INTO pokemon(id,name,base_experience,height,img,abilities,moves,stats)" +
                    " VALUES(@id,@name,@base_experience,@height,@img,@abilities,@moves,@stats)";
                result = database.Execute(sql_query, model);
            }
            return Ok("Pokemon saved successfully.");

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int result = 0;

            using (var database = new MySqlConnection(_connection))
            {
                var sql_query = $"DELETE FROM pokemon WHERE id={id}";
                result = database.Execute(sql_query);
            }
            return Ok("Pokemon was deleted from the save list successfully.");

        }
    }
}
