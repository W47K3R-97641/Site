using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Site.Data;
using Site.Dtos;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public AuthController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromForm] LoginDto model)
    {
        // 1. Validate model input
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // 2. Check if user exists
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            return Unauthorized(new { error = "Invalid email or password" });
        }

        // 3. Attempt password sign-in
        var result = await _signInManager.PasswordSignInAsync(
            user.UserName!,
            model.Password,
            model.RememberMe,
            lockoutOnFailure: true // optional: lock account after failed attempts
        );

        // 4. Handle login result
        if (result.Succeeded)
        {
            return Redirect("/projects"); // ✅ must return
        }
        else if (result.IsLockedOut)
        {
            return Unauthorized(new { error = "Account locked due to too many failed attempts. Try again later." });
        }
        else
        {
            return Unauthorized(new { error = "Invalid email or password" });
        }
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
       
        // Sign out from the Identity authentication scheme
        await _signInManager.SignOutAsync();

        // Optional: explicitly delete your custom cookie if you renamed it
        Response.Cookies.Delete("AmaroAuth", new CookieOptions
        {
            Path = "/",
            Secure = true,
            HttpOnly = true,
            SameSite = SameSiteMode.Strict
        });

        await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
        Redirect("/login"); // Redirect to login page after logout
        return Ok(new { message = "Logged out" });
    }
}
