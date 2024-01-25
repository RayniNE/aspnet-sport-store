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
    public IActionResult Index(int productPage = 1)
    {
        // Pagination
        var products = new ProductsListViewModel
        {
            Products = repository.Products.OrderBy(p => p.Id).Skip((productPage - 1) * PageSize).Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = repository.Products.Count()
            }
        };
        return View(products);
    }
}