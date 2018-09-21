using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SavePointApp.Data;
using SavePointApp.Dtos;

namespace SavePointApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IGamesRepository _repo;
        private readonly IMapper _mapper;
        public UsersController(IGamesRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();

            // Use IEnumerable to return a list of users using the mapping information from the Dto
            var usersToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);

            return Ok(usersToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.GetUser(id);

            // Create variable for return information to the user
            // Will map Dto data to the user and only return necessary information
            var userToReturn = _mapper.Map<UserForDetailedDto>(user);

            // Return the mapped user
            return Ok(userToReturn);
        }
    }
}
