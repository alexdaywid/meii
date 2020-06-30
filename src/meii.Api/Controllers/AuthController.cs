using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using meii.Api.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace meii.Api.Controllers
{
    [Route("api/conta")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        // Post: api/conta/registrar-conta
        [HttpPost("registrar")]
        public async Task<ActionResult> Registrar(RegisterUserViewModel registerUser)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = new IdentityUser
            {
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (!result.Succeeded)
            {
                var lstErro = new List<string>();
                foreach (var erro in result.Errors)
                {
                    lstErro.Add(erro.Description);
                }
                return BadRequest(lstErro);
            }

            await _signInManager.SignInAsync(user, false);

            return Ok(registerUser);
        }

        // POST: api/conta/autenticar
        [HttpPost("autenticar")]
        public async Task<ActionResult> AutenticarConta(LoginUserViewModel loginUser)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

            if (result.Succeeded) return Ok(loginUser);
         
            if (result.IsLockedOut) return BadRequest("Usuário temporariamente bloqueado por tentativas inválidas.");

            return BadRequest("Usuário ou senha inválida.");
        }

    }
}
