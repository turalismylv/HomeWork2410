using front_to_back.Areas.Admin.ViewModels;
using front_to_back.DAL;
using front_to_back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace front_to_back.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PricingController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public PricingController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var model = new PricingIndexViewModel
            {

                PricingComponents = await _appDbContext.PricingComponents.ToListAsync()

            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PricingComponent pricing)
        {
            if (!ModelState.IsValid) return View(pricing);

            bool isExist = await _appDbContext.PricingComponents
                                                   .AnyAsync(c => c.Title.ToLower().Trim() == pricing.Title.ToLower().Trim());

            if (isExist)
            {
                ModelState.AddModelError("Title", "Bu adda kategory artiq movcuddur");

                return View(pricing);
            }

            await _appDbContext.PricingComponents.AddAsync(pricing);
            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var pricingComponent = await _appDbContext.PricingComponents.FindAsync(id);
            if (pricingComponent == null) return NotFound();

            return View(pricingComponent);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, PricingComponent pricingComponent)
        {
            if (!ModelState.IsValid) return View(pricingComponent);
            if (id != pricingComponent.Id) return BadRequest();

            var pricing = await _appDbContext.PricingComponents.FindAsync(id);
            if (pricing == null) return NotFound();

            bool isExist = await _appDbContext.PricingComponents.
                AnyAsync(p => p.Title.ToLower().Trim() == pricingComponent.Title.ToLower().Trim() && 
                id != pricingComponent.Id);

            if (isExist)
            {
                ModelState.AddModelError("Title", "Bu adda category movcuddur");
                return View(pricingComponent);
            }

            pricing.Title = pricingComponent.Title;
            pricing.Description = pricingComponent.Description; 
            pricing.Cost= pricingComponent.Cost;

            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var pricingComponent = await _appDbContext.PricingComponents.FindAsync(id);
            if (pricingComponent == null) return NotFound();

            return View(pricingComponent);
        }



        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var pricing = await _appDbContext.PricingComponents.FindAsync(id);
            if (pricing == null) return NotFound();

            return View(pricing);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteComponent(int id)
        {



            var dBpricing = await _appDbContext.PricingComponents.FindAsync(id);
            if (dBpricing == null) return NotFound();


            _appDbContext.Remove(dBpricing);

            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
