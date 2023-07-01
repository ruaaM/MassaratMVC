using MassaratMVC.Interfaces;
using MassaratMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace MassaratMVC.Controllers
{

    public class MassaratController : Controller
    {

        private readonly IMassaratAPI _massaratAPI;
        public MassaratController(IMassaratAPI massaratAPI)
        {
            _massaratAPI = massaratAPI;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            try
            {
                if (loginRequest == null)
                {
                    return View("Error");
                }

                var result = await _massaratAPI.LoginService(loginRequest);
                if (result.isSuccess) {
                    return RedirectToAction("Index", "Home");
                }

            }
            catch (Exception e)
            {
                return View(e);
            }
          


            return View();
        }
    }
}
