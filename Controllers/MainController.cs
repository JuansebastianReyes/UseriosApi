using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Models;
using UsuariosApi.Models.Interfaces;
using UsuariosApi.Repositories;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("api/")]
    public class MainController : Controller
    {
        private readonly ILogger<MainController> _logger;
        private readonly IUsuarioRepository _usuarioRepository;

        public MainController(
            ILogger<MainController> logger,
            IUsuarioRepository usuarioRepository
        )
        {
            _logger = logger;
            _usuarioRepository = usuarioRepository;
        }
        
        [Route("login")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login(UserLogin loginData){
            try
            {
                bool login = await _usuarioRepository.Login(loginData);

                return Ok(login);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [Route("register")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser(UsuarioRegister usuarioRegister){
            try
            {
                var response = await _usuarioRepository.CreateUsuario(usuarioRegister);

                return Ok(response);

            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCount()
        {
            try
            {
                var count = await _usuarioRepository.CountUser();
                return Ok(new { Count = count });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "Internal Server Error", Message = ex.Message });
            }
        }
    }
}