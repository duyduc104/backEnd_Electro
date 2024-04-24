using electroMVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace electroMVC.Controllers
{
	[ViewComponent(Name = "_BrandSide")]
	public class _BrandSideViewComponent : ViewComponent
	{
		private readonly electroMVCContext _context;

		public _BrandSideViewComponent(electroMVCContext context)
		{
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			var _brandside = _context.Brand.ToList();
			return View("_BrandSide", _brandside);
		}
	}
}
