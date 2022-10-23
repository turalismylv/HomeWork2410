using front_to_back.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace front_to_back.ViewComponents
{
    public class OurTeamComponentViewComponent :ViewComponent
    {
        private readonly AppDbContext _appDbContext;

        public OurTeamComponentViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var ourTeamComponent = await _appDbContext.OurTeamComponents.ToListAsync();
            return View(ourTeamComponent);
        }
    }
}
