using electroMVC.Data;
using Microsoft.AspNetCore.Mvc;
namespace electroMVC.Controllers
{
	[ViewComponent(Name = "_Category")]
	public class _CategoryViewComponent : ViewComponent
	{
		private readonly electroMVCContext _context;

		public _CategoryViewComponent(electroMVCContext context)
		{
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			var _category = _context.Category.ToList();
			return View("_Category", _category);
		}
	}
}
