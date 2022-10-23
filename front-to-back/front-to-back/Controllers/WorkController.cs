using front_to_back.DAL;
using front_to_back.ViewModels.Work;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace front_to_back.Controllers
{
    public class WorkController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public WorkController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {

            var categories = await _appDbContext.Categories
                                                    .Include(c => c.CategoryComponents)
                                                    .ToListAsync();


            var model = new WorkIndexViewModel
            {
                Categories = categories
            };


            return View(model);
        }
    }
}
