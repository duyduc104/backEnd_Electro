using Microsoft.AspNetCore.Mvc;
using electroMVC.Data;

namespace electroMVC.Controllers
{
	[ViewComponent(Name = "_CategorySide")]
	public class _CategorySideViewComponent : ViewComponent
	{
		private readonly electroMVCContext _context;

		public _CategorySideViewComponent(electroMVCContext context)
		{
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			var _categoryside = _context.Category.ToList();
			return View("_CategorySide", _categoryside);
		}
	}
}
