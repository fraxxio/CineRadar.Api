using Microsoft.AspNetCore.Mvc;

namespace CineRadarAI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> GetAllUsers()
        {
            return Ok(await _userService.GetUsers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> GetUserById(int id)
        {
            return Ok(await _userService.GetUserById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> AddUser(AddUserDto newUser)
        {
            return Ok(await _userService.AddUser(newUser));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> UpdateUser(UpdateUserDto updatedUser)
        {
            var response = await _userService.UpdateUser(updatedUser);
            return response.Data is null ? NotFound(response) : Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> DeleteUser(int id)
        {
            var response = await _userService.DeleteUser(id);
            return response.Data is null ? NotFound(response) : Ok(response);
        }
    }
}