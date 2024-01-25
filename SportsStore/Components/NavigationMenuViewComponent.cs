using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Components;

public class NavigationMenuViewComponent : ViewComponent
{
    private IStoreRepository repository;

    public NavigationMenuViewComponent(IStoreRepository repo)
    {
        repository = repo;
    }

    public IViewComponentResult Invoke()
    {
        ViewBag.SelectedCategory = RouteData?.Values["category"];
        var products = repository.Products.Select(x => x.Category).Distinct().OrderBy(x => x);

        return View(products);
    }
}