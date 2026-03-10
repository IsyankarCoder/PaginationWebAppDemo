using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaginationWebAppDemo.Data;

namespace PaginationWebAppDemo.Controllers
{
    public class ProductController 
        : Controller
    {

        private readonly AppDbContext appDbContext;

        public ProductController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        /* public async Task<IActionResult> Index(int page = 1)
         {
             int pageSize = 5;
             var totalCount = await appDbContext.Products.CountAsync();

             var products = await appDbContext
                                 .Products
                                 .Skip((page - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();

             ViewBag.TotalPages = (int)Math.Ceiling((double)totalCount / pageSize);
             ViewBag.CurrentPage = page;

             return View(products);
         }*/

        //Main View
        public async Task<IActionResult> Index(int page = 1,CancellationToken cancellationToken=default)
        {
            int pageSize = 10;

            var totalCount = await appDbContext.Products.CountAsync(cancellationToken);

            ViewBag.TotalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            ViewBag.CurrentPage = page;

            return View();
        }

        /// <summary>
        /// Partial View / Ajax data
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetProducts(int page = 1,CancellationToken cancellationToken=default)
        
        {

            int pageSize = 10;
            var totalCount = await appDbContext.Products.CountAsync(cancellationToken);

            var products = await appDbContext
                                .Products
                                .OrderBy(x => x.Id)
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

            ViewBag.TotalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            ViewBag.CurrentPage = page;

            return PartialView("_ProductRows", products);
        }
    }
}
