using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using URLShort.Models;
using URLShort.Shortener;

namespace URLShort.Controllers
{
    public class ShortUrlController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public ShortUrlController(ApplicationDbContext context,UserManager<ApplicationUser>userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            List<URLModel> urlModels = _context.Urls.ToList();
            return View("Table.cshtml", urlModels);
        }
        [Route("{*table}")]
        public IActionResult Table()
        {
            List<URLModel> urlModels = _context.Urls.Include(e => e.User).ToList();
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var rolenames = _userManager.GetRolesAsync(user).Result;
            return View(urlModels);
        }

        // public IActionResult ShortUrl(string LongUrl)
        //{ 

        //}
        public IActionResult Create()
        {
            return RedirectToAction("Table");
        }
        [HttpPost]
        public ActionResult Create(String longUrl)
        {
            // if (ModelState.IsValid)
            //{
            //  _context.Urls.Add(model);
            //_context.SaveChanges();
            //return RedirectToAction("Table");
            //}
            var url = new URLModel();
            url.UrlLong = longUrl;
            url.Url ="https://urlShortener.te/"+AlphabetTest.base62Encode(longUrl);
            url.CreationDate=DateTime.Now;
            url.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _context.Urls.Add(url);
            _context.SaveChanges();
            return RedirectToAction("Table");
        }
        public ActionResult Remove(int urlId) 
        {
            var urlToRemove=_context.Urls.SingleOrDefault(url=>url.Id == urlId);
            if (urlToRemove != null) 
            {
                urlToRemove.IsRemoved= true;
                _context.SaveChanges();
            }
            return RedirectToAction("Table");
        }
        public ActionResult Info(int UrlId)
        {
            // List<URLModel> urlModels = _context.Urls.Include(e => e.User).ToList();
            URLModel model = new URLModel();
            int id =UrlId;
            if (id != 0) 
            {
                model = _context.Urls.Include(e => e.User).Where(a=>a.Id==id).Single();
            }
            return View(model);
        }

        [Authorize]
        public ActionResult About()
        {
            
            if (User.Identity.IsAuthenticated)
            {
                var userName = User.Identity.Name;
                var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
                return View();
            }
            return View();
        }
    }
}
