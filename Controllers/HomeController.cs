using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Microsoft.AspNetCore.Authorization;
using Shop.Services;
using Shop.Repositories;

namespace Shop.Controllers
{
    [Route("v1/account")]
    public class HomeController : ControllerBase
    {
        [HttpPost]
[Route("login")]
public async Task<ActionResult<dynamic>> Authenticate([FromBody]User model)
{
    // Recupera o usuário
    var user = UserRepository.Get(model.Username, model.Password);

    // Verifica se o usuário existe
    if (user == null)
        return NotFound(new { message = "Usuário ou senha inválidos" });

    // Gera o Token
    var token = TokenService.GenerateToken(user);

    // Oculta a senha
    user.Password = "";
    
    // Retorna os dados
    return new
    {
        user = user,
        token = token
    };
}
        
    }
}