using front_to_back.Areas.Admin.ViewModels;
using front_to_back.DAL;
using front_to_back.ViewModels.Contact;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace front_to_back.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public ContactController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var model = new ContactIndexVIewModel
            {
                ContactBannerHeroe = await _appDbContext.ContactBannerHeroes.FirstOrDefaultAsync()
            };
            return View(model);
        }
    }
}
