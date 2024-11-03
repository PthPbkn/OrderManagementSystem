using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Services.Repository;

namespace OrderManagementSystem.ViewComponents
{
    public class TopMenuViewComponent : ViewComponent
    {
        private readonly IMenuRepository _repository;

        public TopMenuViewComponent(IMenuRepository repository)
        {
            this._repository = repository;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var model = await _repository.GetAllMenu();
            return View("Default", model);
        }


    }
}
