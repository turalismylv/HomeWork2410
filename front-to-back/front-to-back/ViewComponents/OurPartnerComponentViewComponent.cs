using front_to_back.DAL;
using front_to_back.ViewModels.About;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace front_to_back.ViewComponents
{
    public class OurPartnerComponentViewComponent :ViewComponent
    {
        private readonly AppDbContext _appDbContext;

        public OurPartnerComponentViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var ourPartnerComponent = await _appDbContext.OurPartnerComponents.OrderByDescending(opc=>opc.Id).Take(3).ToListAsync();
            return View(ourPartnerComponent);
        }
    }
}
