using Microsoft.AspNetCore.Mvc;
using Backend_WebService.Models;
using Backend_WebService.Services;
using Microsoft.Extensions.Configuration;

[ApiController]
[Route("api")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;
    private readonly IConfiguration _config;

    public UserController(UserService userService, IConfiguration config)
    {
        _userService = userService;
        _config = config;
    }

    private bool IsValidApiKey(string? apiKey)
    {
        string validApiKey = _config["API_KEY"] ?? "";
        return !string.IsNullOrEmpty(apiKey) && apiKey == validApiKey;
    }

    [HttpPost("saveData")]
    public async Task<IActionResult> SaveUser(
        [FromBody] UserModel user, 
        [FromHeader(Name = "x-api-key")] string? apiKey)
    {
        if (!IsValidApiKey(apiKey))
            return Unauthorized(new { message = "Invalid API Key" });

        await _userService.SaveUser(user);

        return Ok(new 
        { 
            message = "User saved successfully!",
            user = user 
        });
    }

    [HttpGet("retrieveData")]
    public async Task<IActionResult> RetrieveUser([FromHeader(Name = "x-api-key")] string? apiKey)
    {
        if (!IsValidApiKey(apiKey))
            return Unauthorized(new { message = "Invalid API Key" });

        var user = await _userService.RetrieveUser();
        if (user == null)
            return NotFound(new { message = "No users found" });

        return Ok(user);
    }
}
