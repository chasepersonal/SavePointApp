using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SavePointApp.Data;

namespace SavePointApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class GamesController : Controller
    {
        // Create Database context value for performing database requests
        private readonly GamesDbContext _context;

        // Constructor for controller values
        public GamesController(GamesDbContext context)
        {
            _context = context;
        }

        // Get all game values
        [HttpGet]
        // Make asynchronous so that no threads will be blocked for database calls
        public async Task<IActionResult> GetGames()
        {
            // await modifier keeps thread open until a result is returned
            var games = await _context.Games.ToListAsync();

            // Return a successfull response after retrieving games
            return Ok(games);
        }

        // Get a single game id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGame(int id)
        {
            // Will either return first match or return a default null value
            // Use Lambda expression to retrieve first game that matches on the ID field
            var game = await _context.Games.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(game);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
