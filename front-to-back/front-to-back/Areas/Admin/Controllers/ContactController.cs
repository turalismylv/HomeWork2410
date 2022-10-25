using front_to_back.Areas.Admin.ViewModels;
using front_to_back.DAL;
using front_to_back.Helpers;
using front_to_back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace front_to_back.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFileService _fileService;

        public ContactController(AppDbContext appDbContext,IWebHostEnvironment webHostEnvironment,IFileService fileService)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
            _fileService = fileService;
        }
        public async Task<IActionResult> Index()
        {
            var model = new ContactIndexViewModel
            {
                ContactBannerHeroe = await _appDbContext.ContactBannerHeroes.ToListAsync()
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]

        public  async Task<IActionResult> Create(ContactBannerHero contactBanner)
        {
            if (!ModelState.IsValid) return View(contactBanner);
            if (!contactBanner.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "File image formatinda deyil,Image formatinda secin!");
                return View(contactBanner);
            }
            if (contactBanner.Photo.Length/1024>200)
            {
                ModelState.AddModelError("Photo", "Sekilin olcusu 60 kb dan boyukdur !");
                return View(contactBanner);
            }

            //var fileName = $"{Guid.NewGuid()}_{contactBanner.Photo.FileName}";
            //var path=Path.Combine(_webHostEnvironment.WebRootPath,"assets/img", fileName);

            //using (FileStream fileStream=new FileStream(path,FileMode.Create,FileAccess.ReadWrite))
            //{
            //    await contactBanner.Photo.CopyToAsync(fileStream);
            //}

          
            contactBanner.PhotoPath = await _fileService.UploadAsync(contactBanner.Photo, _webHostEnvironment.WebRootPath);
            await _appDbContext.ContactBannerHeroes.AddAsync(contactBanner);


            await _appDbContext.SaveChangesAsync();


            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var contactBanner = await _appDbContext.ContactBannerHeroes.FindAsync(id);
            if (contactBanner == null) return NotFound();

            return View(contactBanner);

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var contactBanner =  await _appDbContext.ContactBannerHeroes.FindAsync(id);
            if (contactBanner == null) return NotFound();
            
            return View(contactBanner);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteComponent(int id) {
        
            var contactBanner = await _appDbContext.ContactBannerHeroes.FindAsync(id);
            if (contactBanner == null) return NotFound();

            var path = Path.Combine(_webHostEnvironment.WebRootPath, "assets/img", contactBanner.PhotoPath);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            _appDbContext.ContactBannerHeroes.Remove(contactBanner);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        
        }
    }
}
