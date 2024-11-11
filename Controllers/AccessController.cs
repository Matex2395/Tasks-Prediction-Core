using AdminMVC.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Security.Claims;
using AdminMVC.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AdminMVC.Controllers
{
    public class AccessController : Controller
    {
        private readonly AdminMvcContext _db;

        public AccessController(AdminMvcContext context)
        {
            _db = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserVM model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                ViewData["Message"] = "Las contraseñas no coinciden";
                return View();
            }

            User user = new User
            {
                UserName = model.Name,
                UserEmail = model.Email,
                UserPassword = model.Password,
                CreatedAt = DateTime.Now,
                UserRole = "Developer"
            };

            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();

            if (user.UserId != 0) return RedirectToAction("Login", "Access");

            ViewData["Message"] = "Ha ocurrido un error al registrar el usuario.";
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity!.IsAuthenticated) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            User? found_user = await _db.Users.FirstOrDefaultAsync(u => u.UserEmail == model.Email && u.UserPassword == model.Password);
            if (found_user == null)
            {
                ViewData["Message"] = "No se encontraron coincidencias.";
                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, found_user.UserName)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties);
            return RedirectToAction("Index", "Home");

        }
    }
}
