using loginmodel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using repository;

namespace Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IloginRepository _loginRepository;
        private readonly IConfiguration _configuration;

        public LoginController(IloginRepository loginRepository, IConfiguration configuration)
        {
            _loginRepository = loginRepository;
            _configuration = configuration;
        }

        [EnableCors("AllowOrigin")]
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _loginRepository.GetUser());
        }

        [EnableCors("AllowOrigin")]
        [HttpPost]
        [Route("InsertUser")]
        public async Task<IActionResult> Post(Login login)
        {
            var find = _loginRepository.validation(login);
            if (find.Count > 0)
            {
                return BadRequest(find.FirstOrDefault());
                // return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            else
            {
                await _loginRepository.InsertUser(login);
                return Ok("added successfully");
            }
        }

        [HttpPut]
        [Route("Updateuser")]
        public async Task<IActionResult> Put(Login login)
        {
            await _loginRepository.UpdateUser(login);
            return Ok("Updated Successfully");
        }
    }
}
