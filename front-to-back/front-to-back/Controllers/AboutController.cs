using front_to_back.DAL;
using front_to_back.ViewModels.About;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace front_to_back.Controllers
{

    public class AboutController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public AboutController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            return View();
            

            
        }
        public async Task<IActionResult> LoadMore(int skipRowww)
        {
            var ourPartnerComponents = await _appDbContext.OurPartnerComponents.OrderByDescending(prc => prc.Id).Skip(3 + skipRowww).Take(1).ToListAsync();
            return PartialView("_OurPartnerComponentPartial", ourPartnerComponents);

        }
    }
}
