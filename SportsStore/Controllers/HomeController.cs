using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers;

public class HomeController : Controller
{

    private IStoreRepository repository;
    public int PageSize = 4;

    public HomeController(IStoreRepository repo)
    {
        repository = repo;
    }

    [HttpGet]
    public IActionResult Index(string? category, int productPage = 1)
    {

        var products = repository.Products
                     .Where(p => category == null || p.Category == category);

        var paginatedProducts = products.OrderBy(p => p.Id)
                     .Skip((productPage - 1) * PageSize)
                     .Take(PageSize);


        var totalItems = repository.Products.Where(p => category == null || p.Category == category).Count();

        var pagingInfo = new PagingInfo
        {
            CurrentPage = productPage,
            ItemsPerPage = PageSize,
            TotalItems = totalItems
        };

        // Pagination
        var filteredProducts = new ProductsListViewModel
        {
            Products = paginatedProducts,
            PagingInfo = pagingInfo,
            CurrentCategory = category
        };
        return View(filteredProducts);
    }
}